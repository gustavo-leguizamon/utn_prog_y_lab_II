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
    public partial class FrmCargaMascota : Form
    {
        public FrmCargaMascota()
        {
            InitializeComponent();
        }

        #region Methods

        private bool SeRealizaronCambios()
        {
            return this.txtNombre.Text.Trim().Length > 0 ||
                   this.txtPeso.Value > 0;

        }

        #endregion

        private void FrmCargaPaciente_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now;
        }

        private void FrmCargaMascota_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SeRealizaronCambios() && MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
