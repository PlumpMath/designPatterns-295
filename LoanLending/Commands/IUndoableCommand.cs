using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.Commands
{
    interface IUndoableCommand : ICommand, ICloneable
    {
        void Undo();
    }
}
