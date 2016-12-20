using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;

namespace LoanLending.LinearLoans
{
    class LinearLoan : Loan
    {
        public LinearLoan(string loanId, decimal loanAmount, int term, double interestRate) : base(loanId, loanAmount, term, interestRate)
        {
        }

        public override decimal getMonthPayment(int month)
        {
            return (loanAmount - (month - 1) * loanAmount / term) * (decimal)interestRate / 1200 + loanAmount / term;
        }
    }
}
