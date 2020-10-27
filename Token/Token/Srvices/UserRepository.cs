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
        UserDataBase db = new UserDataBase();
        public bool AddUser(User user)
        {
            //checks if user has repetitive information or not.
            var res = db.Users.Where(p => p.UserName == user.UserName || p.Phone == user.Phone || p.Email == user.Email).FirstOrDefault();
            if (res is null)
            {
                db.Users.Add(user);
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        //get an user by its username
        public User GetUserMyUserName(string username)
        {
            return db.Users.Where(p=>p.UserName== username).FirstOrDefault();
        }

        //get all users
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        //save all changes
        public void Save()
        {
            db.SaveChanges();
        }
    }
}