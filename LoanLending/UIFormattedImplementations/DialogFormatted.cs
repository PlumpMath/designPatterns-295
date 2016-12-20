using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;

namespace LoanLending.UIFormattedImplementations
{
    class DialogFormatted : IDialog
    {
        public IEnumerable<string> ShowDialog(IEnumerable<string> selections)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            var results = new List<string>();
            foreach (var selection in selections)
            {
                Console.WriteLine(selection);
                results.Add(Console.ReadLine());
            }
            Console.ResetColor();
            Console.WriteLine("..................................................................................");
            return results;
        }

        public string ShowDialogSingle(IEnumerable<string> selections)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string result;
            Console.WriteLine();
            foreach (var selection in selections)
            {
                Console.WriteLine(selection);
            }
            result = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("..................................................................................");
            return result;
        }

        public void ShowMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }
    }
}
