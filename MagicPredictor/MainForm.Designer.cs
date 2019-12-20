namespace MagicPredictor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PredictButton = new System.Windows.Forms.Button();
            this.Lprediction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PredictButton
            // 
            this.PredictButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PredictButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PredictButton.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PredictButton.ForeColor = System.Drawing.Color.Black;
            this.PredictButton.Location = new System.Drawing.Point(326, 591);
            this.PredictButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PredictButton.Name = "PredictButton";
            this.PredictButton.Size = new System.Drawing.Size(310, 70);
            this.PredictButton.TabIndex = 0;
            this.PredictButton.Text = "predict";
            this.PredictButton.UseVisualStyleBackColor = false;
            this.PredictButton.Click += new System.EventHandler(this.PredictButton_Click);
            // 
            // Lprediction
            // 
            this.Lprediction.AutoSize = true;
            this.Lprediction.Location = new System.Drawing.Point(285, 222);
            this.Lprediction.Name = "Lprediction";
            this.Lprediction.Size = new System.Drawing.Size(0, 20);
            this.Lprediction.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 215);
            this.label1.TabIndex = 2;
            this.label1.Text = "What is yor prediction for 2020?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MagicPredictor.Properties.Resources.snowball;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(916, 834);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lprediction);
            this.Controls.Add(this.PredictButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PredictButton;
        private System.Windows.Forms.Label Lprediction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

