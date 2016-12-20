using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.CommandImplementations;
using LoanLending.Commands;
using LoanLending.UI;

namespace LoanLending.UIFormattedImplementations
{
    class UIFactoryFormatted : IUIFactory
    {
        public IClientView CreateClientView()
        {
            return new ClientViewFormatted(CreateDialog());
        }

        public IController CreateController(ICommandProcessor commandProcessor, Dictionary<string, ICommand> commands)
        {
            return new ControllerFormatted(commands, commandProcessor, this);
        }

        public IDialog CreateDialog()
        {
            return new DialogFormatted();
        }

        public ILoanView CreateLoanView()
        {
            return new LoanViewFormatted(CreateDialog());
        }

        public IMenuView CreateMenuView()
        {
            return new MenuViewFormatted();
        }
    }
}
