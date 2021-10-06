namespace Decision_Pizza_Staff_App.Models
{
    public interface IWaiterManager
    {
        string EmployId { get; set; }
        string FullNames { get; set; }
        string Message { get; set; }
        string Status { get; set; }
    }

    public interface IMessages
    {
        string Message { get; set; }
    }
}