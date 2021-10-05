using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public interface IWaiterRepository
    {
        Task Create(WaiterManager Coder);
        Task CreateManager();
    }
}