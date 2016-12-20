using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.DataSets;
using LoanLending.Commands;
using LoanLending.Repository;
using LoanLending.UI;

namespace LoanLending.CommandImplementations
{
    class AddLoanCommand : ICommand
    {
        private ILoanRepository repository;
        private IUIFactory uiFactory;
        private DomainFactory factory;

        public AddLoanCommand(IUIFactory uiFactory, DomainFactory factory, ILoanRepository repository)
        {
            this.uiFactory = uiFactory;
            this.factory = factory;
            this.repository = repository;
        }

        public void Execute()
        {
            var arguments = new[] { "Id", "Amount", "Term", "Interest rate" };

            IDialog dialog = uiFactory.CreateDialog();
            var input = dialog.ShowDialog(arguments).ToArray();

            string id = input[0];
            decimal amount = Decimal.Parse(input[1]);
            int term = Int32.Parse(input[2]);
            double interestRate = Double.Parse(input[3]);

            Loan loan = factory.createLoan(id, amount, term, interestRate);
            loan.AddObserver(uiFactory.CreateLoanView());

            repository.Add(loan);
        }
    }
}
