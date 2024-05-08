using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Task
    {
        private int id;
        private string title;
        private int priority;
        private string text;

        public Task(int id, string title, int priority, string text)
        {
            this.id = id;
            this.title = title;
            this.priority = priority;
            this.text = text;
        }
        
    }
       
}
