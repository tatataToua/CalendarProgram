using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes1
{
    public class Notes
    {
        public string text;

        public Notes(string text)
        {
            this.text = text;
        }
        public string Text { get; set; }
    }

}
