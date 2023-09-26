using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        [Indexed]
        public int NotebookId { get; set; }
        public string NoteTitle { get; set; }
        public DateTime NoteCreatedAt { get; set; }
        public DateTime NoteUpdatedAt { get; set; }
        public string NoteFileLocation { get; set; }
    }
}
