using System;
using System.Collections.Generic;
using System.Linq;
using Calculations.Context;
using Calculations.Model;

namespace Calculations.Queries
{
    public class GetCustomersQueries
    {
        private readonly CustomerContext _context;
        public GetCustomersQueries(CustomerContext context)
        {
            _context = context;
        }
        public IList<CustomerModel> Execute()
        {
            return _context.CustomerModel
                           .OrderBy(c => c.FirstName)
                           .ToList();
        }
    }
}
