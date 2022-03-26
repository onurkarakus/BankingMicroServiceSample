using BankingMicroServiceSample.Common.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace BankingMicroServiceSample.CustomerService.Data
{
    public class CustomerServiceContext: DbContext
    {
        public CustomerServiceContext(DbContextOptions<CustomerServiceContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
