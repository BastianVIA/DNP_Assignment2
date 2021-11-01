using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A1.Data;
using A1.Networking;

namespace A1.Models.Impl
{
    public class UserService : IUserService {
        private List<User> users;
        private IClient _client = new Client();

        public UserService() {
            users = _client.GetUsers().Result;
        }
        
        public User ValidateUser(string userName, string password) {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}