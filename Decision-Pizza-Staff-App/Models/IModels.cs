namespace Decision_Pizza_Staff_App.Models
{
   public interface IWaiterManager
    {
        string EmployId { get; set; }
        string FullNames { get; set; }
        string Status { get; set; }
        string TimeSlotsId { get; set; }
        string Day { get; set; }
        string Time { get; set; }
        string Message { get; set; }
    }
}