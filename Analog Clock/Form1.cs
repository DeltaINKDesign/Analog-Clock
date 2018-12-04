using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analog_Clock
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Form1 : Form
    {
       
        Vector2 LeftUpperClock; //nie zmienialne
        Vector2 CenterOfTheClock; //nie zmienialne 
        Vector2 SecondPointer;  //wektor sekund
        Vector2 MinutePointer;  //wektor minuty
        Vector2 HourPointer;  //wektor godziny
        Graphics g;  //inicjujemy korzystanie z grafiki 
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Red;  //ustawia kolor tła
            
            
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime teraz = DateTime.Now;  //wskazowka sekundy
            g.DrawLine(new Pen(Color.Red, 2), CenterOfTheClock.x, CenterOfTheClock.y, SecondPointer.x, SecondPointer.y);
            g.DrawLine(new Pen(Color.Red, 2), CenterOfTheClock.x, CenterOfTheClock.y, MinutePointer.x, MinutePointer.y);
            g.DrawLine(new Pen(Color.Red, 2), CenterOfTheClock.x, CenterOfTheClock.y, HourPointer.x, HourPointer.y);

            SecondPointer.x = CenterOfTheClock.x + (int)(140 * Math.Sin(Math.PI * teraz.Second *6/ 180));
            SecondPointer.y = CenterOfTheClock.x - (int)(140 * Math.Cos(Math.PI * teraz.Second *6/ 180));
            g.DrawLine(new Pen(Color.White, 2), CenterOfTheClock.x, CenterOfTheClock.y, SecondPointer.x, SecondPointer.y);

            MinutePointer.x = CenterOfTheClock.x + (int)(100 * Math.Sin(Math.PI * teraz.Minute * 6 / 180));
            MinutePointer.y = CenterOfTheClock.x - (int)(100 * Math.Cos(Math.PI * teraz.Minute * 6 / 180));
            g.DrawLine(new Pen(Color.Blue, 2), CenterOfTheClock.x, CenterOfTheClock.y, MinutePointer.x, MinutePointer.y);

            HourPointer.x = CenterOfTheClock.x + (int)(40 * Math.Sin(Math.PI * teraz.Hour * 30 / 180));
            HourPointer.y = CenterOfTheClock.x - (int)(40 * Math.Cos(Math.PI * teraz.Hour * 30 / 180));
            g.DrawLine(new Pen(Color.Orange, 2), CenterOfTheClock.x, CenterOfTheClock.y, HourPointer.x, HourPointer.y);

            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new Point(238, 105));


        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            CenterOfTheClock = new Vector2(250, 250);
            LeftUpperClock = new Vector2(200 / 2, 200 / 2);
            g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Color.White, 2), LeftUpperClock.x, LeftUpperClock.y, 300, 300);
            g.DrawEllipse(new Pen(Color.White, 2), LeftUpperClock.x, LeftUpperClock.y, 300, 300);
            for (int i = 0; i < 12; i++)
            {
                Label time = new Label();
                time.Height = 300;
                time.Width = 250;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
