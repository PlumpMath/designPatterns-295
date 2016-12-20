using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.Domain
{
    abstract class DomainFactory
    {
        public Client createClient(string clientId, string name)
        {
            return new Client(clientId, name);
        }

        public abstract Loan createLoan(string loanId, decimal loanAmount, int term, double interestRate);
    }
}
