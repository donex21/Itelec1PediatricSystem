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
    public partial class Prescription : Form
    {
        Immunization immunize = new Immunization();
        OleDbConnection con = new OleDbConnection(Immunization.connectionString);
        public Prescription()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!immunize.AllTextEmpty(this))
            {
                PrescriptionHeaderFile();
                PrescriptionDetailFile();
                MessageBox.Show("Successfully Saved!!");
                immunize.ClearAllText(this);
                PrescriptiondataGridView.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        private void PrescriptionHeaderFile()
        {
            string sql = "Select * From PRECRIPTIONHEADERFILE";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "PRECRIPTIONHEADERFILE");
            object[] colpk = new object[2];
            colpk[0] = DescriptionNoTextBox.Text;
            colpk[1] = ConsultationNoTextBox.Text;
            DataRow findrow = dataset.Tables["PRECRIPTIONHEADERFILE"].Rows.Find(colpk);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["PRECRIPTIONHEADERFILE"].NewRow();
                datarow[0] = DescriptionNoTextBox.Text;
                datarow[1] = ConsultationNoTextBox.Text;
                datarow[2] = PatientCodeTextBox.Text;
                datarow[3] = Convert.ToDateTime(PrescriptionDate.Text);
                datarow[4] = PreparedByTextBox.Text;
                datarow[5] = "OP";

                dataset.Tables["PRECRIPTIONHEADERFILE"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "PRECRIPTIONHEADERFILE");
            }
            else
            {
                MessageBox.Show("Duplicate Entry");
            }
        }

        private void PrescriptionDetailFile()
        {
            foreach (DataGridViewRow row in PrescriptiondataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string sql = "Select * From PRESCRIPTIONDETAILFILE";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "PRESCRIPTIONDETAILFILE");
                    object[] colpk = new object[2];
                    colpk[0] = DescriptionNoTextBox.Text;
                    colpk[1] = row.Cells[0].Value;
                    DataRow findrow = dataset.Tables["PRESCRIPTIONDETAILFILE"].Rows.Find(colpk);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["PRESCRIPTIONDETAILFILE"].NewRow();
                        datarow[0] = DescriptionNoTextBox.Text;
                        datarow[1] = row.Cells[0].Value;
                        datarow[2] = row.Cells[4].Value;
                        datarow[3] = row.Cells[5].Value;
                        datarow[4] = "OP";

                        dataset.Tables["PRESCRIPTIONDETAILFILE"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "PRESCRIPTIONDETAILFILE");
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
            PrescriptiondataGridView.Rows.Clear();
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

        private void DescriptionNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool unique = false;
                if (DescriptionNoTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    con.Open();
                    OleDbCommand command = con.CreateCommand();
                    command.CommandText = "SELECT PRESHCODE FROM PRECRIPTIONHEADERFILE";
                    OleDbDataReader thisreader = command.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["PRESHCODE"].ToString() == DescriptionNoTextBox.Text)
                        {
                            MessageBox.Show("Prescription Number Already in the file");
                            DescriptionNoTextBox.Clear();
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
                    command.CommandText = "SELECT PRESHCONSNO FROM PRECRIPTIONHEADERFILE";
                    OleDbDataReader thisreader = command.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["PRESHCONSNO"].ToString() == ConsultationNoTextBox.Text)
                        {
                            MessageBox.Show("Consultation Number Already in the file");
                            ConsultationNoTextBox.Clear();
                            unique = false;
                            break;
                        }
                        else
                            unique = true;
                    }
                    thisreader.Close();
                    con.Close();
                    if (unique)
                        SendKeys.Send("{TAB}");
                }
            }
        }

        private void PatientCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                if (PatientCodeTextBox.Text == "")
                {
                    PatientNameTextBoxReadOnly.Clear();
                    AgeTextBoxReadOnly.Clear();
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    con.Open();
                    OleDbCommand command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM PATIENTFILE";
                    OleDbDataReader thisreader = command.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["PATCODE"].ToString() == PatientCodeTextBox.Text)
                        {
                            if (thisreader["PATSTATUS"].ToString() != "AC")
                            {
                                found = true;
                                PatientNameTextBoxReadOnly.Text = thisreader["PATFNAME"] + " " + thisreader["PATMNAME"] + ". " + thisreader["PATLNAME"];
                                AgeTextBoxReadOnly.Text = thisreader["PATAGE"].ToString();
                                MessageBox.Show("This Patient Code is already In-active");
                                PatientNameTextBoxReadOnly.Clear();
                                AgeTextBoxReadOnly.Clear();
                            }
                            else
                            {
                                found = true;
                                PatientNameTextBoxReadOnly.Text = thisreader["PATFNAME"] + " " + thisreader["PATMNAME"] + ". " + thisreader["PATLNAME"];
                                AgeTextBoxReadOnly.Text = thisreader["PATAGE"].ToString();
                                SendKeys.Send("{TAB}");
                            }
                        }
                    }
                    thisreader.Close();
                    con.Close();
                    if (!found)
                    {
                        MessageBox.Show("Patient Code Not found");
                        PatientNameTextBoxReadOnly.Clear();
                        AgeTextBoxReadOnly.Clear();
                    }
                }
            }
        }

        string MedName = "";
        string MedCode = "";
        string Meddesc = "";
        string MedDose = "";
        private void MedicineCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool found = false;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (MedicineCodeTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    if (UniqueMedicineCode(MedicineCodeTextBox.Text))
                    {
                        con.Open();
                        OleDbCommand command = con.CreateCommand();
                        command.CommandText = "SELECT * FROM MEDICINEFILE";
                        OleDbDataReader thisreader = command.ExecuteReader();
                        while (thisreader.Read())
                        {
                            if (thisreader["MEDCODE"].ToString() == MedicineCodeTextBox.Text)
                            {
                                found = true;
                                if (thisreader["MEDSTATUS"].ToString() == "UN")
                                {
                                    MessageBox.Show("Medicine is Already Unavailable");
                                    break;
                                }
                                else
                                {
                                    MedName = thisreader["MEDNAME"].ToString();
                                    MedCode = thisreader["MEDCODE"].ToString();
                                    Meddesc = thisreader["MEDDESC"].ToString(); ;
                                    MedDose = thisreader["MEDDOSE"].ToString(); ;
                                    SendKeys.Send("{TAB}");
                                }
                            }
                        }
                        thisreader.Close();
                        con.Close();
                        if (!found)
                        {
                            MessageBox.Show("Medicine Code Not Found");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Medicine Code already in the list");
                    }
                }
            }
        }

        //UNIQUE OF MEDICINE
        private bool UniqueMedicineCode(string medCode)
        {
            if (PrescriptiondataGridView.RowCount >= 1)
            {
                foreach (DataGridViewRow row in PrescriptiondataGridView.Rows)
                {
                    if (row.Cells["medcod"].Value != null)
                    {
                        string val = row.Cells["medcod"].Value.ToString();
                        if (val.Equals(medCode))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void MedQuantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    int height = Convert.ToInt32(MedQuantityTextBox.Text);
                    SendKeys.Send("{TAB}");
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        private void RemarksTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (RemarksTextBox.Text == "" || MedQuantityTextBox.Text == "" || MedicineCodeTextBox.Text == "")
                {
                    MessageBox.Show("Pls. Complete All Details!!");
                }
                else
                {

                    PrescriptiondataGridView.Rows.Add(MedCode, MedName, MedDose, Meddesc, MedQuantityTextBox.Text, RemarksTextBox.Text);
                    RemarksTextBox.Clear();
                    MedicineCodeTextBox.Clear();
                    MedQuantityTextBox.Clear();
                    MedCode = "";
                    MedName = "";
                    MedDose = "";
                    MedDose = "";
                    SendKeys.Send("{TAB}");
                }
            }
        }
    }
}
