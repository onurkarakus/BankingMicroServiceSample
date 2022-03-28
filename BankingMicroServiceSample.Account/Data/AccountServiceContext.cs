using BankingMicroServiceSample.Common.Entities.AccountService;
using Microsoft.EntityFrameworkCore;

namespace BankingMicroServiceSample.AccountService.Data
{
    public class AccountServiceContext: DbContext
    {
        public AccountServiceContext(DbContextOptions<AccountServiceContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
