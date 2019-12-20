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
        private readonly string filepath = $"{Environment.CurrentDirectory}\\document.json";
        string[] predictions;
        Random random = new Random();
        
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

        private async void PredictButton_Click(object sender, EventArgs e)
        {
            Lprediction.Text = "";
            PredictButton.Enabled = false;
            var progress = new Progress();
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
            Lprediction.Text = prediction;
            PredictButton.Enabled = true;

        }
    }
    }

