using System.Threading.Tasks;
using A1.Data;

namespace A1.Models
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}