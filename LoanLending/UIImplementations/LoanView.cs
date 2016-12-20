using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;
using LoanLending.UI;

namespace LoanLending.UIImplementations
{
    class LoanView : ILoanView
    {
        private IDialog dialog;

        public LoanView(IDialog dialog)
        {
            this.dialog = dialog;
        }

        public void Notify(LoanValues loanValues)
        {
            ShowLoanInformation(loanValues);
        }

        public void ShowLoanInformation(LoanValues loanData)
        {
            dialog.ShowMessage("-----------------------\nUpdated loan information:\n ID = " + loanData.loanId + "\n Loan amount = " + loanData.loanAmount + "\n Interest rate = " + loanData.interestRate + "\n Term = " + loanData.term + "\n Amount to pay = " + loanData.amountToPay.ToString("0.00") + ((loanData.amountChange == 0) ? "" : " Old amount to pay = " + (loanData.amountToPay + loanData.amountChange).ToString("0.00")));
        }
    }
}
