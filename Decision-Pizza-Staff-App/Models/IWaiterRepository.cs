using System.Threading.Tasks;

namespace Decision_Pizza_Staff_App.Models
{
    public interface IWaiterRepository
    {
        Task Create(WaiterManager Coder);
        Task CreateManager();
    }
}