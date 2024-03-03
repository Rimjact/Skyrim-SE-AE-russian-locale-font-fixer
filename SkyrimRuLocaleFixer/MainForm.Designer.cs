namespace SkyrimRuLocaleFixer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FixButton = new System.Windows.Forms.Button();
            this.BackToDefaultButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FixButton
            // 
            this.FixButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FixButton.Location = new System.Drawing.Point(12, 12);
            this.FixButton.Name = "FixButton";
            this.FixButton.Size = new System.Drawing.Size(344, 45);
            this.FixButton.TabIndex = 0;
            this.FixButton.Text = "Исправить шрифт русской локализации";
            this.FixButton.UseVisualStyleBackColor = true;
            this.FixButton.Click += new System.EventHandler(this.FixButton_Click);
            // 
            // BackToDefaultButton
            // 
            this.BackToDefaultButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackToDefaultButton.Location = new System.Drawing.Point(12, 63);
            this.BackToDefaultButton.Name = "BackToDefaultButton";
            this.BackToDefaultButton.Size = new System.Drawing.Size(344, 45);
            this.BackToDefaultButton.TabIndex = 1;
            this.BackToDefaultButton.Text = "Вернуть по умолчанию";
            this.BackToDefaultButton.UseVisualStyleBackColor = true;
            this.BackToDefaultButton.Click += new System.EventHandler(this.BackToDefaultButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 116);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(344, 71);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "v1.0 (10.02.2024) | © Rimjact, 2024";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.BackToDefaultButton);
            this.Controls.Add(this.FixButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Исправитель шрифта русской локализации Skyrim SE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FixButton;
        private System.Windows.Forms.Button BackToDefaultButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label1;
    }
}

