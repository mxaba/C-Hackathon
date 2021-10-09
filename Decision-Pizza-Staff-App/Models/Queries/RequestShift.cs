using System.Collections.Generic;
using System.Linq;
using Dapper;
using Decision_Pizza_Staff_App.Database;
using Microsoft.Data.Sqlite;

namespace Decision_Pizza_Staff_App.Models.Queries
{

    public class RequestShift : IRequestShift
    {
        private readonly DatabaseConfig databaseConfig;

        public RequestShift(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public IEnumerable<WaiterManager> RequestShiftSpecific(WaiterManager waiterManager)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (EmployId=@EmployId AND Day=@Day AND Time=@Time);", waiterManager);
            return results;
        }

        public void RemovePendingRequest(WaiterManager waiterManager)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            connection.Query<WaiterManager>("DELETE FROM TimeSlots WHERE (TimeSlotsId=@TimeSlotsId);", waiterManager);
        }

        public void RemoveRequests(WaiterManager waiterManager)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            connection.Query<WaiterManager>("DELETE FROM TimeSlots;", waiterManager);
        }

        public IEnumerable<WaiterManager> InsertTimeSlots(WaiterManager waiter)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            waiter.Status = "Pending";
            var results = connection.Query<WaiterManager>("INSERT INTO TimeSlots (EmployId, FullNames, Status, Time, Day)" +
                "VALUES (@EmployId, @FullNames, @Status, @Time, @Day);", waiter);
            return results;
        }

    }
}