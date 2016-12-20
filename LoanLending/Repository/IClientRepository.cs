using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;

namespace LoanLending.Repository
{
    interface IClientRepository
    {
        void Add(Client client);
        void Remove(Client client);
        IEnumerable<Client> GetAll();
        Client GetById(string clientId);
    }
}
