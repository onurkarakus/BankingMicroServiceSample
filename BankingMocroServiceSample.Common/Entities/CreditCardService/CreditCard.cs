using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.Common.Entities.CreditCardService
{
    [Table("CreditCards", Schema = "CreditCard")]
    public class CreditCard
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string EmbossName { get; set; }
        public string CVV { get; set; }
        public int LastUseYear { get; set; }
        public int LastUseMonth { get; set; }

        public DateTime LastUseDate
        {
            get
            {
                return new DateTime(LastUseYear, LastUseMonth, 1);
            }
        }
    }
}
