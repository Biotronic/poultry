using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biotronic.Poultry.Utilities.Database
{
    public class BatchScope : IAsyncDisposable, IDisposable
    {
        private readonly DbContext _context;
        private bool _disposed;

        public BatchScope(DbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("BatchScope has already been disposed.");
            }
            _disposed = true;
            _context.SaveChanges();
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("BatchScope has already been disposed.");
            }
            _disposed = true;
            await _context.SaveChangesAsync();
        }
    }
}