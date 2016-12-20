using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;

namespace LoanLending.Observers
{
    interface IClientObserver
    {
        void Notify(ClientValues clientValues);
    }
}
