using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ToolBox.Connections.Database
{
    public class Connection : IConnection
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        public Connection(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            if (selector is null)
                throw new ArgumentNullException();

            using (DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    using (IDataReader dataReader = dbCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return selector(dataReader);
                        }
                    }
                }
            }
        }

        public dynamic ExecuteScalar(Command command)
        {
            using (DbConnection connection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    return dbCommand.ExecuteScalar();
                }
            }
        }

        private DbConnection CreateConnection()
        {
            DbConnection connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionString;

            return connection;
        }

        private DbCommand CreateCommand(Command command, DbConnection connection)
        {
            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = command.Query;

            if (command.IsStoredProcedure)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                DbParameter parameter = _providerFactory.CreateParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value;

                dbCommand.Parameters.Add(parameter);
            }

            return dbCommand;
        }
    }
}
