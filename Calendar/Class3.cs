using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes1
{
    using Task1;
    public class Note : Task
    {
        public DateTime CreationDate { get; set; }
        public Note(int id, string text, int priority) : base(id, text, priority)
        {
            CreationDate = CreationDate;

        }
    }
}
