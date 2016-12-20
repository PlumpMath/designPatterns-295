using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.Commands
{
    interface ICommandProcessor
    {
        void Execute(ICommand command);
        void Undo();
    }
}
