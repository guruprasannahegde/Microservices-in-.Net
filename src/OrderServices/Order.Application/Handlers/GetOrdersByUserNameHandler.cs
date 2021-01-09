using MediatR;
using OrderApplication.Mapper;
using OrderApplication.Queries;
using OrderApplication.Responses;
using OrderCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApplication.Handlers
{
    public class GetOrdersByUserNameHandler : IRequestHandler<GetOrdersByUserNameQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByUserNameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrderByUserName(request.UserName);

            return OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderList);
        }
    }
}
