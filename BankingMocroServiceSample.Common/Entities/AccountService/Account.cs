using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.Common.Entities.AccountService
{
    [Table("Accounts", Schema = "Account")]
    public class Account
    {
        public int Id { get; set; }
        public int BranchNumber { get; set; }
        public long CustomerNumber { get; set; }
        public int SuffixNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
