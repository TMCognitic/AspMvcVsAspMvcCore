using Models.Data;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ToolBox.Connections.Database;

namespace Models.Services
{
    public class ContactService : IContactRepository<Contact>
    {
        private IConnection _connection;

        public ContactService(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get(int userId)
        {
            throw new NotImplementedException();
        }

        public Contact Get(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Contact Insert(Contact entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(int UserId, int id, Contact entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int UserId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
