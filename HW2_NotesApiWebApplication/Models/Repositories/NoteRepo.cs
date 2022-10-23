using System.Data.SqlClient;
using System.Data;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HW2_NotesApiWebApplication.Models.Repositories
{
    public class NoteRepo
    {
        //string connectionString = "Data Source=DESKTOP-A858QMV\\SQLEXPRESS; Initial Catalog=HW2_ASPnet_Notes;  Integrated Security=SSPI;";
        string connectionString = "Data Source=SQL5104.site4now.net;Initial Catalog=db_a8e969_tasha021db;User Id=db_a8e969_tasha021db_admin;Password=123456Zero;";


        //отримуємо токен із idNote
        public string? GetTokenByIdNote(int idNote)
        {
            string? token = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                Note note = db.Get<Note>(idNote);//метод Dapper.Contrib
                User user = db.Get<User>(note.UsersId);//метод Dapper.Contrib
                token = user.Token;
            }

            return token;
        }

        //отримуємо IdUser із токена
        public int GetIdUserByToken(string token)
        {
            int IdUser = 0;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                IEnumerable<User> usersList = db.GetAll<User>();
                
                foreach(User us in usersList)
                {
                    if (us.Token == token)
                    {
                        IdUser = us.Id;
                    }
                }                 
            }
            return IdUser;
        }

        public IEnumerable<Note> GetNotes()
        {
            IEnumerable<Note>? notes = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                notes = db.GetAll<Note>();//метод Dapper.Contrib
            }
            return notes;
        }

                
        public Note? GetNoteById(int id)
        {
            Note? note = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                note = db.Get<Note>(id);//метод Dapper.Contrib
            }
            return note;
        }

                
        public bool DeleteNoteWihtToken(int id, string token)
        {
            bool res = false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                Note note = db.Get<Note>(id);//метод Dapper.Contrib
                User user = db.Get<User>(note.UsersId);//метод Dapper.Contrib
                if (user.Token == token)
                {
                    res = db.Delete<Note>(note);//метод Dapper.Contrib
                }
            }
            return res;
        }

        
        public string PutAddNote(Note note, string token)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (note.UsersId == GetIdUserByToken(token))
                {
                    db.Insert(note); //метод Dapper.Contrib
                    return "Ok";
                }
            }
            return "Ви намагаєтеся ввести замітку під чужим Id або токен не вірний";
        }



        public bool DeleteNoteWihtTokenToArh(int idN, string token)
        {
            bool res = false;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                Note note = db.Get<Note>(idN);//замітка по id
                User user = db.Get<User>(note.UsersId);//user по UsersId
                ArhiveNote arhiveNote = new ArhiveNote(note);
                if (user.Token == token)
                {
                    db.Insert(arhiveNote);//метод Dapper.Contrib
                    res = db.Delete<Note>(note);//метод Dapper.Contrib
                }
            }
            return res;
        }



    }
}
