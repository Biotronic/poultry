using System.Diagnostics;
using AutoMapper;

namespace Biotronic.Poultry.Utilities.Database
{
    public abstract class BaseDbRepository<TContext, TProfile> where TContext : BaseDbContext<TContext> where TProfile : BaseDbProfile<TContext>
    {
        protected TContext Context { get; }

        private UserHandler UserHandler { get; }

        protected Mapper Mapper { get; }

        protected BaseUser CurrentUser => UserHandler.CurrentUser;

        protected BaseDbRepository(TContext context, UserHandler userHandler)
        {
            Context = context;
            UserHandler = userHandler;

            var ctor = typeof(TProfile).GetConstructor(new[] { typeof(TContext) });

            Debug.Assert(ctor != null, $"Default profile must define a 1-argument constructor taking an appropriate context parameter ({typeof(TContext)})");

            Mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile((TProfile)ctor.Invoke(new[] { Context }));
            }));
        }

        protected void UpdateEntities<T>(object entities)
        {
            Mapper.Map<T>(entities);
        }
    }
}