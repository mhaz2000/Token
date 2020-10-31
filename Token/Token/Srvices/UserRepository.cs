using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Token.Context;
using Token.Models;

namespace Token.Srvices
{
    public class UserRepository : IUserRepository
    {
        private UserDataBase _dataBase = new UserDataBase();
        public bool AddUser(User user)
        {
            //checks if user has repetitive information or not.
            var res = _dataBase.Users.Where(p => p.UserName == user.UserName || p.Phone == user.Phone || p.Email == user.Email).FirstOrDefault();
            if (res is null)
            {
                _dataBase.Users.Add(user);
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }

        //get an user by its username
        public User GetUserMyUserName(string userName)
        {
            return _dataBase.Users.Where(p=>p.UserName== userName).FirstOrDefault();
        }

        //get all users
        public List<User> GetUsers()
        {
            return _dataBase.Users.ToList();
        }

        //save all changes
        public void Save()
        {
            _dataBase.SaveChanges();
        }
    }
}