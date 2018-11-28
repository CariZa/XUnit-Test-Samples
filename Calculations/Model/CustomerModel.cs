using System;
using System.ComponentModel.DataAnnotations;

namespace Calculations.Model
{
    public class CustomerModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
