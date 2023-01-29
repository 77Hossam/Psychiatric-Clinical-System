using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewNewSecretary
{
    public partial class Patient : Form
    {

        Form1 f = new Form1();

        public Patient(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPatient f = new AddPatient();
            f.ShowDialog();
        }

        private void DgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblFirstName.Text = DgvPatient.CurrentRow.Cells[2].Value.ToString();
            lblNationalID.Text = DgvPatient.CurrentRow.Cells[3].Value.ToString();
            lblPhoneNumber.Text = DgvPatient.CurrentRow.Cells[4].Value.ToString();

            byte[] img = (byte[])DgvPatient.CurrentRow.Cells[5].Value;
            MemoryStream sm = new MemoryStream(img);
            pic.Image = Image.FromStream(sm);
        }

        private void DgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblFirstName.Text = DgvPatient.CurrentRow.Cells[2].Value.ToString();
            lblNationalID.Text = DgvPatient.CurrentRow.Cells[3].Value.ToString();
            lblPhoneNumber.Text = DgvPatient.CurrentRow.Cells[4].Value.ToString();

            byte[] img = (byte[])DgvPatient.CurrentRow.Cells[5].Value;
            MemoryStream sm = new MemoryStream(img);
            pic.Image = Image.FromStream(sm);
            string ColName = DgvPatient.Columns[e.ColumnIndex].Name;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
