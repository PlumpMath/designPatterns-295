using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Observers;
using LoanLending.DataSets;

namespace LoanLending.Domain
{
    class Client : ILoanObserver
    {
        private string clientId;
        private string name;
        private decimal debtAmount;
        private List<IClientObserver> observers = new List<IClientObserver>();

        public string clientIdProperty { get { return clientId; } }

        public Client(string clientId, string name)
        {
            this.clientId = clientId;
            this.name = name;
            this.debtAmount = 0;
        }

        public void NotifyObservers()
        {
            ClientValues values = new ClientValues();
            values.clientId = clientId;
            values.name = name;
            values.debtAmount = debtAmount;

            foreach(IClientObserver observer in observers)
            {
                observer.Notify(values);
            }
        }

        public void AddObserver(IClientObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(LoanValues loanValues)
        {
            debtAmount -= loanValues.amountChange;
            NotifyObservers();
        }
    }
}
