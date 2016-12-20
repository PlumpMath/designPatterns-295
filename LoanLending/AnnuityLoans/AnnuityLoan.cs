using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;

namespace LoanLending.AnnuityLoans
{
    class AnnuityLoan : Loan
    {
        public AnnuityLoan(string loanId, decimal loanAmount, int term, double interestRate) : base(loanId, loanAmount, term, interestRate)
        {
        }

        public override decimal getMonthPayment(int month)
        {
            double coeff = (interestRate / 1200 * (Math.Pow(1 + interestRate / 1200, term)) / (Math.Pow(1 + interestRate / 1200, term) - 1));
            return loanAmount * (decimal)coeff;
        }
    }
}
