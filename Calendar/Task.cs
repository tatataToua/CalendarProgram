using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Tasks
    {
        public string title;
        public string priority;
        public string text;

        public Tasks(string title, string text, string priority)
        {
            this.title = title;
            this.text = text;
            this.priority = priority;
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Priority { get; set; }

    }    
       
}
