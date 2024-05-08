using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Calendar
{
    public partial class Form1 : Form
    {
        static DateTime currentDate = DateTime.Now;
        static int currentYear = DateTime.Now.Year;
        static int currentMonth = DateTime.Now.Month;
        static int currentDay = DateTime.Now.Day;

        public Form1()
        {
            InitializeComponent();
        }

        private void displayDays()
        {
            int days = DateTime.DaysInMonth(currentYear, currentMonth);

            DateTime startofthemonth = new DateTime(currentYear, currentMonth, 1);
            int daysoftheweek = (int)startofthemonth.DayOfWeek + 1;


            for (int i = 1; i < daysoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayholder.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayholder.Controls.Add(ucdays);
            }
        }

        private void displayMonth()
        {
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth);
            Month.Text = monthName + " " + currentYear;

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dayholder.Controls.Clear();

            if (currentMonth == 12)
            {
                currentMonth = 1;
                currentYear += 1;
            }
            else
            {
                currentMonth += 1;
            }
            displayDays();
            displayMonth();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayDays();
            displayMonth();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dayholder.Controls.Clear();

            if (currentMonth == 1)
            {
                currentMonth = 12;
                currentYear -= 1;
            }
            else
            {
                currentMonth -= 1;
            }
            displayDays();
            displayMonth();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TextBox text = new TextBox();
            //this.Controls.Add(text);
            //text.Size = new Size(200, 50);

            var note = new notesForm();
            note.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var events = new eventsForm();
            events.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var events = new tasksForm();
            events.Show();
        }
    }
}
