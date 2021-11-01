using System.Collections.Generic;
using System.Threading.Tasks;
using A1.Data;

namespace A1.Networking
{
    public interface IClient
    {
        Task<List<Adult>> ReadData();
        Task SaveChanges(IList<Adult> adults);
        Task<List<User>> GetUsers();
    }
}