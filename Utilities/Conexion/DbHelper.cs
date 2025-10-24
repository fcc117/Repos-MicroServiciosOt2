using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Utilities.Conexion
{
    public class DbHelper : IDbHelper
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _factory;

        public DbHelper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("OrdenesTrabajoConnection");
            _factory = SqlClientFactory.Instance;
        }

        private DbCommand CreateCommand(string procedureName, Dictionary<string, object> parameters)
        {
            var connection = _factory.CreateConnection();
            connection.ConnectionString = _connectionString;

            var command = connection.CreateCommand();
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                var dbParam = command.CreateParameter();
                dbParam.ParameterName = param.Key;
                dbParam.Value = param.Value ?? DBNull.Value;
                command.Parameters.Add(dbParam);
            }

            return command;
        }

        public async Task<int> ExecuteNonQueryAsync(string procedureName, Dictionary<string, object> parameters)
        {
            using var command = CreateCommand(procedureName, parameters);
            await command.Connection.OpenAsync();
            return await command.ExecuteNonQueryAsync();
        }

        public async Task<object> ExecuteScalarAsync(string procedureName, Dictionary<string, object> parameters)
        {
            using var command = CreateCommand(procedureName, parameters);
            await command.Connection.OpenAsync();
            return await command.ExecuteScalarAsync();
        }

        public async Task<DataTable> ExecuteDataTableAsync(string procedureName, Dictionary<string, object> parameters)
        {
            using var command = CreateCommand(procedureName, parameters);
            using var adapter = _factory.CreateDataAdapter();
            adapter.SelectCommand = command;

            var table = new DataTable();
            await command.Connection.OpenAsync();
            adapter.Fill(table);
            return table;
        }
    }


}
