using System.Collections.Generic;
using System.Linq;
using Server.Data;

namespace Server.Persistence
{
    public class UserService : IUserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new[]
            {
                new User
                {
                    Password = "admin",
                    SecurityLevel = 5,
                    UserName = "admin"
                },
                new User
                {
                    Password = "123456",
                    SecurityLevel = 3,
                    UserName = "Bastian"
                },
                new User
                {
                    Password = "123456",
                    SecurityLevel = 1,
                    UserName = "Mikkel"
                }
            }.ToList();
        }

        public List<User> GetUsers()
        {
            return _users;
        }
    }
}