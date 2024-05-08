using Calendar;
using Task1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Notes1;
using System.Reflection;
namespace Calendar
{
    public partial class tasksForm : Form
    {
        private TextBox text1 = new TextBox();
        private TextBox text2 = new TextBox();
        private TextBox text3 = new TextBox();
        private Tasks newTask = new Tasks("", "", "");
        private List<Tasks> taskList = new List<Tasks>();
        private TextBox taskTextBox = new TextBox();

        public tasksForm()
        {
            InitializeComponent();
            createBoxes(300, 105, text1);
            createBoxes(300, 170, text2);
            createBoxes(300, 235, text3);
            createTextBox(600, 200);
        }
        private void createTextBox(int x, int y)
        {
            taskTextBox.Multiline = true;
            taskTextBox.ScrollBars = ScrollBars.Vertical;
            taskTextBox.Size = new Size(200, 190);
            taskTextBox.Location = new Point(x, y); 
            this.Controls.Add(taskTextBox); 
        }

        private void createBoxes(int x, int y, TextBox textbox)
        {
            textbox.Size = new Size(200, 200);
            textbox.Location = new Point(x, y);
            this.Controls.Add(textbox);
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            newTask.title = text1.Text;
            newTask.text = text2.Text;
            newTask.priority = text3.Text;

            Tasks latestTask = new Tasks(newTask.title, newTask.text, newTask.priority);
            taskList.Add(latestTask);
            UpdateTaskDisplay();
            //this.Close();
        }

        private void UpdateTaskDisplay()
        {
            // Clear existing text
            taskTextBox.Clear();

            // Update text with all tasks
            foreach (var task in taskList)
            {
                taskTextBox.AppendText($"Task: {task.title}\r\n");
                taskTextBox.AppendText($"Text: {task.text}\r\n");
                taskTextBox.AppendText($"Priority: {task.priority}\r\n\r\n");
            }
        }

        private void SaveToTextFile()
        {
            using (StreamWriter writetext = new StreamWriter("task.txt"))
            {
                foreach (var anyTask in taskList)
                {
                    writetext.WriteLine($"{anyTask.title},{anyTask.text},{anyTask.priority}");
                }
            }
        }

        private void ReadFromTextFile()
        {
            string path = "task.txt";
            if (File.Exists(path))
            {
                taskTextBox.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        taskTextBox.AppendText($"Task: {parts[0]}\r\n");
                        taskTextBox.AppendText($"Text: {parts[1]}\r\n");
                        taskTextBox.AppendText($"Priority: {parts[2]}\r\n\r\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid line format: " + line);
                    }
                }
            }
        }

        private void clearTask()
        {
            taskList.Clear();
            taskTextBox.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearTask();
        }
        private void tasksForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            SaveToTextFile();
        }
        private void tasksForm_Load(object sender, EventArgs e)
        {
            ReadFromTextFile();
        }
    }
}
