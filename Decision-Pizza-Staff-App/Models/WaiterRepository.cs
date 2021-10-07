using Dapper;
using Microsoft.Data.Sqlite;
using Decision_Pizza_Staff_App.Database;
using System.Threading.Tasks;

namespace Decision_Pizza_Staff_App.Models
{

    public class WaiterRepository : IWaiterRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public WaiterRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(WaiterManager waiter)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            await connection.ExecuteAsync("INSERT INTO WaiterManager (EmployId, FullNames, Status)" +
                "VALUES (@EmployId, @FullNames, @Status);", waiter);
        }

        public async Task CreateManager()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            await connection.ExecuteAsync("INSERT INTO WaiterManager (EmployId, FullNames, Status)" +
                "VALUES (@EmployId, @FullNames, @Status);", new {EmployId="John1234CodeX", FullNames="John Cena", Status="waiter"});

            await connection.ExecuteAsync("INSERT INTO WaiterManager (EmployId, FullNames, Status)" +
                "VALUES (@EmployId, @FullNames, @Status);", new { EmployId = "VinceMacMacMahonCodeX", FullNames = "Vince MacMacMahon", Status = "manager" });
        }
    }
}