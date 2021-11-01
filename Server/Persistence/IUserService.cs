using System.Collections.Generic;
using Server.Data;

namespace Server.Persistence
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}