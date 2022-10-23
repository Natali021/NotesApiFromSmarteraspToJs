using Dapper.Contrib.Extensions;
using HW2_NotesApiWebApplication.Models;
using HW2_NotesApiWebApplication.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HW2_NotesApiWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class NoteController : ControllerBase
    {
        NoteRepo noteRepo = new NoteRepo();


        [HttpGet(Name = "GetNotes")]
        public IEnumerable<Note> GetNotes()
        {
            NoteRepo noteRepo2 = new NoteRepo();
            return noteRepo2.GetNotes();
        }

        

        [HttpGet("{id}")]
        public Note? GetNoteById(int id)
        {            
            return noteRepo.GetNoteById(id);
        }

        

        [HttpDelete("NoteWihtToken")]
        public bool DeleteNoteWihtToken(int id, string token)
        {            
            return noteRepo.DeleteNoteWihtToken(id, token);
        }

        [HttpPut]
        public string PutAddNote(Note note, string token)
        {            
            return noteRepo.PutAddNote(note, token);
        }


        
        [HttpDelete("NoteWihtTokenToArh")]
        public bool DeleteNoteWihtTokenToArh(int idN, string token)
        {            
            return noteRepo.DeleteNoteWihtTokenToArh(idN, token);
        }


        

    }
}
