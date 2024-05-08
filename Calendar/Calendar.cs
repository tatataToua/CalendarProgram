using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
    
{
    using System.Security.Cryptography;
    using Task1;
    using Event1;
    using Notes1;
    using System.Drawing.Text;

    public class Calendar
    {
        private List<Task> tasks;
        private List<Event> events;
        private List<Notes> notes;

        public Calendar() {
            tasks = new List<Task>();
            events = new List<Event>();
            notes = new List<Notes>();
        }

        // task operations
        public void addTask(Task calTasks)
        {
            tasks.Add(calTasks);
        }
        public void removeTask(Task calTask) { 
            tasks.Remove(calTask);
        }

        // event operations
        public void addEvent(Event calEvent) { 
            events.Add(calEvent);
        }
        public void removeEvent(Event calEvent) {
            events.Remove(calEvent);
        }

        // notes operations
        public void addNotes(Notes calNotes)
        {
            notes.Add(calNotes);
        }
        public void removeNotes(Notes calNotes)
        {
            notes.Remove(calNotes);
        }

    }
}
