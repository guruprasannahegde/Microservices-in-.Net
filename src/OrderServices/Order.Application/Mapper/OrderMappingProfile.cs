using AutoMapper;
using OrderApplication.Responses;
using OrderCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
