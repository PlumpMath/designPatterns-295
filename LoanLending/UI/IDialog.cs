using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanLending.UI
{
    interface IDialog
    {
        IEnumerable<string> ShowDialog(IEnumerable<string> selections);
        string ShowDialogSingle(IEnumerable<string> selections);
        void ShowMessage(string message);
    }
}
