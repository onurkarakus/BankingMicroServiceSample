using BankingMicroServiceSample.AccountService.Data;
using BankingMicroServiceSample.Common.Entities.AccountService;
using BankingMicroServiceSample.Common.RequestMessages.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.AccountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountServiceContext accountServiceContext;

        public AccountController(AccountServiceContext accountServiceContext)
        {
            this.accountServiceContext = accountServiceContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountsByCustomer(int Id)
        {
            return await accountServiceContext.Accounts.Where(p => p.CustomerNumber == Id).ToListAsync();
        }

        [HttpPost("ApplyForCreditCard")]
        public async Task<IActionResult> ApplyForCreditCard([FromBody] OpenAccountRequest openAccountRequest)
        {
            var customerCardList = await accountServiceContext.Accounts.Where(p => p.CustomerNumber == openAccountRequest.CustomerNo &&
            p.BranchNumber == openAccountRequest.BranchNo &&
            p.SuffixNumber == openAccountRequest.Suffix).ToListAsync();

            if (!customerCardList.Any())
            {
                var newAccount = new Account
                {
                    CustomerNumber = openAccountRequest.CustomerNo,
                    BranchNumber = openAccountRequest.BranchNo,
                    IsActive = true,
                    SuffixNumber = openAccountRequest.Suffix
                };

                accountServiceContext.Add(newAccount);
                await accountServiceContext.SaveChangesAsync();

                return Ok(newAccount.Id);
            }

            return NotFound();
        }
    }
}
