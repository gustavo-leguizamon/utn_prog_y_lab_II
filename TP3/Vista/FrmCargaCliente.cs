using Entidades;
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
        private List<Cliente> clientes;

        public FrmCargaCliente(List<Cliente> clientes)
        {
            InitializeComponent();

            this.clientes = clientes;
        }

        #region Methods

        private bool SeRealizaronCambios()
        {
            return this.txtNombre.Text.Trim().Length > 0 ||
                   this.txtApellido.Text.Trim().Length > 0 ||
                   this.txtDni.Value > 0;

        }

        private void ReiniciarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDni.Value = 0;
        }

        private bool SeCompletaronTodosLosCampos()
        {
            return this.txtNombre.Text.Trim().Length > 0 &&
                   this.txtApellido.Text.Trim().Length > 0 &&
                   this.txtDni.Value > 0;

        }

        private bool ValidaClienteUnico()
        {
            foreach (Cliente cliente in this.clientes)
            {
                if (cliente.Dni == (long)this.txtDni.Value)
                    return false;
            }
            return true;
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidaClienteUnico())
            {
                if (SeCompletaronTodosLosCampos())
                {
                    this.clientes.Add(new Cliente()
                    {
                        Nombre = this.txtNombre.Text,
                        Apellido = this.txtApellido.Text,
                        Dni = (long)this.txtDni.Value,
                        FechaNacimiento = this.dtFechaNacimiento.Value
                    });
                    this.DialogResult = DialogResult.OK;
                    ReiniciarCampos();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe indicar todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe indicar un DNI diferente ya que hay otro cliente con el mismo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
