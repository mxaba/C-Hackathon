using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models.Queries
{
    public interface IRequestShift
    {
        void RemoveRequests(WaiterManager waiterManager);
        void RemovePendingRequest(WaiterManager waiterManager);
        IEnumerable<WaiterManager> InsertTimeSlots(WaiterManager waiter);
        IEnumerable<WaiterManager> RequestShiftSpecific(WaiterManager waiterManager);
    }
}