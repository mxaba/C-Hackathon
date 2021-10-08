using System.Collections.Generic;
using Dapper;
using Decision_Pizza_Staff_App.Database;
using Microsoft.Data.Sqlite;

namespace Decision_Pizza_Staff_App.Models.Queries
{

    public class GetSlotsStatus : IGetSlotsStatus
    {
        private readonly DatabaseConfig databaseConfig;

        public GetSlotsStatus(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public IEnumerable<WaiterManager> AprovedSlotsMondays()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (Status='Approved' AND Day='Monday');");
            return results;
        }

        public IEnumerable<WaiterManager> AprovedSlotsTuesdays()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (Status='Approved' AND Day='Tuesday');");
            return results;
        }

        public IEnumerable<WaiterManager> AprovedSlotsWednesdays()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (Status='Approved' AND Day='Wednesday');");
            return results;
        }

        public IEnumerable<WaiterManager> AprovedSlotsThursdays()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (Status='Approved' AND Day='Thursday');");
            return results;
        }

        public IEnumerable<WaiterManager> AprovedSlotsFridayss()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE (Status='Approved' AND Day='Friday');");
            return results;
        }

        public IEnumerable<WaiterManager> PendingSlots()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE Status='Pending';");
            return results;
        }
    }
}