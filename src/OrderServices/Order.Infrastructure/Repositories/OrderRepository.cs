using Microsoft.EntityFrameworkCore;
using OrderCore;
using OrderCore.Repositories;
using OrderInfrastructure.Data;
using OrderInfrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.Repositories
{
    public class OrderRepository:Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext):base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrderByUserName(string userName)
        {
            return await _dbContext.Orders.Where(o => o.UserName == userName).ToListAsync();
        }
    }
}
