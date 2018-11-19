namespace SimplexMethodMinMax
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfVariablesUpDown = new System.Windows.Forms.DomainUpDown();
            this.numberOfConstraintsUpDown = new System.Windows.Forms.DomainUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Оберіть кількість змінних:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Оберіть кількість обмежень:";
            // 
            // numberOfVariablesUpDown
            // 
            this.numberOfVariablesUpDown.Items.Add("2");
            this.numberOfVariablesUpDown.Items.Add("3");
            this.numberOfVariablesUpDown.Items.Add("4");
            this.numberOfVariablesUpDown.Items.Add("5");
            this.numberOfVariablesUpDown.Location = new System.Drawing.Point(190, 21);
            this.numberOfVariablesUpDown.Name = "numberOfVariablesUpDown";
            this.numberOfVariablesUpDown.Size = new System.Drawing.Size(109, 20);
            this.numberOfVariablesUpDown.TabIndex = 2;
            this.numberOfVariablesUpDown.Text = "змінні";
            // 
            // numberOfConstraintsUpDown
            // 
            this.numberOfConstraintsUpDown.Items.Add("2");
            this.numberOfConstraintsUpDown.Items.Add("3");
            this.numberOfConstraintsUpDown.Items.Add("4");
            this.numberOfConstraintsUpDown.Items.Add("5");
            this.numberOfConstraintsUpDown.Location = new System.Drawing.Point(190, 62);
            this.numberOfConstraintsUpDown.Name = "numberOfConstraintsUpDown";
            this.numberOfConstraintsUpDown.Size = new System.Drawing.Size(109, 20);
            this.numberOfConstraintsUpDown.TabIndex = 3;
            this.numberOfConstraintsUpDown.Text = "обмеження";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(104, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "max";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button2.Location = new System.Drawing.Point(180, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "min";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 135);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numberOfConstraintsUpDown);
            this.Controls.Add(this.numberOfVariablesUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "MainForm";
            this.Text = "Simplex Method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DomainUpDown numberOfVariablesUpDown;
        private System.Windows.Forms.DomainUpDown numberOfConstraintsUpDown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

