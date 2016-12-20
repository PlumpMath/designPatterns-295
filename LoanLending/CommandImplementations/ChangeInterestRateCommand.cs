using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.Commands;
using LoanLending.UI;
using LoanLending.Repository;

namespace LoanLending.CommandImplementations
{
    class ChangeInterestRateCommand : IUndoableCommand
    {
        private double oldInterestRate;
        private double newInterestRate;
        private ILoanRepository loanRepository;
        private IUIFactory factory;
        private Loan loan;

        public ChangeInterestRateCommand(ILoanRepository loanRepository, IUIFactory factory)
        {
            this.loanRepository = loanRepository;
            this.factory = factory;
        }

        public void Execute()
        {
            IDialog dialog = factory.CreateDialog();
            loan = GetLoan(dialog);
            oldInterestRate = loan.interestRateProperty;
            List<string> args = new List<string>();
            args.Add("Enter new interest rate: ");
            newInterestRate = Double.Parse(dialog.ShowDialogSingle(args));
            loan.ChangeInterestRate(newInterestRate);
        }

        public void Undo()
        {
            loan.ChangeInterestRate(oldInterestRate);
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
            return this.MemberwiseClone();
        }
    }
}
