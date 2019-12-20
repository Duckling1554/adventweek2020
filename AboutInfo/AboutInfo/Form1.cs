using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AboutInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;
        int length = 0;
        string text;
        private void Form1_Load(object sender, EventArgs e)
        {
            text = Info.Text;
            length = text.Length;
            Info.Text = "";
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count ++;
            if (count >= length)
            {
                timer1.Stop();
            }
            Info.Text = text.Substring(0, count);
        }        
    }
    
}
