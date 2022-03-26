using BankingMicroServiceSample.Common.Entities.CreditCardService;
using BankingMicroServiceSample.CreditCardService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faker;

namespace BankingMicroServiceSample.CreditCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardServiceContext creditCardServiceContext;

        public CreditCardController(CreditCardServiceContext creditCardServiceContext)
        {
            this.creditCardServiceContext = creditCardServiceContext;
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCardByCustomer(int Id)
        {
            return await creditCardServiceContext.CreditCards.Where(p=>p.CustomerId == Id).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForCreditCard(int CustomerId)
        {
            var customerCardList = await creditCardServiceContext.CreditCards.Where(p => p.CustomerId == CustomerId).ToListAsync();

            if (!customerCardList.Any())
            {
                var newCard = new CreditCard
                {
                    CustomerId = CustomerId,
                    CVV = Faker.RandomNumber.Next(999).ToString(),
                    EmbossName = Faker.Name.FullName(NameFormats.Standard),
                    LastUseMonth = Faker.Identification.DateOfBirth().Month,
                    LastUseYear = Faker.Identification.DateOfBirth().Year, 
                    CardNumber = Faker.RandomNumber.Next(6, 6).ToString()
                };

                creditCardServiceContext.Add(newCard);
                await creditCardServiceContext.SaveChangesAsync();

                return Ok(CustomerId);
            }

            return NotFound();            
        }
    }
}
