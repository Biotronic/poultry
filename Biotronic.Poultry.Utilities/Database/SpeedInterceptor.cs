using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Biotronic.Poultry.Utilities.Database
{
    /// <summary>
    /// Explanation needed:
    ///
    /// Entity Framework executes all its queries via sp_Executesql.
    /// sp_Executesql, while pretending to be a sensible procedure that
    /// specifies the types of its parameters (in the @params parameter),
    /// in fact ignores this information, and types everything as
    /// (basically) nvarchar(max).
    ///
    /// This means that e.g. a datetime comparison with a parameter will
    /// execute a conversion from nvarchar(max) to datetime on every
    /// single row, instead of doing it once. This is slower than doing
    /// it once.
    ///
    /// This interceptor forces a conversion by declaring local variables
    /// of the appropriate type and assigning to them from the parameters,
    /// which it renames, so as not to cause collisions, and to avoid
    /// touching the body of the command.
    ///
    /// Why sp_Executesql does not do this, I do not know.
    /// Why Entity Framework does not do this, I can only attribute to
    /// ignorance, ineptitude, imbecility, irrationality and idiocy.
    /// </summary>
    public class SpeedInterceptor : IDbCommandInterceptor
    {
        private const string ParamSuffix = "__";

        public ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            FixCommand(command);
            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        public InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            FixCommand(command);
            return result;
        }

        public InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            FixCommand(command);
            return result;
        }

        public InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            FixCommand(command);
            return result;
        }

        public ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            FixCommand(command);
            return new ValueTask<InterceptionResult<object>>(result);
        }

        public ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            FixCommand(command);
            return new ValueTask<InterceptionResult<int>>(result);
        }

        private static void FixCommand(DbCommand command)
        {
            Trace.WriteLine("==== This query ====");
            Trace.WriteLine(command.CommandText);

            command.CommandText = $"{string.Join("", command.Parameters.OfType<DbParameter>().Select(DeclareParameter))}{command.CommandText}";

            Trace.WriteLine("==== Becomes ====");
            Trace.WriteLine(command.CommandText);

            foreach (DbParameter param in command.Parameters)
            {
                param.ParameterName += ParamSuffix;
            }
        }

        private static string DeclareParameter(DbParameter param)
        {
            return $"DECLARE {param.ParameterName} {GetDbType(param.DbType, param.Size)} = {param.ParameterName}{ParamSuffix};{Environment.NewLine}";
        }

        private static string GetDbType(DbType dbType, int size)
        {
            // Source:
            // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
            return dbType switch
            {
                DbType.AnsiString => size == 0 ? "varchar" : $"varchar({size})",
                DbType.AnsiStringFixedLength => "char",
                DbType.Binary => "binary",
                DbType.Boolean => "bit",
                DbType.Byte => "tinyint",
                DbType.Date => "date",
                DbType.DateTime2 => "datetime2",
                DbType.DateTime => "datetime",
                DbType.DateTimeOffset => "datetimeoffset",
                DbType.Decimal => "decimal",
                DbType.Double => "float",
                DbType.Guid => "uniqueidentifier",
                DbType.Int16 => "smallint",
                DbType.Int32 => "int",
                DbType.Int64 => "bigint",
                DbType.Object => "sql_variant",
                DbType.Single => "real",
                DbType.String => size == 0 ? "nvarchar" : $"nvarchar({size})",
                DbType.StringFixedLength => size == 0 ? "nchar" : $"nchar({size})",
                DbType.Time => "time",
                DbType.Xml => "xml",
                DbType.Currency => "currency",
                DbType.SByte => "tinyint",
                DbType.UInt16 => "smallint",
                DbType.UInt32 => "int",
                DbType.UInt64 => "bigint",
                DbType.VarNumeric => throw new NotSupportedException("The datatype VarNumeric is not supported"),
                _ => throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null)
            };
        }

        #region Unimplemented interceptors
        public InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
        {
            return result;
        }

        public DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            return result;
        }

        public DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return result;
        }

        public object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            return result;
        }

        public int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            return result;
        }

        public ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return new ValueTask<DbDataReader>(result);
        }

        public ValueTask<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return new ValueTask<object>(result);
        }

        public ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return new ValueTask<int>(result);
        }

        public void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
        }

        public Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData,
            InterceptionResult result)
        {
            return result;
        }
        #endregion
    }
}
