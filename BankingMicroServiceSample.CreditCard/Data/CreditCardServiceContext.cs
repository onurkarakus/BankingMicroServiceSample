using BankingMicroServiceSample.Common.Entities.CreditCardService;
using Microsoft.EntityFrameworkCore;

namespace BankingMicroServiceSample.CreditCardService.Data
{
    public class CreditCardServiceContext: DbContext
    {
        public CreditCardServiceContext(DbContextOptions<CreditCardServiceContext> options) : base(options)
        {

        }

        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
