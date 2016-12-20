using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;

namespace LoanLending.UIImplementations
{
    class MenuView : IMenuView
    {
        public string ShowMenu(IEnumerable<string> menu)
        {
            var i = 1;
            foreach (var menuItem in menu)
            {
                Console.WriteLine(i + " " + menuItem);
                i++;
            }
            Console.ResetColor();
            Console.WriteLine(".............................................................................");
            return Console.ReadLine();
        }
    }
}
