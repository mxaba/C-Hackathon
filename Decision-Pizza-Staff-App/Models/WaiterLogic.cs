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
    public class WaiterLogic : IWaiterLogic
    {
        private readonly DatabaseConfig databaseConfig;

        public WaiterLogic(DatabaseConfig databaseConfig)
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

        public IEnumerable<WaiterManager> InsertTimeSlots(WaiterManager waiter)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            waiter.Status = "Pending";
            var resultsCounter = connection.Query<WaiterManager>("SELECT * FROM TimeSlots;").ToList();
            waiter.TimeSlotsId = resultsCounter.Count();;
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("INSERT INTO TimeSlots (EmployId, FullNames, Status, Time, Day)" + 
                "VALUES (@EmployId, @FullNames, @Status, @Time, @Day);", waiter);
            return results;
        }

        public IEnumerable<WaiterManager> GetTimeSlotsById(WaiterManager waiter)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots WHERE EmployId=@EmployId;", waiter);
            return results;
        }

        public IEnumerable<WaiterManager> GetTimeSlots()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("SELECT * FROM TimeSlots;");
            return results;
        }

        public IEnumerable<WaiterManager> RejectRequestShift(int id)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            var results = connection.Query<WaiterManager>("UPDATE TimeSlots SET Status='Reject' WHERE TimeSlotsId=@TimeSlotsId;", new {TimeSlotsId=id});            
            return results;
        }

        public void ApproveRequestShift(int id)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            //return (IEnumerable<WaiterManager>)
            connection.Query<WaiterManager>("UPDATE TimeSlots SET Status='Approved' WHERE TimeSlotsId=@TimeSlotsId;", new {TimeSlotsId=id});
        }

    }
}
