using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;
using LoanLending.UI;

namespace LoanLending.UIFormattedImplementations
{
    class LoanViewFormatted : ILoanView
    {
        private IDialog dialog;

        public LoanViewFormatted(IDialog dialog)
        {
            this.dialog = dialog;
        }

        public void Notify(LoanValues loanValues)
        {
            ShowLoanInformation(loanValues);
        }

        public void ShowLoanInformation(LoanValues loanData)
        {
            dialog.ShowMessage("-----------------------\nUPDATED LOAN INFORMATION:\n ID = " + loanData.loanId + "\n LOAN AMOUNT = " + loanData.loanAmount + "\n INTEREST RATE = " + loanData.interestRate + "\n TERM = " + loanData.term + "\n AMOUNT TO PAY = " + loanData.amountToPay + ((loanData.amountChange == 0) ? "" : " OLD AMOUNT TO PAY = " + (loanData.amountToPay + loanData.amountChange)));
        }
    }
}
