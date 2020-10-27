using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Token.Models;

namespace Token.Srvices
{
    //Repository Interface
    public interface IUserRepository:IDisposable
    {
        List<User> GetUsers();
        User GetUserMyUserName(string username);
        bool AddUser(User user);
        void Save();
    }
}
