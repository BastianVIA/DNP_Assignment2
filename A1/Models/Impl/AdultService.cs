using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using A1.Data;
using A1.Networking;

namespace A1.Models.Impl
{
    public class AdultService : IAdultService
    {
        private IClient _client = new Client();
        
        public async Task<List<Adult>> ReadData()
        {
            return await _client.ReadData();
        }

        public Task SaveChanges(IList<Adult> adults)
        {
            return _client.SaveChanges(adults);
        }
    }
}