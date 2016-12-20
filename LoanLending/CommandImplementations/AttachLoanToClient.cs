using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.Commands;
using LoanLending.Repository;
using LoanLending.UI;


namespace LoanLending.CommandImplementations
{
    class AttachLoanToClient : ICommand
    {
        private IClientRepository clientRepository;
        private ILoanRepository loanRepository;
        private IUIFactory factory;

        public AttachLoanToClient(IClientRepository clientRepository, ILoanRepository loanRepository, IUIFactory factory)
        {
            this.clientRepository = clientRepository;
            this.loanRepository = loanRepository;
            this.factory = factory;
        }

        public void Execute()
        {
            IDialog dialog = factory.CreateDialog();
            IClientView clientView = factory.CreateClientView();
            ILoanView loanView = factory.CreateLoanView();
            Client client = GetClient(dialog);
            Loan loan = GetLoan(dialog);

            client.Notify(loan.GetValues());

            loan.AddObserver(client);
        }

        private Client GetClient(IDialog dialog)
        {
            IList<string> arguments = new List<string>();
            arguments.Add("Select client: \n");

            int i = 0;
            foreach (Client client in clientRepository.GetAll())
            {
                i++;
                arguments.Add(i.ToString() + ". " + "Id: " + client.clientIdProperty + "\n");
            }

            if (i == 0) return null;
            int result;
            bool parseResult = int.TryParse(dialog.ShowDialogSingle(arguments), out result);

            return clientRepository.GetAll().ElementAt(result - 1);
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
    }
}
