using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NewNewSecretary
{
    public partial class AddPatient : Form
    {
        SqlConnection con = new SqlConnection();
        public AddPatient()
        {
            InitializeComponent();
            con.ConnectionString = @"Server=HOSSAM_LAPTOP\SQLEXPRESS,1433;Database=Clinical;User Id='sa';Password='rude';";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnBrowseImage_Click_1(object sender, EventArgs e)
        {
            /*OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose image |*.png;*.bmp;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Pic.Image = Image.FromFile(ofd.FileName);
            }*/
        }

        private void AddPatient_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand patient = new SqlCommand("INSERT INTO patient(NID, patient_fname, patient_lname, phoneNumber, age, Gender, city) values(@NID, @patient_fname, @patient_lname, @phoneNumber, @age, @Gender, @city);", con);
            patient.Parameters.Add("@NID", TxtNationalID.Text);
            patient.Parameters.Add("@patient_fname", TxtFirstName.Text);
            patient.Parameters.Add("@patient_lname", TxtLastName.Text);
            patient.Parameters.Add("@phoneNumber", TxtPhoneNumber.Text);
            patient.Parameters.Add("@age", TxtAge.Text);
            patient.Parameters.Add("@city", TxtCity.Text);
            if (rdbtnMale.Checked)
            {
                patient.Parameters.Add("@Gender", rdbtnMale.Text);
            }
            if (rdbtnFemale.Checked)
            {
                patient.Parameters.Add("@Gender", rdbtnFemale.Text);
            }
            patient.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Added Successfully");
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
