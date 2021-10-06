using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Decision_Pizza_Staff_App.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Decision_Pizza_Staff_App.Models
{
    public class Login : ILogin
    {
        private readonly DatabaseConfig databaseConfig;

        public Login(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public IEnumerable<WaiterManager> GetWaiterManager(string EmployId)
        {
            
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT rowid AS Id, EmployId, FullNames, Status FROM WaiterManager WHERE EmployId=@EmployId;", new { EmployId = EmployId });
            return results;
        }

    }
}
