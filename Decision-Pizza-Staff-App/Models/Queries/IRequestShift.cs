using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models.Queries
{
    public interface IRequestShift
    {
        IEnumerable<WaiterManager> InsertTimeSlots(WaiterManager waiter);
        IEnumerable<WaiterManager> RequestShiftSpecific(WaiterManager waiterManager);
    }
}