namespace HW2_NotesApiWebApplication.Models
{
    public class ArhiveNote
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string? Header { get; set; }
        public string? Text { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int UsersId { get; set; }

        public ArhiveNote(Note note)
        {
            NoteId = note.Id;  
            Header = note.Header;
            Text = note.Text;
            DateOfCreation = note.DateOfCreation;
            UsersId = note.UsersId;
        }
        
    }
}
