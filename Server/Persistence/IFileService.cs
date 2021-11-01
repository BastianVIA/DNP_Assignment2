using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Data;

namespace Server.Persistence
{
    public interface IFileService
    {
        IList<T> ReadData<T>(string s);
        void SaveChanges(IList<Adult> adults);

    }
}