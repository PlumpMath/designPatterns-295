using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.DataSets;
using LoanLending.UI;

namespace LoanLending.UIImplementations
{
    class ClientView : IClientView
    {
        private IDialog dialog;

        public ClientView(IDialog dialog)
        {
            this.dialog = dialog;
        }

        public void ShowClientInformation(ClientValues clientData)
        {
            dialog.ShowMessage("-----------------------\nUpdated client information:\n ID = " + clientData.clientId + "\n Name = " + clientData.name + "\n Debt amount = " + clientData.debtAmount.ToString("0.00") + "\n-----------------------");
        }

        public void Notify(ClientValues clientValues)
        {
            ShowClientInformation(clientValues);
        }
    }
}
