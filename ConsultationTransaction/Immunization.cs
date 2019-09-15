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
    public partial class Immunization : Form
    {
        public static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Donil Ponce\Desktop\DonilPonceItelec1\DATABASE\PEDIATRICSCLINICALSYSTEM.mdb";
        OleDbConnection con = new OleDbConnection(connectionString);

        public Immunization()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!AllTextEmpty(this))
            {
                ImmunoHeaderFile();
                ImmunoDetailFile();
                MessageBox.Show("Successfully Saved!!");
                ClearAllText(this);
                VaccinedataGridView.Rows.Clear();
            }
            else {
                MessageBox.Show("Pls. Complete All Details");
            }
        }

        //ImmunoHeADERfILE
        private void ImmunoHeaderFile()
        {
            string sql = "Select * From IMMUNIZATIONHEADERFILE";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "IMMUNIZATIONHEADERFILE");
            DataRow findrow = dataset.Tables["IMMUNIZATIONHEADERFILE"].Rows.Find(ImmunizationNoTextBox.Text);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["IMMUNIZATIONHEADERFILE"].NewRow();
                datarow[0] = ImmunizationNoTextBox.Text;
                datarow[1] = Convert.ToDateTime(immunizeDateTimePicker.Text);
                datarow[2] = PatientCodeTextBox.Text;
                datarow[3] = Convert.ToDouble(WeightTextBox.Text);
                datarow[4] = Convert.ToDouble(HeightTextBox.Text);
                datarow[5] = PreparedByTextBox.Text;
                datarow[6] = ImmunizedByTextBox.Text;
                datarow[7] = "OP";

                dataset.Tables["IMMUNIZATIONHEADERFILE"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "IMMUNIZATIONHEADERFILE");             
            }
            else
            {
                MessageBox.Show("Duplicate Entry");
            }
        }

        //ImmunoDetailFile
        private void ImmunoDetailFile()
        { 
            foreach( DataGridViewRow row in VaccinedataGridView.Rows )
            {
                if (row.Cells["vaccode"].Value != null)
                {
                    string sql = "Select * From IMMUNIZATIONDETAILFILE";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
                    OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
                    DataSet dataset = new DataSet();
                    dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dataAdapter.Fill(dataset, "IMMUNIZATIONDETAILFILE");
                    object[] colpk = new object[2];
                    colpk[0] = ImmunizationNoTextBox.Text;
                    colpk[1] = row.Cells[0].Value;
                    DataRow findrow = dataset.Tables["IMMUNIZATIONDETAILFILE"].Rows.Find(colpk);
                    if (findrow == null)
                    {
                        DataRow datarow = dataset.Tables["IMMUNIZATIONDETAILFILE"].NewRow();
                        datarow[0] = ImmunizationNoTextBox.Text;
                        datarow[1] = row.Cells[0].Value;
                        datarow[2] = row.Cells[3].Value;
                        datarow[3] = row.Cells[4].Value;
                        datarow[4] = "OP";

                        dataset.Tables["IMMUNIZATIONDETAILFILE"].Rows.Add(datarow);
                        dataAdapter.Update(dataset, "IMMUNIZATIONDETAILFILE");
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
            ClearAllText(this);
            VaccinedataGridView.Rows.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method Clear All Textbox
       public void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        //All textbox is Empty
       public bool AllTextEmpty(Control con)
       {
           foreach (Control c in con.Controls)
           {
               if (c is TextBox)
                   if (((TextBox)c).Text == "")
                       return true;
           }
           return false;
       }


        //PATIENT CODE
        private void PatientCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PatientFile(PatientCodeTextBox, PatientNameTextBoxReadOnly, AddressTextBoxReadOnly,
                    TelephoneTextBoxReadOnly, FathersNameTextBoxReadOnly, MothersNameTextBoxReadOnly, GenderTextBoxReadOnly,
                    BirthdayTextBoxReadOnly, AgeTextBoxReadOnly);
                
            }
            
        }

        //patientCode
        public void PatientFile(TextBox PatientCodeTextBox, TextBox PatientNameTextBoxReadOnly, TextBox AddressTextBoxReadOnly,
            TextBox TelephoneTextBoxReadOnly, TextBox FathersNameTextBoxReadOnly, TextBox MothersNameTextBoxReadOnly, TextBox GenderTextBoxReadOnly,
            TextBox BirthdayTextBoxReadOnly, TextBox AgeTextBoxReadOnly)
        {
            bool found = false;
            if (PatientCodeTextBox.Text == "")
            {
                //method ClearAll Patient
                ClearAllPatientFile(PatientCodeTextBox, PatientNameTextBoxReadOnly, AddressTextBoxReadOnly,
                    TelephoneTextBoxReadOnly, FathersNameTextBoxReadOnly, MothersNameTextBoxReadOnly, GenderTextBoxReadOnly,
                    BirthdayTextBoxReadOnly, AgeTextBoxReadOnly);
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
                            AddressTextBoxReadOnly.Text = thisreader["PATADDR"].ToString();
                            TelephoneTextBoxReadOnly.Text = thisreader["PATTEL"].ToString();
                            FathersNameTextBoxReadOnly.Text = thisreader["PATFATHNAME"].ToString();
                            MothersNameTextBoxReadOnly.Text = thisreader["PATMOTHNAME"].ToString();
                            GenderTextBoxReadOnly.Text = thisreader["PATGENDER"].ToString();
                            BirthdayTextBoxReadOnly.Text = String.Format("{0:MM/dd/yyyy}", thisreader["PATBDATE"]); 
                            AgeTextBoxReadOnly.Text = thisreader["PATAGE"].ToString();
                            MessageBox.Show("This Patient Code is already In-active");
                            //method ClearAll Patient
                            ClearAllPatientFile(PatientCodeTextBox, PatientNameTextBoxReadOnly, AddressTextBoxReadOnly,
                                TelephoneTextBoxReadOnly, FathersNameTextBoxReadOnly, MothersNameTextBoxReadOnly, GenderTextBoxReadOnly,
                                BirthdayTextBoxReadOnly, AgeTextBoxReadOnly);

                        }else
                        {
                            found = true;
                            PatientNameTextBoxReadOnly.Text = thisreader["PATFNAME"] + " " + thisreader["PATMNAME"] + ". " + thisreader["PATLNAME"];
                            AddressTextBoxReadOnly.Text = thisreader["PATADDR"].ToString();
                            TelephoneTextBoxReadOnly.Text = thisreader["PATTEL"].ToString();
                            FathersNameTextBoxReadOnly.Text = thisreader["PATFATHNAME"].ToString();
                            MothersNameTextBoxReadOnly.Text = thisreader["PATMOTHNAME"].ToString();
                            GenderTextBoxReadOnly.Text = thisreader["PATGENDER"].ToString();
                            BirthdayTextBoxReadOnly.Text = String.Format("{0:MM/dd/yyyy}", thisreader["PATBDATE"]); 
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
                }
            }
        }

        //method ClearAll Patient
        public void ClearAllPatientFile(TextBox PatientCodeTextBox, TextBox PatientNameTextBoxReadOnly, TextBox AddressTextBoxReadOnly,
            TextBox TelephoneTextBoxReadOnly, TextBox FathersNameTextBoxReadOnly, TextBox MothersNameTextBoxReadOnly, TextBox GenderTextBoxReadOnly,
            TextBox BirthdayTextBoxReadOnly, TextBox AgeTextBoxReadOnly)
        {
            PatientCodeTextBox.Clear();
            PatientNameTextBoxReadOnly.Clear();
            AddressTextBoxReadOnly.Clear();
            TelephoneTextBoxReadOnly.Clear();
            FathersNameTextBoxReadOnly.Clear();
            MothersNameTextBoxReadOnly.Clear();
            GenderTextBoxReadOnly.Clear();
            BirthdayTextBoxReadOnly.Clear();
            AgeTextBoxReadOnly.Clear();
        }

        private void PreparedByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                Prepared( PreparedByTextBox, PreparedByTextBoxReadOnly);
            }
        }

        //Method for Prepared BY
        public void Prepared(TextBox PreparedByTextBox, TextBox PreparedByTextBoxReadOnly)
        {
            bool found = false;
            if (PreparedByTextBox.Text == "")
            {
                PreparedByTextBoxReadOnly.Clear();
                MessageBox.Show("PLS... FILL UP");
            }
            else
            {
                con.Open();
                OleDbCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM EMPLOYEEFILE";
                OleDbDataReader thisreader = command.ExecuteReader();
                while (thisreader.Read())
                {
                    if (thisreader["EMPCODE"].ToString() == PreparedByTextBox.Text)
                    {
                        if (thisreader["EMPSTATUS"].ToString() == "IN")
                        {
                            found = true;
                            PreparedByTextBoxReadOnly.Text = thisreader["EMPFNAME"] + " " + thisreader["EMPMNAME"] + ". " + thisreader["EMPLNAME"];
                            MessageBox.Show("Employee is already In-Active");
                            PreparedByTextBoxReadOnly.Clear();
                        }
                        else
                        {
                            found = true;
                            PreparedByTextBoxReadOnly.Text = thisreader["EMPFNAME"] + " " + thisreader["EMPMNAME"] + ". " + thisreader["EMPLNAME"];
                            SendKeys.Send("{TAB}");
                        }
                    }
                }
                thisreader.Close();
                con.Close();
                if (!found)
                {
                    PreparedByTextBoxReadOnly.Clear();
                    MessageBox.Show("Employee Code Not found");
                }
            }

        }

        //Method For Examined And Immunized BY
        public void ExaminedOrImmunized(TextBox ExamineByTextBox, TextBox ExamineByTextBoxReadOnly)
        {
            bool found = false;
            if (ExamineByTextBox.Text == "")
            {
                ExamineByTextBoxReadOnly.Clear();
                MessageBox.Show("PLS... FILL UP");
            }
            else
            {
                con.Open();
                OleDbCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM EMPLOYEEFILE";
                OleDbDataReader thisreader = command.ExecuteReader();
                while (thisreader.Read())
                {
                    if (thisreader["EMPCODE"].ToString() == ExamineByTextBox.Text)
                    {
                        if (thisreader["EMPPOSITION"].ToString() != "Doctor")
                        {
                            found = true;
                            ExamineByTextBoxReadOnly.Text = thisreader["EMPFNAME"] + " " + thisreader["EMPMNAME"] + ". " + thisreader["EMPLNAME"];
                            MessageBox.Show("Unauthorized Employee");
                            ExamineByTextBoxReadOnly.Clear();
                            //con.Close();
                            break;
                        }
                        else if (thisreader["EMPSTATUS"].ToString() == "IN")
                        {
                            found = true;
                            ExamineByTextBoxReadOnly.Text = thisreader["EMPFNAME"] + " " + thisreader["EMPMNAME"] + ". " + thisreader["EMPLNAME"];
                            MessageBox.Show("Employee is already In-Active");
                            ExamineByTextBoxReadOnly.Clear();
                        }
                        else
                        {
                            found = true;
                            ExamineByTextBoxReadOnly.Text = thisreader["EMPFNAME"] + " " + thisreader["EMPMNAME"] + ". " + thisreader["EMPLNAME"];
                            SendKeys.Send("{TAB}");
                        }
                    }
                }
                thisreader.Close();
                con.Close();
                if (!found)
                {
                    ExamineByTextBoxReadOnly.Clear();
                    MessageBox.Show("Employee Code Not found");
                }
            }
        }

        private void ImmunizedByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ExaminedOrImmunized(ImmunizedByTextBox, ImmunizedByTextBoxReadOnly);
            }
        }

        //Immunize No.
        private void ImmunizationNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool unique = false;
                if (ImmunizationNoTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    con.Open();
                    OleDbCommand command = con.CreateCommand();
                    command.CommandText = "SELECT IMMHIMMUNO FROM IMMUNIZATIONHEADERFILE";
                    OleDbDataReader thisreader = command.ExecuteReader();
                    while (thisreader.Read())
                    {
                        if (thisreader["IMMHIMMUNO"].ToString() == ImmunizationNoTextBox.Text)
                        {
                            MessageBox.Show("Immunization Number Already in the file");
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

       
        //Vaccine NO.
        int numshot;
        int totalshot;
        int vacpatshotnum;
        string vaccineName = "";
        string vaccineCode = "";
        string vaccinedesc = "";
        private void VaccineCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool found = false;
            numshot = 0;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (VaccineCodeTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    if (UniqueVaccineCode(VaccineCodeTextBox.Text))
                    {
                        con.Open();
                        OleDbCommand command = con.CreateCommand();
                        command.CommandText = "SELECT * FROM VACCINEFILE";
                        OleDbDataReader thisreader = command.ExecuteReader();
                        while (thisreader.Read())
                        {
                            if (thisreader["VACCODE"].ToString() == VaccineCodeTextBox.Text)
                            {
                                found = true;
                                if (thisreader["VACSTATUS"].ToString() == "UN")
                                {
                                    MessageBox.Show("Vaccine is Already Unavailable");
                                    break;
                                }
                                else
                                {
                                    vaccineName = thisreader["VACNAME"].ToString();
                                    vaccineCode = thisreader["VACCODE"].ToString();
                                    vaccinedesc = thisreader["VACDESC"].ToString(); ;
                                    numshot = Convert.ToInt32(thisreader["VACNUMSHOT"]);
                                    SendKeys.Send("{TAB}");
                                }
                            }
                        }
                        thisreader.Close();
                        con.Close();
                        if (!found)
                        {
                            MessageBox.Show("Vaccine Code Not Found");
                        }
                    }
                    else {
                        MessageBox.Show("Vaccine Code already in the list");
                    }
                }
            }
        }

        //Shot Number
        private void ShotNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            totalshot = 0;
            vacpatshotnum = 0;
            bool firstTime = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ShotNumberTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    try
                    {
                        con.Open();
                        OleDbCommand command = con.CreateCommand();
                        command.CommandText = "SELECT * FROM VACCINEPATIENTFILE";
                        OleDbDataReader thisreader = command.ExecuteReader();
                        while (thisreader.Read())
                        {
                            if (thisreader["VACVCODE"].ToString() == vaccineCode && thisreader["VACPCODE"].ToString() == PatientCodeTextBox.Text)
                            {
                                vacpatshotnum = Convert.ToInt32(thisreader["VACPATSHOTNUM"]);
                                firstTime = false;
                                break;
                            }
                        }
                        thisreader.Close();
                        con.Close();
                        totalshot = vacpatshotnum + Convert.ToInt32(ShotNumberTextBox.Text);
                        if (totalshot > numshot)
                        {
                            MessageBox.Show("Shot Number Already reaches its limit");
                            ShotNumberTextBox.Clear();
                        }
                        else if (firstTime)
                        {
                            MessageBox.Show("He/She is first Time in this vaccine");
                            InsertVaPatFile();
                            SendKeys.Send("{TAB}");
                        }
                        else
                        {
                            SendKeys.Send("{TAB}");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
            }
        }

        //insert if first time in the vaccine
        private void InsertVaPatFile()
        {
            string sql = "Select * From VACCINEPATIENTFILE";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, con);
            OleDbCommandBuilder cmdbuilder = new OleDbCommandBuilder(dataAdapter);
            DataSet dataset = new DataSet();
            dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            dataAdapter.Fill(dataset, "VACCINEPATIENTFILE");
            object[] colpk = new object[2];
            colpk[0] = VaccineCodeTextBox.Text;
            colpk[1] = PatientCodeTextBox.Text;
            DataRow findrow = dataset.Tables["VACCINEPATIENTFILE"].Rows.Find(colpk);
            if (findrow == null)
            {
                DataRow datarow = dataset.Tables["VACCINEPATIENTFILE"].NewRow();
                datarow[0] = VaccineCodeTextBox.Text;
                datarow[1] = PatientCodeTextBox.Text;
                datarow[2] = Convert.ToDateTime(immunizeDateTimePicker.Text);
                datarow[3] = ShotNumberTextBox.Text;
                datarow[4] = "IC";

                dataset.Tables["VACCINEPATIENTFILE"].Rows.Add(datarow);
                dataAdapter.Update(dataset, "VACCINEPATIENTFILE");
            }
            else
            {
                MessageBox.Show("Duplicate Entry");
            }
        }

        //Reaction 
        private void ReactionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ReactionTextBox.Text == "")
                {
                    MessageBox.Show("PLS... FILL UP");
                }
                else
                {
                    if (totalshot <= numshot && vaccineCode != "" && ShotNumberTextBox.Text != "")
                    {
                        VaccinedataGridView.Rows.Add(vaccineCode, vaccineName, vaccinedesc, ShotNumberTextBox.Text, ReactionTextBox.Text);
                        VaccineCodeTextBox.Clear();
                        ShotNumberTextBox.Clear();
                        ReactionTextBox.Clear();
                        vaccineCode = "";
                        vaccineName = "";
                        vaccinedesc = "";
                        SendKeys.Send("{TAB}");
                    }
                    else {
                        MessageBox.Show("Pls. Complete All Details!!");
                    }

                }
            }
        }

        //Enter Weight
        private void WeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ifValidNumber(WeightTextBox.Text);           
        }


        //Enter Height
        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                ifValidNumber(HeightTextBox.Text);
        }

        public void ifValidNumber(String Value)
        {
            
            try
            {
                double val = Convert.ToDouble(Value);
                SendKeys.Send("{TAB}");
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }           
        }
        //Unique Vaacine Code Of the datagridView
        private bool UniqueVaccineCode(string vacCode)
        {
            if (VaccinedataGridView.RowCount >= 1)
            {
                foreach (DataGridViewRow row in VaccinedataGridView.Rows)
                {
                    if(row.Cells["vaccode"].Value != null){
                        string val = row.Cells["vaccode"].Value.ToString();
                        if (val.Equals(vacCode))
                        {
                            return false;
                        }
                    }
                }
           }
            return true;
        }

       
    }
}
