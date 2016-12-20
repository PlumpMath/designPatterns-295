using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.CommandImplementations;
using LoanLending.Commands;
using LoanLending.UI;

namespace LoanLending.UIImplementations
{
    class UIFactory : IUIFactory
    {
        public IClientView CreateClientView()
        {
            return new ClientView(CreateDialog());
        }

        public IController CreateController(ICommandProcessor commandProcessor, Dictionary<string, ICommand> commands)
        {
            return new UIImplementations.Controller(commands, commandProcessor, this);
        }

        public IDialog CreateDialog()
        {
            return new Dialog();
        }

        public ILoanView CreateLoanView()
        {
            return new LoanView(CreateDialog());
        }

        public IMenuView CreateMenuView()
        {
            return new MenuView();
        }
    }
}
