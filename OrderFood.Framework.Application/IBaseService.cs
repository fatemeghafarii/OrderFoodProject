namespace OrderFood.Framework.Application
{
    public interface IBaseService<TAggregate> where TAggregate : class
    {
        Task<int> CreateAsync(TAggregate aggregate);
        Task<int> UpdateAsync(TAggregate aggregate);
        Task<TAggregate?> GetByIdAsync(Guid id);
        Task<List<TAggregate>> GetAsync(int skip, int take);
        Task<int> RemoveAsync(Guid id);
    }
}
