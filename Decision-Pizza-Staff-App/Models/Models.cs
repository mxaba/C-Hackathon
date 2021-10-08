using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models
{

    public class WaiterManager : IWaiterManager
    {
        public string EmployId { get; set; }
        public string FullNames { get; set; }
        public string Status { get; set; }
        public int TimeSlotsId { get; set; }
        public List<WaiterManager> TimeslotsResults { get; set; }
        public List<WaiterManager> RequestShiftApproved { get; set; }
        public List<WaiterManager> Monday { get; set; }
        public List<WaiterManager> Tuesday { get; set; }
        public List<WaiterManager> Wednesday { get; set; }
        public List<WaiterManager> Thursday { get; set; }
        public List<WaiterManager> Friday { get; set; }
        public List<WaiterManager> RequestAddShift1 { get; set; }
        public List<WaiterManager> RequestAddShift2 { get; set; }
        public List<WaiterManager> RequestAddShift3 { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }

        // If less than three waiters for a shift, change this variable to = "table-danger text-secondary"
        public string ColourChange = "table-success text-secondary";
    }
}