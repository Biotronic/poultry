namespace Biotronic.Poultry.Utilities.Database
{
    public abstract class BaseDbRepository<TContext> where TContext : BaseDbContext<TContext>
    {
        protected TContext Context { get; }
        private UserHandler UserHandler { get; }

        protected BaseUser CurrentUser => UserHandler.CurrentUser;

        protected BaseDbRepository(TContext context, UserHandler userHandler)
        {
            Context = context;
            UserHandler = userHandler;
        }
    }
}