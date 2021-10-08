using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models
{
   public interface IWaiterManager
    {
        string EmployId { get; set; }
        string FullNames { get; set; }
        string Status { get; set; }
        int TimeSlotsId { get; set; }
        List<WaiterManager> TimeslotsResults { get; set; }
        List<WaiterManager> RequestShiftApproved { get; set; }
        List<WaiterManager> Monday { get; set; }
        List<WaiterManager> Tuesday { get; set; }
        List<WaiterManager> Wednesday { get; set; }
        List<WaiterManager> Thursday { get; set; }
        List<WaiterManager> RequestAddShift1 { get; set; }
        List<WaiterManager> RequestAddShift2 { get; set; }
        List<WaiterManager> RequestAddShift3 { get; set; }
        List<WaiterManager> Friday { get; set; }
        string Day { get; set; }
        string Time { get; set; }
        string Message { get; set; }
    }
}