namespace Decision_Pizza_Staff_App.Models
{

    public class WaiterManager : IWaiterManager
    {
        public string EmployId { get; set; }
        public string FullNames { get; set; }
        public string Status { get; set; }
        public string TimeSlotsId { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }

    }
}