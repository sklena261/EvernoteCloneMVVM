using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class Notebook
    {
        [PrimaryKey, AutoIncrement]
        public int NotebookId { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string NotebookName { get; set; }
    }
}
