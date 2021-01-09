using Microsoft.EntityFrameworkCore;
using OrderCore;
using OrderCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderInfrastructure.Data
{
    public class OrderContext:DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
