using Microsoft.EntityFrameworkCore;

namespace OrderFood.Framework.Persistence.EF
{
    public class BaseRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(TAggregate aggregate)
        {
            await _dbContext.Set<TAggregate>().AddAsync(aggregate);
            return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TAggregate> GetAsNoTracking()
        {
            return _dbContext.Set<TAggregate>().AsNoTracking();
        } 
        public IQueryable<TAggregate> Get()
        {
            return _dbContext.Set<TAggregate>();
        }

        public TAggregate GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> RemoveAsync(TAggregate aggregate)
        {
            _dbContext.Set<TAggregate>().Remove(aggregate);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TAggregate aggregate)
        {
            _dbContext.Set<TAggregate>().Update(aggregate);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
