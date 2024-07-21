//using Microsoft.EntityFrameworkCore;
//using OrderFood.Domain.Foods;
//using OrderFood.Domain.Foods.Contracts;
//using OrderFood.Persistence.EF.Contexts;

//namespace OrderFood.Persistence.EF.Foods
//{
//    public class FoodRepository : IFoodRepository
//    {
//        private readonly OrderFoodContext _orderFoodContext;
//        public FoodRepository(OrderFoodContext orderFoodContext)
//        {
//            _orderFoodContext = orderFoodContext;
//        }
//        public async Task<int> CreateAsync(Food food)
//        {
//            await _orderFoodContext.Food.AddAsync(food);
//            return await _orderFoodContext.SaveChangesAsync();
//        }

//        public async Task<int> RemoveAsync(Food food)
//        {
//             _orderFoodContext.Food.Remove(food);
//             return await _orderFoodContext.SaveChangesAsync();
//        }
 
//        public async Task<int> UpdateAsync(Food food)
//        {
//            _orderFoodContext.Food.Update(food);
//            return await _orderFoodContext.SaveChangesAsync();
//        }
//        public  IQueryable<Food> Get()
//        {
//            return _orderFoodContext.Food.AsNoTracking();
//        }

//        public async Task<Food> GetById(Guid id)
//        {
//            return await _orderFoodContext.Food.FirstAsync(x => x.Id == id);
//        }
//    }
//}
