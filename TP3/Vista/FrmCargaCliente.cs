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
    public partial class FrmCargaCliente : Form
    {
        public FrmCargaCliente()
        {
            InitializeComponent();
        }

        #region Methods

        private bool SeRealizaronCambios()
        {
            return this.txtNombre.Text.Trim().Length > 0 ||
                   this.txtApellido.Text.Trim().Length > 0 ||
                   this.txtDni.Value > 0;

        }

        #endregion

        private void FrmCargaCliente_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void FrmCargaCliente_FormClosing(object sender, FormClosingEventArgs e)
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
