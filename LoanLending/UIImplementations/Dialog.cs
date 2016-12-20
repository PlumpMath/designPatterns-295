using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;

namespace LoanLending.UIImplementations
{
    class Dialog : IDialog
    {
        public IEnumerable<string> ShowDialog(IEnumerable<string> selections)
        {
            var results = new List<string>();
            foreach (var selection in selections)
            {
                Console.WriteLine(selection);
                results.Add(Console.ReadLine());
            }
            Console.WriteLine("..................................................................................");
            return results;
        }

        public string ShowDialogSingle(IEnumerable<string> selections)
        {
            string result;
            Console.WriteLine();
            foreach (var selection in selections)
            {
                Console.WriteLine(selection);
            }
            result = Console.ReadLine();
            Console.WriteLine("..................................................................................");
            return result;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
