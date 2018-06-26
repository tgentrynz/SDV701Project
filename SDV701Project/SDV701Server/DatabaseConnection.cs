using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SDV701Server
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Handles communication with the databse.
    /// </summary>
    internal static class DatabaseConnection
    {
        private static string databaseLocation = $"{AppDomain.CurrentDomain.BaseDirectory}computershopdata.db";
        private static DbProviderFactory providerFactory = DbProviderFactories.GetFactory("System.Data.SQLite");
        private static string connectionString = $"Data Source={databaseLocation};Version=3";

        internal static DataTable GetDataTable(string commandString, Dictionary<string, Object> commandParamaters)
        {
            using (DataTable table = new DataTable("TheTable"))
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                command.CommandText = commandString;
                setPars(command, commandParamaters);
                using (DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    table.Load(dataReader);
                return table;
            }
        }

        internal static int Execute(string commandString, Dictionary<string, Object> commandParamaters)
        {
            using (DbConnection connection = providerFactory.CreateConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                command.CommandText = commandString;
                setPars(command, commandParamaters);
                return command.ExecuteNonQuery();
            }
        }

        private static void setPars(DbCommand command, Dictionary<string, Object> parameters)
        {
            if (parameters != null)
                foreach (KeyValuePair<string, Object> item in parameters)
                {
                    DbParameter parameter = providerFactory.CreateParameter();
                    parameter.Value = item.Value == null ? DBNull.Value : item.Value;
                    parameter.ParameterName = '@' + item.Key;
                    command.Parameters.Add(parameter);
                }
        }
    }
}
