using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;
using LoanLending.Commands;

namespace LoanLending.UIFormattedImplementations
{
    class ControllerFormatted : IController
    {
        private ICommandProcessor processor;
        private IUIFactory uiFactory;
        private Dictionary<string, ICommand> commands;

        public ControllerFormatted(Dictionary<string, ICommand> commands, ICommandProcessor processor, IUIFactory uiFactory)
        {
            this.commands = commands;
            this.processor = processor;
            this.uiFactory = uiFactory;
        }

        public void ShowMenu()
        {
            IDialog dialog = uiFactory.CreateDialog();
            IMenuView menuView = uiFactory.CreateMenuView();
            var menu = commands.Keys.ToList();
            menu.Add("UNDO");
            menu.Add("EXIT");

            while(true)
            {
                var result = menuView.ShowMenu(menu);
                int i = Int32.Parse(result);

                if (i <= commands.Count)
                {
                    if (commands.Values.ToList()[i - 1] is IUndoableCommand)
                        processor.Execute(((commands.Values.ToList()[i - 1]) as IUndoableCommand).Clone() as IUndoableCommand);
                    else
                        processor.Execute(commands.Values.ToList()[i - 1]);
                }
                else if (i == commands.Count + 1)
                {
                    processor.Undo();
                }
                else if (i == commands.Count + 2)
                {
                    return;
                }
            }
        }
    }
}
