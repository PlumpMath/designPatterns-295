using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Commands;

namespace LoanLending.CommandImplementations
{
    class CommandProcessor : ICommandProcessor
    {
        private List<IUndoableCommand> commands = new List<IUndoableCommand>();

        public void Execute(ICommand command)
        {
            command.Execute();
            if (command is IUndoableCommand)
                commands.Add(command as IUndoableCommand);
        }

        public void Undo()
        {
            if(commands.Count != 0)
            {
                commands.Last().Undo();
                commands.Remove(commands.Last());
            }
        }
    }
}
