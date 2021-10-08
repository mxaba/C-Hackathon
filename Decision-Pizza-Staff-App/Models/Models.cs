using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models
{

    public class WaiterManager : IWaiterManager
    {
        public string EmployId { get; set; }
        public string FullNames { get; set; }
        public string Status { get; set; }
        public string TimeSlotsId { get; set; }
        public List<WaiterManager> TimeslotsResults { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }

        // If less than three waiters for a shift, change this variable to = "table-danger text-secondary"
        public string ColourChange = "table-success text-secondary";
    }
}