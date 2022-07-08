using Datos;
using Entidades;
using Logica;
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
    public partial class FrmABMCliente : Form
    {
        private ClienteDAO clienteDAO;
        private eFrmABM eFrmABM;
        private Cliente cliente;

        public FrmABMCliente(ClienteDAO clienteDAO, eFrmABM eFrmABM)
        {
            InitializeComponent();

            this.clienteDAO = clienteDAO;
            this.eFrmABM = eFrmABM;
        }

        public FrmABMCliente(ClienteDAO clienteDAO, eFrmABM eFrmABM, Cliente cliente)
            : this(clienteDAO, eFrmABM)
        {
            this.cliente = cliente;
        }

        #region Metodos

        private bool SeRealizaronCambios()
        {
            return this.txtNombre.Text.Trim().Length > 0 ||
                   this.txtApellido.Text.Trim().Length > 0 ||
                   this.txtDireccion.Text.Trim().Length > 0 ||
                   this.txtDni.Value > 0;

        }

        private void ReiniciarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtDni.Value = 0;
        }

        private bool SeCompletaronTodosLosCampos()
        {
            return this.txtNombre.Text.Trim().Length > 0 &&
                   this.txtApellido.Text.Trim().Length > 0 &&
                   this.txtDireccion.Text.Trim().Length > 0 &&
                   this.txtDni.Value > 0;

        }

        private bool EsNuevoCliente()
        {
            try
            {
                return !this.clienteDAO.Existe((long)this.txtDni.Value);
            }
            catch (EntidadInexistenteException)
            {
                return true;
            }
        }

        private void ManejarControles()
        {
            bool editarDatos = this.eFrmABM != eFrmABM.Ver;
            this.txtApellido.Enabled = editarDatos;
            this.txtNombre.Enabled = editarDatos;
            this.txtDni.Enabled = editarDatos;
            this.txtDireccion.Enabled = editarDatos;
            this.dtFechaNacimiento.Enabled = editarDatos;
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.btnAceptar.Text = "Registrar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        private void ColocarDatos()
        {
            if (this.cliente is not null)
            {
                this.txtApellido.Text = cliente.Apellido;
                this.txtNombre.Text = cliente.Nombre;
                this.txtDni.Value = cliente.Dni;
                this.txtDireccion.Text = cliente.Direccion;
                this.dtFechaNacimiento.Value = cliente.FechaNacimiento;
            }

        }

        #endregion

        #region Eventos

        #region Form

        private void FrmABMCliente_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now.AddYears(-18);
            ColocarDatos();
            ManejarControles();
        }

        private void FrmABMCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.eFrmABM != eFrmABM.Ver && SeRealizaronCambios() && MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Botones

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.eFrmABM != eFrmABM.Ver)
            {
                if (SeCompletaronTodosLosCampos())
                {
                    Cliente cliente = new Cliente((long)this.txtDni.Value, this.txtNombre.Text, this.txtApellido.Text, this.dtFechaNacimiento.Value, this.txtDireccion.Text);
                    if (this.eFrmABM == eFrmABM.Crear)
                    {
                        if (EsNuevoCliente())
                        {
                            this.clienteDAO.Guardar(cliente);
                        }
                        else
                        {
                            MessageBox.Show("Debe indicar un DNI diferente ya que hay otro cliente con el mismo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (this.eFrmABM == eFrmABM.Editar)
                    {
                        this.clienteDAO.Modificar(cliente);
                    }
                    this.DialogResult = DialogResult.OK;
                    ReiniciarCampos();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe indicar todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #endregion
    }
}
