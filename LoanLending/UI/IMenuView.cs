using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.UI
{
    interface IMenuView
    {
        string ShowMenu(IEnumerable<string> menu);
    }
}
