using entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Order> addOrderAsync(Order order)
        {
            return await repository.addOrderAsync(order);
        }

        public async Task<Order> getOrderAsync(int id)
        {
            return await repository.getOrderAsync(id);
        }
    }
}
