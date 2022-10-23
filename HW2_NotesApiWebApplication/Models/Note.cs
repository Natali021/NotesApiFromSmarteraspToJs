//Разместить api с прошлого дз на хостинге
//и через JS вывести результаты в карточки с любого endPoint

namespace HW2_NotesApiWebApplication.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string? Header { get; set; }        
        public string? Text { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int UsersId { get; set; }

        
    }
}
