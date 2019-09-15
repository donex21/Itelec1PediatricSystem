using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PEDIATRICCLINICALSYSTEM
{
    public partial class ConsultationTransaction : Form
    {
        Immunization immunize = new Immunization();
        OleDbConnection con = new OleDbConnection(Immunization.connectionString);

        public ConsultationTransaction()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ForAdmissionCheckBox.Text = "For \nAdmission?";
            ForLaboratoryTestCheckBox.Text = "For \nLaboratory Test?";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ((ForAdmissionCheckBox.Checked == false && ForLaboratoryTestCheckBox.Checked == false))
            {
                MessageBox.Show("Pls. Choose Reference Slip");
                return;
            }
            else if (!immunize.AllTextEmpty(this))
            {
                ConsultationHeaderFile();
                ConsultationDetailFile();
                MessageBox.Show("Successfully Saved!!");
                immunize.ClearAllText(this);
                DiagnoseDataGridView.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        private void ConsultationHeaderFile()
        {
            string sql = "Select * From CONSULTATIONHEADERFILE";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "CONSULTATIONHEADERFILE");
            DataRow findrow = dataset.Tables["CONSULTATIONHEADERFILE"].Rows.Find(ConsultationNoTextBox.Text);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["CONSULTATIONHEADERFILE"].NewRow();
                datarow[0] = ConsultationNoTextBox.Text;
                datarow[1] = ImmunizationNoTextBox.Text;
                datarow[2] = Convert.ToDateTime(ConsultationDate.Text);
                datarow[3] = PatientCodeTextBox.Text;
                datarow[4] = Convert.ToDouble(WeightTextBox.Text);
                datarow[5] = Convert.ToDouble(HeightTextBox.Text);
                datarow[6] = Convert.ToDouble(BodyTempTextBox.Text);
                datarow[8] = PreparedByTextBox.Text;
                datarow[9] = ExaminedByTextBox.Text;
                datarow[10] = "OP";

                if (ForAdmissionCheckBox.Checked && ForLaboratoryTestCheckBox.Checked)
                    datarow[7] = "BT";
                else if(ForAdmissionCheckBox.Checked && ForLaboratoryTestCheckBox.CheckState == CheckState.Unchecked)
                    datarow[7] = "AD";
                else
                    datarow[7] = "LT";

                dataset.Tables["CONSULTATIONHEADERFILE"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "CONSULTATIONHEADERFILE");
            }
            else
            {
                MessageBox.Show("Duplicate Entry");
            }
        }

        private void ConsultationDetailFile()
        {
            foreach (DataGridViewRow row in DiagnoseDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string sql = "Select * From CONSULTATIONDETAILFILE";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "CONSULTATIONDETAILFILE");
                    object[] colpk = new object[2];
                    colpk[0] = ConsultationNoTextBox.Text;
                    colpk[1] = row.Cells[0].Value;
                    DataRow findrow = dataset.Tables["CONSULTATIONDETAILFILE"].Rows.Find(colpk);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["CONSULTATIONDETAILFILE"].NewRow();
                        datarow[0] = ConsultationNoTextBox.Text;
                        datarow[1] = row.Cells[0].Value;
                        datarow[2] = row.Cells[2].Value;
                        datarow[3] = "OP";

                        dataset.Tables["CONSULTATIONDETAILFILE"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "CONSULTATIONDETAILFILE");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Entry");
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            immunize.ClearAllText(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PreparedByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                immunize.Prepared(PreparedByTextBox, PreparedByTextBoxReadOnly);
            }
        }

        private void ExaminedByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                immunize.ExaminedOrImmunized(ExaminedByTextBox, ExaminedByTextBoxReadOnly);
            }
        }

        private void PatientCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                immunize.PatientFile(PatientCodeTextBox, PatientNameTextBoxReadOnly, AddressTextBoxReadOnly,
                    TelephoneTextBoxReadOnly, FathersNameTextBoxReadOnly, MothersNameTextBoxReadOnly, GenderTextBoxReadOnly,
                    BirthdayTextBoxReadOnly, AgeTextBoxReadOnly);        
            }
        }

        private void ConsultationNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool unique = false;
                if (ConsultationNoTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    con.Open();
                    OleDbCommand command = con.CreateCommand();
                    command.CommandText = "SELECT CONHO FROM CONSULTATIONHEADERFILE";
                    OleDbDataReader thisreader = command.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["CONHO"].ToString() == ConsultationNoTextBox.Text)
                        {
                            MessageBox.Show("Consultation Number Already in the file");
                            ImmunizationNoTextBox.Clear();
                            unique = false;
                            break;
                        }
                        else
                            unique = true;
                    }
                    thisreader.Close();
                    con.Close();
                    if(unique)
                        SendKeys.Send("{TAB}");
                }
            }
        }

        private void WeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                immunize.ifValidNumber(WeightTextBox.Text); 
        }

        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                immunize.ifValidNumber(HeightTextBox.Text); 
        }

        private void BodyTempTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                immunize.ifValidNumber(BodyTempTextBox.Text); 
        }
        string diagcode = "";
        string diagName = "";
        private void DiagnosisCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool found = false;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (DiagnosisCodeTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    if (UniqueDiagnoseCode(DiagnosisCodeTextBox.Text))
                    {
                        con.Open();
                        OleDbCommand command = con.CreateCommand();
                        command.CommandText = "SELECT * FROM DIAGNOSISFILE";
                        OleDbDataReader thisreader = command.ExecuteReader();
                        while (thisreader.Read())
                        {
                            if (thisreader["DIAGCODE"].ToString() == DiagnosisCodeTextBox.Text)
                            {
                                found = true;
                                diagcode = thisreader["DIAGCODE"].ToString();
                                diagName = thisreader["DIAGNAME"].ToString();
                                SendKeys.Send("{TAB}");
                                break;
                            }
                        }
                        thisreader.Close();
                        con.Close();
                        if (!found)
                        {
                            MessageBox.Show("Diagnosis Code Not Found");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Diagnosis Code already in the list");
                    }
                }
            }
        }

        private bool UniqueDiagnoseCode(string diagcodeCode)
        {
            if (DiagnoseDataGridView.RowCount >= 1)
            {
                foreach (DataGridViewRow row in DiagnoseDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string val = row.Cells[0].Value.ToString();
                        if (val.Equals(diagcodeCode))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void PhysicianNotesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (PhysicianNotesTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    if (DiagnosisCodeTextBox.Text !=  "")
                    {
                        DiagnoseDataGridView.Rows.Add(diagcode, diagName, PhysicianNotesTextBox.Text);
                        diagcode = "";
                        diagName = "";
                        DiagnosisCodeTextBox.Clear();
                        PhysicianNotesTextBox.Clear();
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        MessageBox.Show("Pls. Complete All Details!!");
                    }

                }
            }
        }
    }
}
