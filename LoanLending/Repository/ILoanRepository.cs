using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;

namespace LoanLending.Repository
{
    interface ILoanRepository
    {
        void Add(Loan loan);
        void Remove(Loan loan);
        IEnumerable<Loan> GetAll();
        Loan GetById(string loanId);
    }
}
