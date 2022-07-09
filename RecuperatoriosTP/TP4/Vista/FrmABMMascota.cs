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
    public partial class FrmABMMascota : Form
    {
        //private Cliente cliente;
        private eFrmABM eFrmABM;
        private Mascota mascota;
        private MascotaDAO mascotaDAO;
        //private ClienteDAO clienteDAO;

        public FrmABMMascota(MascotaDAO mascotaDAO, Cliente cliente)
            : this(mascotaDAO, eFrmABM.Crear, new Mascota(cliente))
        {
        }

        public FrmABMMascota(MascotaDAO mascotaDAO, eFrmABM eFrmABM, Mascota mascota)
        {
            InitializeComponent();

            this.mascotaDAO = mascotaDAO;
            //this.clienteDAO = new ClienteDAO();
            this.eFrmABM = eFrmABM;
            this.mascota = mascota;
        }














        #region Metodos

        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (this.txtNombre.Text.Trim().Length > 0 ||
                                                      this.txtPeso.Value > 0)) ||
                   (this.eFrmABM == eFrmABM.Editar && (this.txtNombre.Text.Trim() != this.mascota.Nombre.Trim() ||
                                                       (float)this.txtPeso.Value != this.mascota.Peso));
        }

        private void ReiniciarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtPeso.Value = 0;
        }

        private bool SeCompletaronTodosLosCampos()
        {
            return this.txtNombre.Text.Trim().Length > 0 &&
                   this.txtPeso.Value > 0;

        }

        private bool ValidaMascotaUnica()
        {
            //return !new BusquedaMascota(this.cliente.Mascotas).Existe(new Mascota(this.cliente.Dni, this.txtNombre.Text, (float)this.txtPeso.Value, this.dtFechaNacimiento.Value));
            return true;
        }

        //private bool EsDniUnico()
        //{
        //    try
        //    {
        //        return !this.clienteDAO.Existe((long)this.txtDni.Value);
        //    }
        //    catch (EntidadInexistenteException)
        //    {
        //        return true;
        //    }
        //}


        //private void EstablecerCliente()
        //{
        //    try
        //    {
        //        //this.cliente = this.clienteDAO.LeerPorId((long)txtDni.Value, new Type[] { typeof(Mascota) });
        //        this.txtNombreCliente.Text = $"{this.mascota.Cliente.Nombre} {this.mascota.Cliente.Apellido}";
        //        this.grpMascota.Enabled = true;
        //        this.btnAceptar.Enabled = true;
        //    }
        //    catch (EntidadInexistenteException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        this.grpMascota.Enabled = false;
        //        this.btnAceptar.Enabled = false;
        //        this.txtNombreCliente.Text = string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.grpMascota.Enabled = false;
        //        this.btnAceptar.Enabled = false;
        //        this.txtNombreCliente.Text = string.Empty;
        //    }
        //}

        private void ManejarControles()
        {
            bool editarDatos = this.eFrmABM != eFrmABM.Ver;
            this.txtNombre.Enabled = editarDatos;
            this.txtPeso.Enabled = editarDatos;
            //this.txtDni.Enabled = editarDatos;
            this.dtFechaNacimiento.Enabled = editarDatos;
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.btnAceptar.Text = "Agregar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.btnAceptar.Visible = false;
                this.btnCancelar.Text = "Aceptar";
            }
        }

        private void ColocarDatos()
        {
            if (this.mascota is not null)
            {
                this.txtDni.Text = this.mascota.Cliente.Dni.ToString();
                this.txtNombreCliente.Text = this.mascota.Cliente.NombreCompleto;
                if (this.mascota.Id > 0)
                {
                    this.txtNombre.Text = mascota.Nombre;
                    this.txtPeso.Value = (decimal)mascota.Peso;
                    this.dtFechaNacimiento.Value = mascota.FechaNacimiento;
                }
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmCargaMascota_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now;
            ColocarDatos();
            ManejarControles();
        }

        private void FrmCargaMascota_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (ValidaMascotaUnica())
                    {
                        Mascota mascota = new Mascota(this.mascota.Cliente.Id, this.txtNombre.Text, (float)this.txtPeso.Value, this.dtFechaNacimiento.Value);
                        if (this.eFrmABM == eFrmABM.Crear)
                        {
                            this.mascotaDAO.Guardar(mascota);
                        }
                        else if (this.eFrmABM == eFrmABM.Editar)
                        {
                            this.mascotaDAO.Modificar(mascota);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe indicar una mascota diferente ya que el cliente ya la registró.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region TextBox

        //private void txtDni_ValueChanged(object sender, EventArgs e)
        //{
        //    EstablecerCliente();
        //}

        //private void txtDni_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.txtDni.ValueChanged -= txtDni_ValueChanged;
        //        EstablecerCliente();
        //        this.txtDni.ValueChanged += txtDni_ValueChanged;
        //    }
        //}

        #endregion

        #endregion
    }
}
