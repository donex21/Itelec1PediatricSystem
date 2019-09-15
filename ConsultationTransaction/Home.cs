using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEDIATRICCLINICALSYSTEM
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Consultationbutton_Click(object sender, EventArgs e)
        {
            ConsultationTransaction consultation = new ConsultationTransaction();
            consultation.Show();
        }

        private void ImmunizationButton_Click(object sender, EventArgs e)
        {
            Immunization immunization = new Immunization();
            immunization.Show();
        }

        private void PrescriptionButton_Click(object sender, EventArgs e)
        {
            Prescription prescription = new Prescription();
            prescription.Show();
        }
    }
}
