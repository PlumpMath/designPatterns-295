using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.UI;

namespace LoanLending.UIFormattedImplementations
{
    class MenuViewFormatted : IMenuView
    {
        public string ShowMenu(IEnumerable<string> menu)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var i = 1;
            foreach (var menuItem in menu)
            {
                Console.WriteLine("MENU ITEM NR. " + i + " " + menuItem);
                i++;
            }
            Console.ResetColor();
            Console.WriteLine(".............................................................................");
            return Console.ReadLine();
        }
    }
}
