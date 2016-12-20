using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Commands;
using LoanLending.CommandImplementations;

namespace LoanLending.UI
{
    interface IUIFactory
    {
        IClientView CreateClientView();
        ILoanView CreateLoanView();
        IMenuView CreateMenuView();
        IController CreateController(ICommandProcessor commandProcessor, Dictionary<string, ICommand> commands);
        IDialog CreateDialog();
    }
}
