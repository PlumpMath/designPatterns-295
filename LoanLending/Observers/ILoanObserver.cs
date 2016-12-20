using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;

namespace LoanLending.Observers
{
    interface ILoanObserver
    {
        void Notify(LoanValues loanValues);
    }
}
