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
            this.BackColor = Color.Black;  //ustawia kolor tła
            
            
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime teraz = DateTime.Now;  //wskazowka sekundy
            g.DrawLine(new Pen(Color.Black, 2), CenterOfTheClock.x, CenterOfTheClock.y, SecondPointer.x, SecondPointer.y);
            g.DrawLine(new Pen(Color.Black, 2), CenterOfTheClock.x, CenterOfTheClock.y, MinutePointer.x, MinutePointer.y);
            g.DrawLine(new Pen(Color.Black, 2), CenterOfTheClock.x, CenterOfTheClock.y, HourPointer.x, HourPointer.y);

            SecondPointer.x = CenterOfTheClock.x + (int)(140 * Math.Sin(Math.PI * teraz.Second *6/ 180));
            SecondPointer.y = CenterOfTheClock.x - (int)(140 * Math.Cos(Math.PI * teraz.Second *6/ 180));
            g.DrawLine(new Pen(Color.IndianRed, 2), CenterOfTheClock.x, CenterOfTheClock.y, SecondPointer.x, SecondPointer.y);

            MinutePointer.x = CenterOfTheClock.x + (int)(100 * Math.Sin(Math.PI * teraz.Minute * 6 / 180));
            MinutePointer.y = CenterOfTheClock.x - (int)(100 * Math.Cos(Math.PI * teraz.Minute * 6 / 180));
            g.DrawLine(new Pen(Color.AliceBlue, 2), CenterOfTheClock.x, CenterOfTheClock.y, MinutePointer.x, MinutePointer.y);

            HourPointer.x = CenterOfTheClock.x + (int)(40 * Math.Sin(Math.PI * teraz.Hour * 30 / 180));
            HourPointer.y = CenterOfTheClock.x - (int)(40 * Math.Cos(Math.PI * teraz.Hour * 30 / 180));
            g.DrawLine(new Pen(Color.Orange, 2), CenterOfTheClock.x, CenterOfTheClock.y, HourPointer.x, HourPointer.y);

            g.DrawString("12", new Font("Times New Roman", 12), Brushes.White, new Point(238, 105));  //poziom, pion
            g.DrawString("3", new Font("Times New Roman", 12), Brushes.White, new Point(380, 240));
            g.DrawString("6", new Font("Times New Roman", 12), Brushes.White, new Point(242, 375));
            g.DrawString("9", new Font("Times New Roman", 12), Brushes.White, new Point(105, 240));

            g.DrawString("1", new Font("Times New Roman", 12), Brushes.White, new Point(310, 125));
            g.DrawString("2", new Font("Times New Roman", 12), Brushes.White, new Point(355, 175));

            g.DrawString("4", new Font("Times New Roman", 12), Brushes.White, new Point(355, 305));
            g.DrawString("5", new Font("Times New Roman", 12), Brushes.White, new Point(307, 352));

            g.DrawString("7", new Font("Times New Roman", 12), Brushes.White, new Point(179, 355));
            g.DrawString("8", new Font("Times New Roman", 12), Brushes.White, new Point(132, 307));

            g.DrawString("10", new Font("Times New Roman", 12), Brushes.White, new Point(129, 175));
            g.DrawString("11", new Font("Times New Roman", 12), Brushes.White, new Point(172, 125));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            CenterOfTheClock = new Vector2(250, 250);
            LeftUpperClock = new Vector2(200 / 2, 200 / 2);
            g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Color.White, 2), LeftUpperClock.x, LeftUpperClock.y, 300, 300);
            g.DrawEllipse(new Pen(Color.White, 2), LeftUpperClock.x, LeftUpperClock.y, 300, 300);
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
