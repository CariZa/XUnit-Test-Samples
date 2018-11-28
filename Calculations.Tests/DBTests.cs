using System;
using Calculations.Context;
using Calculations.Model;
using Calculations.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;

namespace Calculations.Tests
{
    public class DBTests
    {
        public DBTests()
        {
        }

        [Fact]
        public void ShouldReturnCustomers()
        {
            //new DbContextOptionsBuilder().UseInMemoryDatabase();

            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: "Customers")
                .Options;

            var context = new CustomerContext(options);

            Seed(context);

            var query = new GetCustomersQueries(context);

            var result = query.Execute();

            Assert.Equal(2, result.Count);

        }

        private void Seed(CustomerContext context)
        {
            var customer = new[]
                {
                    new CustomerModel { FirstName = "Jerry", LastName = "Smith" },
                    new CustomerModel { FirstName = "Smith", LastName = "Jerry" },
                };
            context.CustomerModel.AddRange(customer);
            context.SaveChanges();
        }
    }
}
