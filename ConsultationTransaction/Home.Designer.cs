namespace PEDIATRICCLINICALSYSTEM
{
    partial class Home
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
            this.Consultationbutton = new System.Windows.Forms.Button();
            this.ImmunizationButton = new System.Windows.Forms.Button();
            this.PrescriptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Consultationbutton
            // 
            this.Consultationbutton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Consultationbutton.FlatAppearance.BorderSize = 4;
            this.Consultationbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Consultationbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consultationbutton.Location = new System.Drawing.Point(35, 33);
            this.Consultationbutton.Name = "Consultationbutton";
            this.Consultationbutton.Size = new System.Drawing.Size(140, 43);
            this.Consultationbutton.TabIndex = 0;
            this.Consultationbutton.Text = "Consultation";
            this.Consultationbutton.UseVisualStyleBackColor = true;
            this.Consultationbutton.Click += new System.EventHandler(this.Consultationbutton_Click);
            // 
            // ImmunizationButton
            // 
            this.ImmunizationButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.ImmunizationButton.FlatAppearance.BorderSize = 4;
            this.ImmunizationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImmunizationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImmunizationButton.Location = new System.Drawing.Point(35, 95);
            this.ImmunizationButton.Name = "ImmunizationButton";
            this.ImmunizationButton.Size = new System.Drawing.Size(140, 43);
            this.ImmunizationButton.TabIndex = 1;
            this.ImmunizationButton.Text = "Immunization";
            this.ImmunizationButton.UseVisualStyleBackColor = true;
            this.ImmunizationButton.Click += new System.EventHandler(this.ImmunizationButton_Click);
            // 
            // PrescriptionButton
            // 
            this.PrescriptionButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.PrescriptionButton.FlatAppearance.BorderSize = 4;
            this.PrescriptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrescriptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrescriptionButton.Location = new System.Drawing.Point(35, 155);
            this.PrescriptionButton.Name = "PrescriptionButton";
            this.PrescriptionButton.Size = new System.Drawing.Size(140, 43);
            this.PrescriptionButton.TabIndex = 2;
            this.PrescriptionButton.Text = "Prescription";
            this.PrescriptionButton.UseVisualStyleBackColor = true;
            this.PrescriptionButton.Click += new System.EventHandler(this.PrescriptionButton_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 278);
            this.Controls.Add(this.PrescriptionButton);
            this.Controls.Add(this.ImmunizationButton);
            this.Controls.Add(this.Consultationbutton);
            this.MaximumSize = new System.Drawing.Size(323, 317);
            this.MinimumSize = new System.Drawing.Size(323, 317);
            this.Name = "Home";
            this.Text = "Pediatric Clinical System (Home)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Consultationbutton;
        private System.Windows.Forms.Button ImmunizationButton;
        private System.Windows.Forms.Button PrescriptionButton;
    }
}