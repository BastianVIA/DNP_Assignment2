using System.Collections.Generic;
using System.Threading.Tasks;
using A1.Data;

namespace A1.Models
{
    public interface IAdultService
    {
        Task<List<Adult>> ReadData();
        Task SaveChanges(IList<Adult> adults);
    }
}