using System.Threading.Tasks;
using A1.Data;

namespace A1.Models
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}