using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decision_Pizza_Staff_App.Models
{
    public interface ILogin
    {
        IEnumerable<WaiterManager> GetWaiterManager(string EmployId);
    }
}