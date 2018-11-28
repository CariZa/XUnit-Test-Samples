using System;
using Calculations.Model;

namespace Calculations.Repositories
{
    public interface ICustomerRepository
    {
        void Save(CustomerModel model);
    }
}
