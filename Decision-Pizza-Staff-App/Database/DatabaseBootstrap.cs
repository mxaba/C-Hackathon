using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SQLLite_Database.Database
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
            if (!string.IsNullOrEmpty(tableName) && tableName == "WaiterManager")
                // connection.Execute("DROP TABLE WaiterManager");
                return;

            connection.Execute("Create Table WaiterManager (" +
                "EmployId VARCHAR(100) NOT NULL," +
                "FullNames VARCHAR(100) NOT NULL," +
                "Status VARCHAR(100) NOT NULL);"
            );

            connection.Execute("CREATE UNIQUE INDEX IWaiterManager ON WaiterManager (EmployId);");

            int i = 0;
            while (i <= 10)
            {
                var waiterManagerData = new WaiterManager(){
                    EmployId = Faker.Identification.UsPassportNumber(),
                    FullNames = Faker.Name.First(),
                    Status = "waiter",
                };
                Task.Run(async () => {
                    await waiterRepository.Create(waiterManagerData);
                }).GetAwaiter().GetResult();
                i++;
            }

            Task.Run(async () => {
                    await waiterRepository.CreateManager();
            }).GetAwaiter().GetResult();
        }
    }
}