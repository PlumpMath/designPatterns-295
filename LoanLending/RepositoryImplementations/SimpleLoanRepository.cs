using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Repository;
using LoanLending.Domain;

namespace LoanLending.RepositoryImplementations
{
    class SimpleLoanRepository : ILoanRepository
    {
        private List<Loan> list = new List<Loan>();

        public void Add(Loan loan)
        {
            list.Add(loan);
        }

        public IEnumerable<Loan> GetAll()
        {
            return list;
        }

        public Loan GetById(string loanId)
        {
            return list.Where(o => o.loanIdProperty == loanId).Single();
        }

        public void Remove(Loan loan)
        {
            list.Remove(loan);
        }
    }
}
