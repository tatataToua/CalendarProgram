using System;
using Event1;
using Calendar;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Task1;
using System.IO;

namespace Calendar
{
    public partial class eventsForm : Form
    {
        private TextBox text1 = new TextBox();
        private TextBox text2 = new TextBox();
        private TextBox text3 = new TextBox();
        private TextBox text4 = new TextBox();
        private Event newEvent = new Event("", "", "", "");
        private List<Event> eventList = new List<Event>();
        private TextBox eventTextBox = new TextBox();


        private TextBox text = new TextBox();

        public eventsForm()
        {
            InitializeComponent();
            createBoxes(300, 115, text1);
            createBoxes(300, 165, text2);
            createBoxes(300, 215, text3);
            createBoxes(300, 265, text4);
            createEventBoxes(600, 200);
        }
        private void createEventBoxes(int x, int y)
        {
            eventTextBox.Multiline = true;
            eventTextBox.ScrollBars = ScrollBars.Vertical;
            eventTextBox.Size = new Size(200, 190);
            eventTextBox.Location = new Point(x, y);
            this.Controls.Add(eventTextBox);
        }
        private void createBoxes(int x, int y, TextBox textbox)
        {
            textbox.Size = new Size(200, 200);
            textbox.Location = new Point(x, y);
            this.Controls.Add(textbox);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newEvent.title = text1.Text;
            newEvent.text = text2.Text;
            newEvent.priority = text3.Text;
            newEvent.time = text4.Text;


            Event latestEvent = new Event(newEvent.title, newEvent.text, newEvent.priority, newEvent.time);
            eventList.Add(latestEvent);
            UpdateEventDisplay();
            //this.Close();
        }

        private void UpdateEventDisplay()
        {
            // Clear existing text
            eventTextBox.Clear();

            // Update text with all tasks
            foreach (var events in eventList)
            {
                eventTextBox.AppendText($"Title: {events.title}\r\n");
                eventTextBox.AppendText($"Text: {events.text}\r\n");
                eventTextBox.AppendText($"Priority: {events.priority}\r\n");
                eventTextBox.AppendText($"Time: {events.time}\r\n\r\n");

            }
        }
        private void SaveToEventFile()
        {
            using (StreamWriter writetext = new StreamWriter("event.txt"))
            {
                foreach (var anyEvent in eventList)
                {
                    writetext.WriteLine($"{anyEvent.title},{anyEvent.text},{anyEvent.priority},{anyEvent.time}");
                }
            }
        }

        private void ReadFromEventFile()
        {
            string path = "event.txt";
            if (File.Exists(path))
            {
                eventTextBox.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 4)
                    {
                        eventTextBox.AppendText($"Task: {parts[0]}\r\n");
                        eventTextBox.AppendText($"Text: {parts[1]}\r\n");
                        eventTextBox.AppendText($"Priority: {parts[2]}\r\n");
                        eventTextBox.AppendText($"Time: {parts[3]}\r\n\r\n");

                    }
                    else
                    {
                        Console.WriteLine("Invalid line format: " + line);
                    }
                }
            }
        }
        private void clearEvent()
        {
            eventList.Clear();
            eventTextBox.Clear();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearEvent();
        }
        private void eventsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToEventFile();
        }

        private void eventsForm_Load(object sender, EventArgs e)
        {
            ReadFromEventFile();
        }
    }
}
