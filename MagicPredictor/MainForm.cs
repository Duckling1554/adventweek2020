using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MagicPredictor
{
    public partial class MainForm : Form
    {
        private const string name = "MagicBall";
        private readonly string filepath = "../../../MagicPredictor/Resources/predictions.json";
        string[] predictions;
        Random random = new Random();
        int count=0;
        int length;
        public MainForm()
        {
            InitializeComponent();
           
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            this.Text = name;
            try
            {
                var data = File.ReadAllText(filepath);
                predictions = JsonConvert.DeserializeObject<string[]>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (predictions == null)
                    this.Close();
                else if (predictions.Length == 0)
                    MessageBox.Show("No predictions");
            }
        }

        //private async void PredictButton_Click(object sender, EventArgs e)
        //{
        //    Lprediction.Text = "";
        //    PredictButton.Enabled = false;
        //    var progress = new Progress();
        //    progress.Height = 100;
        //    progress.Width = 400;
        //    progress.Show();
        //    await Task.Run(() =>
        //    // new thread for coreect work progressBar
        //    // await for logic async
        //    {

        //        for (int i = 0; i <= 100; i++)
        //        {
        //            this.Invoke(new Action(() =>
        //            {
        //                progress.UpdateProgress(i);
        //            }
        //            ));

        //            Thread.Sleep(50);
        //        }
        //    });
        //    progress.Close();
        //    var index = random.Next(predictions.Length);
        //    var prediction = predictions[index];
        //    Lprediction.Text = prediction;
        //    PredictButton.Enabled = true;

        //}
       
        string text;
        private async void PredictButton_Click(object sender, EventArgs e)
        {
             count = 0;
            label1.Text = "";
            PredictButton.Enabled = false;
            var progress = new Progress();
            progress.Height = 100;
            progress.Width = 400;
            progress.Show();
            await Task.Run(() =>
            // new thread for coreect work progressBar
            // await for logic async
            {

                for (int i = 0; i <= 100; i++)
                {
                    this.Invoke(new Action(() =>
                    {
                        progress.UpdateProgress(i);
                    }
                    ));

                    Thread.Sleep(50);
                }
            });
            progress.Close();
            var index = random.Next(predictions.Length);
            var prediction = predictions[index];

            text = prediction;
            length = text.Length;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            count++;
            if (count >= length)
            {
                timer1.Stop();
                PredictButton.Enabled = true;
            }
            else
            {
                if (text != null)
                    label1.Text = text.Substring(0, count);
            }
            
        }
    }
    }

