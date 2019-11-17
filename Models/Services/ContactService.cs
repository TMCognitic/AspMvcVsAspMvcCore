using Models.Data;
using Models.Mappers;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Command command = new Command("SP_GetContacts", true);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, (dr) => dr.ToContact());
        }

        public Contact Get(int userId, int id)
        {
            Command command = new Command("SP_GetContactById", true);
            command.AddParameter("UserId", userId);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr) => dr.ToContact()).SingleOrDefault();
        }

        public Contact Insert(int userId, Contact entity)
        {
            Command command = new Command("SP_AddContact", true);
            command.AddParameter("UserId", userId);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);

            entity.Id = (int)_connection.ExecuteScalar(command);

            return entity;
        }

        public bool Update(int userId, int id, Contact entity)
        {
            Command command = new Command("SP_UpdateContact", true);
            command.AddParameter("UserId", userId);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Phone", entity.Phone);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int userId, int id)
        {
            Command command = new Command("SP_DeleteContact", true);
            command.AddParameter("UserId", userId);
            command.AddParameter("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
