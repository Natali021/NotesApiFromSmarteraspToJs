using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HW2_NotesApiWebApplication.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using HW2_NotesApiWebApplication.Models.Repositories;

namespace HW2_NotesApiWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        UserRepo userRepo = new UserRepo();

        //[HttpGet(Name = "GetUsers")]
        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {            
            return userRepo.GetUsers();
        }

        

        //[HttpPut("{AddUser}")]   //з фігурними скобками просить ввести id при виконанні
        [HttpPut]
        public string PutAddUser(User user)
        {            
            return userRepo.PutAddUser(user);
        }


        //---------------не потрібні роути-------------//
        //[HttpGet("{id}")]
        //public User? GetUsersById(int id)
        //{
        //    return userRepo.GetUsersById(id);
        //}

        //[HttpDelete("{id}")]
        //public bool DeleteUser(int id)
        //{            
        //    return userRepo.DeleteUser(id);
        //}

        //[HttpDelete("UserWihtToken")]
        //public bool DeleteUserWihtToken(int id, string token)
        //{            
        //    return userRepo.DeleteUserWihtToken(id, token);
        //}


        //---------------варіант без репозиторію------------//
        //string connectionString = "Data Source=DESKTOP-A858QMV\\SQLEXPRESS; Initial Catalog=HW2_ASPnet_Notes;  Integrated Security=SSPI;";
        //[HttpGet(Name = "GetUsers")]
        //public IEnumerable<User> GetUsers()
        //{
        //    IEnumerable<User>? users = null;
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        users = db.GetAll<User>();//метод Dapper.Contrib
        //    }
        //    return users;
        //}

        //[HttpGet("{id}")]
        //public User? GetUsersById(int id)
        //{
        //    User? user = null;
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        user = db.Get<User>(id);//метод Dapper.Contrib
        //    }
        //    return user;
        //}

        ////[HttpPut("{AddUser}")]   //з фігурними скобками просить ввести id при виконанні
        //[HttpPut]
        //public string PutAddUser(User user)
        //{            
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        db.Insert(user); //метод Dapper.Contrib
        //    }
        //    return "Ok";
        //}

        //[HttpDelete("{id}")]
        //public bool DeleteUser(int id)
        //{
        //    bool res = false;            
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {                
        //        res = db.Delete<User>(new User { Id = id });//метод Dapper.Contrib
        //    }
        //    return res;
        //}

        //[HttpDelete("UserWihtToken")]        
        //public bool DeleteUserWihtToken(int id,string token)
        //{
        //    bool res = false;            
        //    using (IDbConnection db = new SqlConnection(connectionString))
        //    {
        //        User user = db.Get<User>(id);//метод Dapper.Contrib
        //        if (user.Token == token)
        //        {
        //            res = db.Delete<User>(user);//метод Dapper.Contrib
        //        }                
        //    }
        //    return res;
        //}

    }
}
