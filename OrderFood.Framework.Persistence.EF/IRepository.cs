namespace OrderFood.Framework.Persistence.EF
{
    public interface IRepository<TAggregate> where TAggregate : class
    {
        public IQueryable<TAggregate> GetAsNoTracking();
        public IQueryable<TAggregate> Get();
        public TAggregate GetById(Guid id);
        Task<int> CreateAsync(TAggregate aggregate);
        Task<int> UpdateAsync(TAggregate aggregate);
        Task<int> RemoveAsync(TAggregate aggregate);
    }
}
