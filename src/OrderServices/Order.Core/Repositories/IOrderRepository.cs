using OrderCore.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderCore.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserName(string userName);
    }
}
