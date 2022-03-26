using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.Common.Entities.Customers
{
    [Table("Customers", Schema = "Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public long CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }
}
