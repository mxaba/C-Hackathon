using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decision_Pizza_Staff_App.Models
{
    public interface IWaiterLogic
    {
        IEnumerable<WaiterManager> GetWaiterManager(string EmployId);
        IEnumerable<WaiterManager> InsertTimeSlots(WaiterManager waiter);
        IEnumerable<WaiterManager> GetTimeSlotsById(WaiterManager waiter);
        IEnumerable<WaiterManager> GetTimeSlots();
        void ApprovetShift(int id);
        void RejecttShift(int id);
    }
}