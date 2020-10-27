using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Token.Models;

namespace Token.Context
{
    public class UserDataBase:DbContext
    {
        public UserDataBase()
        {

        }
        public DbSet<User> Users { get; set; }
    }
}