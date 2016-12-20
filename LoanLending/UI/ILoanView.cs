using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;
using LoanLending.Observers;

namespace LoanLending.UI
{
    interface ILoanView : ILoanObserver
    {
        void ShowLoanInformation(LoanValues loanData);
    }
}
