using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;

namespace LoanLending.AnnuityLoans
{
    class AnnuityFactory : DomainFactory
    {
        public override Loan createLoan(string loanId, decimal loanAmount, int term, double interestRate)
        {
            return new AnnuityLoan(loanId, loanAmount, term, interestRate);
        }
    }
}
