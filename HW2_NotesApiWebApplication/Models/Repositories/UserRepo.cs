using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Dapper.Contrib.Extensions;

namespace HW2_NotesApiWebApplication.Models.Repositories
{
    public class UserRepo
    {
        //string connectionString = "Data Source=DESKTOP-A858QMV\\SQLEXPRESS; Initial Catalog=HW2_ASPnet_Notes;  Integrated Security=SSPI;";
        string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a8e969_tasha021db;User Id=db_a8e969_tasha021db_admin;Password=123456Zero;";
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User>? users = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.GetAll<User>();//метод Dapper.Contrib
            }
            return users;
        }

        
        public User? GetUsersById(int id)
        {
            User? user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Get<User>(id);//метод Dapper.Contrib
            }
            return user;
        }

        
        public string PutAddUser(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Insert(user); //метод Dapper.Contrib
            }
            return "Ok";
        }

        
        public bool DeleteUser(int id)
        {
            bool res = false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                res = db.Delete<User>(new User { Id = id });//метод Dapper.Contrib
            }
            return res;
        }

        
        public bool DeleteUserWihtToken(int id, string token)
        {
            bool res = false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                User user = db.Get<User>(id);//метод Dapper.Contrib
                if (user.Token == token)
                {
                    res = db.Delete<User>(user);//метод Dapper.Contrib
                }
            }
            return res;
        }
    }
}
