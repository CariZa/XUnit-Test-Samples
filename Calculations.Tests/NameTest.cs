using System;
using Xunit;

namespace Calculations.Tests
{
    public class NameTest
    {
        [Fact]
        void FullName_GivenNameSurname_ReturnStringFullName()
        {
            Names names = new Names();
            string fullname = names.FullName("Cari","Liebenberg");
            Assert.Equal("Cari Liebenberg", fullname, ignoreCase:true);
            // You can use regex with strings: "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"
        }
    }
}
