//using OrderFood.Domain.Foods;
//using OrderFood.Domain.Foods.Contracts;

//namespace OrderFood.DomainService.Foods
//{
//    public class FoodDomainService : IFoodDomainService
//    {
//        private readonly IFoodRepository _foodRepository;

//        public FoodDomainService(IFoodRepository foodRepository)
//        {
//            _foodRepository = foodRepository;
//        }
//        public async Task<List<Food>> GetAsync()
//        {
//            //return await _foodRepository.GetAsync().ToList();
//            throw new NotImplementedException();
//        }
//        public async Task<int> CreateAsync(Food food)
//        {
//            return await _foodRepository.CreateAsync(food);
//        }
//        public Task<int> UpdateAsync(Food food)
//        {
//            throw new NotImplementedException();
//        }
//        public int Create(Food food)
//        {
//            throw new NotImplementedException();
//        }
//        public void Delete(Food food)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
