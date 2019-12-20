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

namespace MagicPredictor
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            this.Text = "Progress";
        }
       public void UpdateProgress(int i)
        {
            if (i == progressBar1.Maximum)// this logic created for fixing animation in progressBar
            {
                progressBar1.Maximum = i + 1;
                progressBar1.Value = i + 1;
                progressBar1.Maximum = i;
                this.Text = $"{i}%";
            }
            else
            {
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = i;
        }
    }
}
