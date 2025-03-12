namespace KaloriaCalculator
{
    partial class Calculator
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
            this.listBoxSzoveg = new System.Windows.Forms.ListBox();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGoalWeight = new System.Windows.Forms.TextBox();
            this.textBoxWorkoutsPerWeek = new System.Windows.Forms.TextBox();
            this.textBoxCaloriesIntake = new System.Windows.Forms.TextBox();
            this.textBoxAlvas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOszKaloria = new System.Windows.Forms.TextBox();
            this.textBoxBiciklizes = new System.Windows.Forms.TextBox();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.Duration = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSzoveg
            // 
            this.listBoxSzoveg.FormattingEnabled = true;
            this.listBoxSzoveg.Location = new System.Drawing.Point(9, 12);
            this.listBoxSzoveg.Name = "listBoxSzoveg";
            this.listBoxSzoveg.Size = new System.Drawing.Size(367, 69);
            this.listBoxSzoveg.TabIndex = 0;
            // 
            // btnCalculator
            // 
            this.btnCalculator.Location = new System.Drawing.Point(9, 294);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(367, 23);
            this.btnCalculator.TabIndex = 1;
            this.btnCalculator.Text = "Calculator";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(9, 323);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(367, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(135, 87);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(241, 20);
            this.textBoxWeight.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Összes elégetett kalória:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Leadási súly:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Étel mennyiség:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alvás:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Heti edzés:";
            // 
            // textBoxGoalWeight
            // 
            this.textBoxGoalWeight.Location = new System.Drawing.Point(135, 113);
            this.textBoxGoalWeight.Name = "textBoxGoalWeight";
            this.textBoxGoalWeight.Size = new System.Drawing.Size(241, 20);
            this.textBoxGoalWeight.TabIndex = 9;
            // 
            // textBoxWorkoutsPerWeek
            // 
            this.textBoxWorkoutsPerWeek.Location = new System.Drawing.Point(135, 139);
            this.textBoxWorkoutsPerWeek.Name = "textBoxWorkoutsPerWeek";
            this.textBoxWorkoutsPerWeek.Size = new System.Drawing.Size(241, 20);
            this.textBoxWorkoutsPerWeek.TabIndex = 10;
            // 
            // textBoxCaloriesIntake
            // 
            this.textBoxCaloriesIntake.Location = new System.Drawing.Point(135, 165);
            this.textBoxCaloriesIntake.Name = "textBoxCaloriesIntake";
            this.textBoxCaloriesIntake.Size = new System.Drawing.Size(241, 20);
            this.textBoxCaloriesIntake.TabIndex = 11;
            // 
            // textBoxAlvas
            // 
            this.textBoxAlvas.Location = new System.Drawing.Point(135, 216);
            this.textBoxAlvas.Name = "textBoxAlvas";
            this.textBoxAlvas.Size = new System.Drawing.Size(241, 20);
            this.textBoxAlvas.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Súly:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Biciklizés:";
            // 
            // textBoxOszKaloria
            // 
            this.textBoxOszKaloria.Location = new System.Drawing.Point(134, 268);
            this.textBoxOszKaloria.Name = "textBoxOszKaloria";
            this.textBoxOszKaloria.Size = new System.Drawing.Size(242, 20);
            this.textBoxOszKaloria.TabIndex = 15;
            // 
            // textBoxBiciklizes
            // 
            this.textBoxBiciklizes.Location = new System.Drawing.Point(134, 242);
            this.textBoxBiciklizes.Name = "textBoxBiciklizes";
            this.textBoxBiciklizes.Size = new System.Drawing.Size(242, 20);
            this.textBoxBiciklizes.TabIndex = 16;
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(135, 191);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(241, 20);
            this.textBoxDuration.TabIndex = 17;
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Location = new System.Drawing.Point(6, 197);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(50, 13);
            this.Duration.TabIndex = 18;
            this.Duration.Text = "Duration:";
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 360);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.textBoxBiciklizes);
            this.Controls.Add(this.textBoxOszKaloria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAlvas);
            this.Controls.Add(this.textBoxCaloriesIntake);
            this.Controls.Add(this.textBoxWorkoutsPerWeek);
            this.Controls.Add(this.textBoxGoalWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCalculator);
            this.Controls.Add(this.listBoxSzoveg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSzoveg;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGoalWeight;
        private System.Windows.Forms.TextBox textBoxWorkoutsPerWeek;
        private System.Windows.Forms.TextBox textBoxCaloriesIntake;
        private System.Windows.Forms.TextBox textBoxAlvas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOszKaloria;
        private System.Windows.Forms.TextBox textBoxBiciklizes;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label Duration;
    }
}

