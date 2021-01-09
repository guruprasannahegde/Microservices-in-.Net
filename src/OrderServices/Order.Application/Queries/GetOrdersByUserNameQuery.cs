using MediatR;
using OrderApplication.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Queries
{
    public class GetOrdersByUserNameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }

        public GetOrdersByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
