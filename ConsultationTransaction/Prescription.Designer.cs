namespace PEDIATRICCLINICALSYSTEM
{
    partial class Prescription
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DescriptionNoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConsultationNoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PrescriptionDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AgeTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PatientNameTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.PatientCodeTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrescriptiondataGridView = new System.Windows.Forms.DataGridView();
            this.RemarksTextBox = new System.Windows.Forms.TextBox();
            this.MedQuantityTextBox = new System.Windows.Forms.TextBox();
            this.MedicineCodeTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PreparedByTextBoxReadOnly = new System.Windows.Forms.TextBox();
            this.PreparedByTextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.medcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mdname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mdose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mrmrks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrescriptiondataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "PRESCRIPTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CEBU GENERAL HOSPITAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PEDIATRIC MEDICAL SYSTEM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prescription No.";
            // 
            // DescriptionNoTextBox
            // 
            this.DescriptionNoTextBox.Location = new System.Drawing.Point(103, 74);
            this.DescriptionNoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionNoTextBox.Name = "DescriptionNoTextBox";
            this.DescriptionNoTextBox.Size = new System.Drawing.Size(62, 20);
            this.DescriptionNoTextBox.TabIndex = 13;
            this.DescriptionNoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescriptionNoTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Consultation No.";
            // 
            // ConsultationNoTextBox
            // 
            this.ConsultationNoTextBox.Location = new System.Drawing.Point(362, 74);
            this.ConsultationNoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ConsultationNoTextBox.Name = "ConsultationNoTextBox";
            this.ConsultationNoTextBox.Size = new System.Drawing.Size(62, 20);
            this.ConsultationNoTextBox.TabIndex = 15;
            this.ConsultationNoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsultationNoTextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Date";
            // 
            // PrescriptionDate
            // 
            this.PrescriptionDate.Location = new System.Drawing.Point(542, 74);
            this.PrescriptionDate.Margin = new System.Windows.Forms.Padding(2);
            this.PrescriptionDate.Name = "PrescriptionDate";
            this.PrescriptionDate.Size = new System.Drawing.Size(201, 20);
            this.PrescriptionDate.TabIndex = 17;
            this.PrescriptionDate.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AgeTextBoxReadOnly);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.PatientNameTextBoxReadOnly);
            this.groupBox1.Controls.Add(this.PatientCodeTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(14, 127);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(394, 139);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Info";
            // 
            // AgeTextBoxReadOnly
            // 
            this.AgeTextBoxReadOnly.Location = new System.Drawing.Point(104, 84);
            this.AgeTextBoxReadOnly.Margin = new System.Windows.Forms.Padding(2);
            this.AgeTextBoxReadOnly.Name = "AgeTextBoxReadOnly";
            this.AgeTextBoxReadOnly.ReadOnly = true;
            this.AgeTextBoxReadOnly.Size = new System.Drawing.Size(50, 20);
            this.AgeTextBoxReadOnly.TabIndex = 23;
            this.AgeTextBoxReadOnly.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(58, 87);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Age";
            // 
            // PatientNameTextBoxReadOnly
            // 
            this.PatientNameTextBoxReadOnly.Location = new System.Drawing.Point(104, 54);
            this.PatientNameTextBoxReadOnly.Margin = new System.Windows.Forms.Padding(2);
            this.PatientNameTextBoxReadOnly.Name = "PatientNameTextBoxReadOnly";
            this.PatientNameTextBoxReadOnly.ReadOnly = true;
            this.PatientNameTextBoxReadOnly.Size = new System.Drawing.Size(186, 20);
            this.PatientNameTextBoxReadOnly.TabIndex = 17;
            this.PatientNameTextBoxReadOnly.TabStop = false;
            // 
            // PatientCodeTextBox
            // 
            this.PatientCodeTextBox.Location = new System.Drawing.Point(104, 27);
            this.PatientCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PatientCodeTextBox.Name = "PatientCodeTextBox";
            this.PatientCodeTextBox.Size = new System.Drawing.Size(95, 20);
            this.PatientCodeTextBox.TabIndex = 16;
            this.PatientCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatientCodeTextBox_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Patient Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Patient Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PrescriptiondataGridView);
            this.groupBox2.Controls.Add(this.RemarksTextBox);
            this.groupBox2.Controls.Add(this.MedQuantityTextBox);
            this.groupBox2.Controls.Add(this.MedicineCodeTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(18, 298);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(744, 279);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Medicine to Prescribe";
            // 
            // PrescriptiondataGridView
            // 
            this.PrescriptiondataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PrescriptiondataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.PrescriptiondataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrescriptiondataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medcod,
            this.mdname,
            this.mdose,
            this.mdesc,
            this.mqty,
            this.mrmrks});
            this.PrescriptiondataGridView.Location = new System.Drawing.Point(14, 121);
            this.PrescriptiondataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.PrescriptiondataGridView.Name = "PrescriptiondataGridView";
            this.PrescriptiondataGridView.RowTemplate.Height = 24;
            this.PrescriptiondataGridView.Size = new System.Drawing.Size(711, 137);
            this.PrescriptiondataGridView.TabIndex = 29;
            this.PrescriptiondataGridView.TabStop = false;
            // 
            // RemarksTextBox
            // 
            this.RemarksTextBox.Location = new System.Drawing.Point(107, 89);
            this.RemarksTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RemarksTextBox.Name = "RemarksTextBox";
            this.RemarksTextBox.Size = new System.Drawing.Size(534, 20);
            this.RemarksTextBox.TabIndex = 28;
            this.RemarksTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RemarksTextBox_KeyPress);
            // 
            // MedQuantityTextBox
            // 
            this.MedQuantityTextBox.Location = new System.Drawing.Point(107, 58);
            this.MedQuantityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MedQuantityTextBox.Name = "MedQuantityTextBox";
            this.MedQuantityTextBox.Size = new System.Drawing.Size(54, 20);
            this.MedQuantityTextBox.TabIndex = 27;
            this.MedQuantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MedQuantityTextBox_KeyPress);
            // 
            // MedicineCodeTextBox
            // 
            this.MedicineCodeTextBox.Location = new System.Drawing.Point(107, 28);
            this.MedicineCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MedicineCodeTextBox.Name = "MedicineCodeTextBox";
            this.MedicineCodeTextBox.Size = new System.Drawing.Size(95, 20);
            this.MedicineCodeTextBox.TabIndex = 26;
            this.MedicineCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MedicineCodeTextBox_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 89);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Remarks";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Medicine Code";
            // 
            // PreparedByTextBoxReadOnly
            // 
            this.PreparedByTextBoxReadOnly.Location = new System.Drawing.Point(216, 632);
            this.PreparedByTextBoxReadOnly.Margin = new System.Windows.Forms.Padding(2);
            this.PreparedByTextBoxReadOnly.Name = "PreparedByTextBoxReadOnly";
            this.PreparedByTextBoxReadOnly.ReadOnly = true;
            this.PreparedByTextBoxReadOnly.Size = new System.Drawing.Size(146, 20);
            this.PreparedByTextBoxReadOnly.TabIndex = 28;
            // 
            // PreparedByTextBox
            // 
            this.PreparedByTextBox.Location = new System.Drawing.Point(118, 632);
            this.PreparedByTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PreparedByTextBox.Name = "PreparedByTextBox";
            this.PreparedByTextBox.Size = new System.Drawing.Size(95, 20);
            this.PreparedByTextBox.TabIndex = 27;
            this.PreparedByTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreparedByTextBox_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(39, 635);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 26;
            this.label26.Text = "Prepared By";
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Location = new System.Drawing.Point(630, 644);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(83, 31);
            this.ExitButton.TabIndex = 32;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearButton.Location = new System.Drawing.Point(630, 606);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(83, 31);
            this.ClearButton.TabIndex = 31;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Location = new System.Drawing.Point(507, 606);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(83, 31);
            this.SaveButton.TabIndex = 30;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // medcod
            // 
            this.medcod.FillWeight = 56.91719F;
            this.medcod.HeaderText = "MEDICINE CODE";
            this.medcod.Name = "medcod";
            // 
            // mdname
            // 
            this.mdname.FillWeight = 157.669F;
            this.mdname.HeaderText = "MEDICINE NAME";
            this.mdname.Name = "mdname";
            this.mdname.ReadOnly = true;
            // 
            // mdose
            // 
            this.mdose.FillWeight = 63.15226F;
            this.mdose.HeaderText = "DOSE";
            this.mdose.Name = "mdose";
            this.mdose.ReadOnly = true;
            // 
            // mdesc
            // 
            this.mdesc.FillWeight = 102.9409F;
            this.mdesc.HeaderText = "DESCRIPTION";
            this.mdesc.Name = "mdesc";
            this.mdesc.ReadOnly = true;
            // 
            // mqty
            // 
            this.mqty.FillWeight = 36.57952F;
            this.mqty.HeaderText = "QTY";
            this.mqty.Name = "mqty";
            this.mqty.ReadOnly = true;
            // 
            // mrmrks
            // 
            this.mrmrks.FillWeight = 182.7411F;
            this.mrmrks.HeaderText = "REMARKS";
            this.mrmrks.Name = "mrmrks";
            this.mrmrks.ReadOnly = true;
            // 
            // Prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 685);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PreparedByTextBoxReadOnly);
            this.Controls.Add(this.PreparedByTextBox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PrescriptionDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ConsultationNoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DescriptionNoTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(795, 724);
            this.MinimumSize = new System.Drawing.Size(795, 724);
            this.Name = "Prescription";
            this.Text = "Prescription";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrescriptiondataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DescriptionNoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ConsultationNoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker PrescriptionDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PatientNameTextBoxReadOnly;
        private System.Windows.Forms.TextBox PatientCodeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AgeTextBoxReadOnly;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView PrescriptiondataGridView;
        private System.Windows.Forms.TextBox RemarksTextBox;
        private System.Windows.Forms.TextBox MedQuantityTextBox;
        private System.Windows.Forms.TextBox MedicineCodeTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PreparedByTextBoxReadOnly;
        private System.Windows.Forms.TextBox PreparedByTextBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn medcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn mdname;
        private System.Windows.Forms.DataGridViewTextBoxColumn mdose;
        private System.Windows.Forms.DataGridViewTextBoxColumn mdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn mqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn mrmrks;
    }
}