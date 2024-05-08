using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event1
{
    using Microsoft.Win32;
    using Task1;
    public class Event
    {
        public string title;
        public string priority;
        public string text;
        public string time;

        public Event(string title, string text, string priority, string time)
        {
            this.title = title;
            this.text = text;
            this.priority = priority;
            this.time = time;
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Priority { get; set; }
        public string Time { get; set; }
    }
}
