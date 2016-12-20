using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.DataSets;
using LoanLending.Commands;
using LoanLending.Repository;
using LoanLending.UI;

namespace LoanLending.CommandImplementations
{
    class AddClientCommand : ICommand
    {
        private IClientRepository repository;
        private IUIFactory uiFactory;
        private DomainFactory factory;

        public AddClientCommand(IUIFactory uiFactory, DomainFactory factory, IClientRepository repository)
        {
            this.uiFactory = uiFactory;
            this.factory = factory;
            this.repository = repository;
        }

        public void Execute()
        {
            var arguments = new[] { "Id", "Name" };

            IDialog dialog = uiFactory.CreateDialog();
            var input = dialog.ShowDialog(arguments).ToArray();

            string id = input[0];
            string name = input[1];

            Client client = factory.createClient(id, name);
            repository.Add(client);
            client.AddObserver(uiFactory.CreateClientView());
        }
    }
}
