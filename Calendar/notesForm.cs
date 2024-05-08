
using Calendar;
using Notes1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{

    public partial class notesForm : Form
    {
        private TextBox text = new TextBox();
        private List<Notes> notesList = new List<Notes>();
        private Notes notes = new Notes("");

        public notesForm()
        {
            InitializeComponent();
            createNotes();
            //notesList.Add(notes);
        }
        private void createNotes()
        {
            text.Multiline = true;
            text.Dock = DockStyle.Fill;
            text.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            notes.text = text.Text;
            Notes newNote = new Notes(notes.text);
            notesList.Add(newNote);
            MessageBox.Show("Notes saved successfully: " + notes.text);
            //this.Close();
        }

        private void SaveToTextFile()
        {
        using(StreamWriter writetext = new StreamWriter("notes.txt"))
            {
                foreach (var note in notesList)
                {
                    writetext.WriteLine(note.text);
                }
            }
        }

        private void ReadFromTextFile()
        {
            string text = File.ReadAllText("notes.txt");
            MessageBox.Show(text);
        }
        private void LoadNotesFromFile()
        {
            string path = "notes.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    notesList.Add(new Notes(line));
                }
            }
        }

        private void clearNotes()
        {
            string path = "notes.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    notesList.Clear();
                }
            }
        }

        private void notesForm_Load(object sender, EventArgs e)
        {
            LoadNotesFromFile();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            SaveToTextFile();
            ReadFromTextFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearNotes();
        }
    }
}
