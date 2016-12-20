using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.Commands;
using LoanLending.DataSets;
using LoanLending.Repository;
using LoanLending.UI;

namespace LoanLending.CommandImplementations
{
    class PayCommand : IUndoableCommand
    {
        private Loan loan;
        private LoanValues values;
        private ILoanRepository loanRepository;
        private IUIFactory uiFactory;

        public PayCommand(ILoanRepository loanRepository, IUIFactory uiFactory)
        {
            this.loanRepository = loanRepository;
            this.uiFactory = uiFactory;
        }

        public void Execute()
        {
            IDialog dialog = uiFactory.CreateDialog();
            loan = GetLoan(dialog);
            values = loan.GetValues();
            loan.Pay();
        }

        public void Undo()
        {
            loan.SetLoanValues(values.interestRate, values.amountToPay, values.monthsPayed);
        }

        private Loan GetLoan(IDialog dialog)
        {
            IList<string> arguments = new List<string>();
            arguments.Add("Select loan: \n");

            int i = 0;
            foreach (Loan loan in loanRepository.GetAll())
            {
                i++;
                arguments.Add(i.ToString() + ". " + "Id: " + loan.loanIdProperty + "\n");
            }

            if (i == 0) return null;
            int result;
            bool parseResult = int.TryParse(dialog.ShowDialogSingle(arguments), out result);

            return loanRepository.GetAll().ElementAt(result - 1);
        }

        public object Clone()
        {
            LoanValues loanVal = new LoanValues();
            loanVal.amountToPay = values.amountToPay;
            loanVal.interestRate = values.interestRate;
            loanVal.monthsPayed = values.monthsPayed;
            PayCommand comm = ((PayCommand)this.MemberwiseClone());
            comm.values = loanVal;
            return comm;
        }
    }
}
