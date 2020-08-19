using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EyeOK
{
    public partial class Form1 : Form
    {
        private String appname = "none";
        private int period = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (IntPtr.Zero != API_RAM.FindWindow(appname))
            {
                API_RAM.setforewindow(API_RAM.FindWindow(appname));
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Dinput.KeyDown(0x1e);
            System.Threading.Thread.Sleep(1000);
            Dinput.KeyDown(0x0e);
            System.Threading.Thread.Sleep(1000);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            appname = textBox1.Text;
            label1.Text = "appname: "+textBox1.Text;
            button3.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            period = Convert.ToInt32(textBox2.Text);
            label2.Text = "period: " + textBox2.Text + " ms";
            timer1.Interval = period;
            timer2.Interval = period;
            timer3.Interval = period;
            timer4.Interval = period;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if ("start front" == button3.Text)
            {
                timer1.Enabled = true;
                button3.Text = "stop front";
            }
            else
            {
                timer1.Enabled = false;
                button3.Text = "start front";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if ("start type" == button4.Text)
            {
                timer2.Enabled = true;
                button4.Text = "stop type";
            }
            else
            {
                timer2.Enabled = false;
                button4.Text = "start type";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if ("start move" == button5.Text)
            {
                timer3.Enabled = true;
                button5.Text = "stop move";
            }
            else
            {
                timer3.Enabled = false;
                button5.Text = "start move";
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            Dinput.MouseMoveRightClick();
            System.Threading.Thread.Sleep(1000);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if ("start roll" == button6.Text)
            {
                timer4.Enabled = true;
                button6.Text = "stop roll";
            }
            else
            {
                timer4.Enabled = false;
                button6.Text = "start roll";
            }
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            Dinput.MouseRoll();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
