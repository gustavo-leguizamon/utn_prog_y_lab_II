using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaCliente frm = new FrmCargaCliente();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }

        private void btnCargarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargaMascota frm = new FrmCargaMascota();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado. {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
