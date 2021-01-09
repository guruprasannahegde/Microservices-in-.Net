using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryAvailibility = retry.Value;

            try
            {
                orderContext.Database.Migrate();

                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreConfiguredSeedValues());
                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryAvailibility<3)
                {
                    retryAvailibility++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(orderContext, loggerFactory, retryAvailibility);
                }
            }
        }

        private static IEnumerable<Order> GetPreConfiguredSeedValues()
        {
            return new List<Order>()
            {
                new Order()
                {
                    UserName="David",
                    EmailAddress="David@abc.com",
                    BillingAdress=" David AC 123",
                    City="NYC",
                    State="NY",
                    Country="USA",
                    ZipCode="1111",
                    CardNumber="12345678909876",
                    CVV="123"
                }
            };
        }
    }
}
