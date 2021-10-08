using System.Collections.Generic;

namespace Decision_Pizza_Staff_App.Models.Queries
{
    public interface IGetSlotsStatus
    {
        IEnumerable<WaiterManager> AprovedSlotsMondays();
        IEnumerable<WaiterManager> AprovedSlotsTuesdays();
        IEnumerable<WaiterManager> AprovedSlotsWednesdays();
        IEnumerable<WaiterManager> AprovedSlotsThursdays();
        IEnumerable<WaiterManager> AprovedSlotsFridayss();
        IEnumerable<WaiterManager> PendingSlots();
    }
}