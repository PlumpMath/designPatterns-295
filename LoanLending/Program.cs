using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;
using LoanLending.UIImplementations;
using LoanLending.Commands;
using LoanLending.CommandImplementations;
using LoanLending.Domain;
using LoanLending.AnnuityLoans;
using LoanLending.Repository;
using LoanLending.RepositoryImplementations;
using Microsoft.Practices.Unity;

namespace LoanLending
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommandProcessor processor = new CommandProcessor();
            DomainFactory domainFactory = new AnnuityFactory();
            IClientRepository clientRepository = new SimpleClientRepository();
            ILoanRepository loanRepository = new SimpleLoanRepository();
            IUIFactory uiFactory = new UIFactory();

            var commands = new Dictionary<string, ICommand>
            {
                {"Add client", new AddClientCommand(uiFactory, domainFactory, clientRepository) },
                {"Add loan", new AddLoanCommand(uiFactory, domainFactory, loanRepository) },
                {"Attach loan to client", new AttachLoanToClient(clientRepository, loanRepository, uiFactory) },
                {"Change interest rate", new ChangeInterestRateCommand(loanRepository, uiFactory) },
                {"Pay", new PayCommand(loanRepository, uiFactory) }
            };

            IController controller = uiFactory.CreateController(processor, commands);
            controller.ShowMenu();
        }
    }
}
