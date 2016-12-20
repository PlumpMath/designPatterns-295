using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanLending.Domain;
using LoanLending.Repository;

namespace LoanLending.RepositoryImplementations
{
    class SimpleClientRepository : IClientRepository
    {
        private List<Client> list = new List<Client>();

        public void Add(Client client)
        {
            list.Add(client);
        }

        public IEnumerable<Client> GetAll()
        {
            return list;
        }

        public Client GetById(string clientId)
        {
            return list.Where(o => o.clientIdProperty == clientId).Single();
        }

        public void Remove(Client client)
        {
            list.Remove(client);
        }
    }
}
