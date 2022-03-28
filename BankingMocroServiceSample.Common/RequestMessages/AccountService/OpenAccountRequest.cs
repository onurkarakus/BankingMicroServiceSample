using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroServiceSample.Common.RequestMessages.AccountService
{
    public class OpenAccountRequest
    {
        public int CustomerNo { get; set; }
        public int BranchNo { get; set; }
        public int Suffix { get; set; }        
    }
}
