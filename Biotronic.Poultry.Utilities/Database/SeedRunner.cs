using System.Collections.Generic;

namespace Biotronic.Poultry.Utilities.Database
{
    public class SeedRunner<TRepository> where TRepository : IBaseDbRepository
    {
        public TRepository Repository { get; }

        private readonly List<ISeed<TRepository>> _seeds = new List<ISeed<TRepository>>();


        public SeedRunner(TRepository repository)
        {
            Repository = repository;
        }

        public void Add(ISeed<TRepository> seed)
        {
            _seeds.Add(seed);
        }

        public void Seed()
        {
            foreach (var seed in _seeds)
            {
                seed.Run(Repository);
            }
        }
    }
}