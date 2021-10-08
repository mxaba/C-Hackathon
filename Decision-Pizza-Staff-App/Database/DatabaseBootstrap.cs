using Dapper;
using Microsoft.Data.Sqlite;
using Decision_Pizza_Staff_App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Decision_Pizza_Staff_App.Database
{

    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly IWaiterRepository waiterRepository;
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig, IWaiterRepository waiterRepository)
        {
            this.databaseConfig = databaseConfig;
            this.waiterRepository = waiterRepository;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'WaiterManager';");
            var tableName = table.FirstOrDefault();
            var tableTime = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'TimeSlots';");
            var tableNameTime = tableTime.FirstOrDefault();
            if ((!string.IsNullOrEmpty(tableName) && tableName == "WaiterManager") || (!string.IsNullOrEmpty(tableNameTime) && tableNameTime == "TimeSlots"))
                // connection.Execute("DROP TABLE WaiterManager");
                // connection.Execute("DROP TABLE TimeSlots");
                return;
            

            connection.Execute("Create Table WaiterManager (" +
                "EmployId VARCHAR(100) NOT NULL," +
                "FullNames VARCHAR(100) NOT NULL," +
                "Status VARCHAR(100) NOT NULL);"
            );

            connection.Execute("Create Table TimeSlots (" +
                "TimeSlotsId INTEGER NOT NULL PRIMARY KEY," +
                "EmployId VARCHAR(100) NOT NULL," +
                "FullNames VARCHAR(100) NOT NULL," +
                "Status VARCHAR(100) NOT NULL," +
                "Time VARCHAR(100) NOT NULL," +
                "Day VARCHAR(100) NOT NULL);"
            );

            connection.Execute("CREATE UNIQUE INDEX IWaiterManager ON WaiterManager (EmployId);");

            Task.Run(async () => {
                    await waiterRepository.CreateManager();
            }).GetAwaiter().GetResult();
        }
    }
}