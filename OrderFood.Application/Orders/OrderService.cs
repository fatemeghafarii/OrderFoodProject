using Microsoft.EntityFrameworkCore;
using OrderFood.Application.Contract.Orders;
using OrderFood.Domain.Foods;
using OrderFood.Domain.Orders;
using OrderFood.Domain.Orders.Arguments;
using OrderFood.Domain.Orders.Entities;
using OrderFood.Framework.Persistence.EF;
using System.Data;
using System.Diagnostics;

namespace OrderFood.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Food> _foodRepository;
        public OrderService(IRepository<Order> orderRepository, IRepository<Food> foodRepository)
        {
            _orderRepository = orderRepository;
            _foodRepository = foodRepository;
        }

        public async Task<int> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var orderArg = orderCreateDto.MapToArgument();
            var id = Guid.NewGuid();
            orderArg.OrderItems = await CreateOrderItems(orderCreateDto.Items, id);
            var order = new Order(id, orderArg);
            return await _orderRepository.CreateAsync(order);

        }

        public async Task<List<OrderGetDto>> GetAsync(int skip, int take)
        {
            var orders = await _orderRepository.GetAsNoTracking().Include(o => o.OrderItems).Skip(skip).Take(take).ToListAsync();
            var result = orders.Select(f => new OrderGetDto
            {
                VendorId = f.VendorId,
                FinalPrice = f.FinalPrice,
                CustomerId = f.CustomerId,
                OrderState = f.OrderState,
                Items = f.OrderItems.Select(i => new OrderItemGetDto { Id = i.Id, Title = i.Title, Count = i.Count, Discount = i.Discount, Price = i.Price }).ToList(),
            }).ToList();

            return result;
        }

        public async Task<OrderGetDto?> GetByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetAsNoTracking().FirstAsync(o => o.Id == id) ?? throw new Exception();

            return new()
            {
                Id = order.Id,
                VendorId = order.VendorId,
                FinalPrice = order.FinalPrice,
                CustomerId = order.CustomerId,
                CreateDate = order.CreateDate,
                OrderState = order.OrderState
            };
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var order = await _orderRepository.Get().FirstAsync(o => o.Id == id);
            return await _orderRepository.RemoveAsync(order);
        }

        public async Task<int> UpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            var order = await _orderRepository.Get().Include(x => x.OrderItems).FirstAsync(o => o.Id == orderUpdateDto.Id);
            var orderItems = await CreateOrderItems(orderUpdateDto.Items, order.Id);
            order.Update(orderUpdateDto.VendorId, orderUpdateDto.CustomerId, orderUpdateDto.OrderState, orderItems);
            return await _orderRepository.UpdateAsync(order);
        }

        private async Task<List<OrderItem>> CreateOrderItems(List<OrderItemDto> items, Guid orderId)
        {
            var foods = await _foodRepository.GetAsNoTracking().Where(f => items.Select(i => i.FoodId).Contains(f.Id)).ToListAsync();
            var orderItemArgs = foods.Select(f => new OrderItemArg()
            {
                OrderId = orderId,
                Count = 0,
                Title = f.Title,
                Price = f.Price,
                Discount = f.Discount,
                FoodId = f.Id
            }).ToList();
            orderItemArgs.ForEach(a =>
            {
                a.Count = items.First(i => i.FoodId == a.FoodId).Count;
            });
            var orderItems = orderItemArgs.Select(a => new OrderItem(a)).ToList();
            return orderItems;
        }
    }
}
