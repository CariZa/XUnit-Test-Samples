using System;
using Calculations.Model;

namespace Calculations.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        //private readonly IConfiguration _configuration;

        //public CustomerRepository(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public void Save(CustomerModel model)
        {
            //var connectionString = _configuration.GetConnectionString("default");
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    var command = connection.CreateCommand();
            //    command.CommandText = "something";
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
        }
    }
}
