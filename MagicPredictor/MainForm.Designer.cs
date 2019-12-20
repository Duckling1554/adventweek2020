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
            this.PredictButton = new System.Windows.Forms.Button();
            this.Lprediction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PredictButton
            // 
            this.PredictButton.BackgroundImage = global::MagicPredictor.Properties.Resources.snowballdown;
            this.PredictButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PredictButton.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PredictButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.PredictButton.Location = new System.Drawing.Point(353, 363);
            this.PredictButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PredictButton.Name = "PredictButton";
            this.PredictButton.Size = new System.Drawing.Size(231, 51);
            this.PredictButton.TabIndex = 0;
            this.PredictButton.Text = "PREDICT";
            this.PredictButton.UseVisualStyleBackColor = true;
            this.PredictButton.Click += new System.EventHandler(this.PredictButton_Click);
            // 
            // Lprediction
            // 
            this.Lprediction.AutoSize = true;
            this.Lprediction.Location = new System.Drawing.Point(253, 178);
            this.Lprediction.Name = "Lprediction";
            this.Lprediction.Size = new System.Drawing.Size(0, 17);
            this.Lprediction.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MagicPredictor.Properties.Resources.snowball;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(817, 538);
            this.Controls.Add(this.Lprediction);
            this.Controls.Add(this.PredictButton);
            this.DoubleBuffered = true;
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
    }
}

