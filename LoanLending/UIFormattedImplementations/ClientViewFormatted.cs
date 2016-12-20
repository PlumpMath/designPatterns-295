using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;
using LoanLending.UI;

namespace LoanLending.UIFormattedImplementations
{
    class ClientViewFormatted : IClientView
    {
        private IDialog dialog;

        public ClientViewFormatted(IDialog dialog)
        {
            this.dialog = dialog;
        }

        public void Notify(ClientValues clientValues)
        {
            ShowClientInformation(clientValues);
        }

        public void ShowClientInformation(ClientValues clientData)
        {
            dialog.ShowMessage("-----------------------\nUPDATED CLIENT INFORMATION:\n ID = " + clientData.clientId + "\n NAME = " + clientData.name + "\n DEBT AMOUNT = " + clientData.debtAmount + "\n-----------------------");
        }
    }
}
