using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.DataSets
{
    struct LoanValues
    {
        public string loanId { get; set; }
        public decimal loanAmount { get; set; }
        public double interestRate { get; set; }
        public int term { get; set; }
        public decimal amountToPay { get; set; }
        public decimal amountChange { get; set; }
        public int monthsPayed { get; set; }
    }
}
