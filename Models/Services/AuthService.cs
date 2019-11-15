using Models.Data;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Connections.Database;

namespace Models.Services
{
    public class AuthService : IAuthRepository<User>
    {
        private IConnection _connection;

        public AuthService(IConnection connection)
        {
            _connection = connection;
        }

        public void Register(User entity)
        {
            Command command = new Command("SP_RegisterUser", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);

            _connection.ExecuteNonQuery(command);
        }

        public User Login(User entity)
        {
            Command command = new Command("SP_CheckUser", true);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);

            return _connection.ExecuteReader(command, (dr) => new User() { Id = (int)dr["Id"], LastName = (string)dr["LastName"], FirstName = (string)dr["FirstName"], Email = entity.Email }).SingleOrDefault();
        }

    }
}
