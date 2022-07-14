﻿using Datos;
using Datos.Exceptions;
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
using Vista.Exceptions;

namespace Vista
{
    public partial class FrmABMCliente : Form
    {
        private ClienteDAO clienteDAO;
        private eFrmABM eFrmABM;
        private Cliente cliente;
        private bool operacionFinalizada;

        public FrmABMCliente(ClienteDAO clienteDAO)
            : this(clienteDAO, eFrmABM.Crear, null)
        {
        }

        public FrmABMCliente(ClienteDAO clienteDAO, eFrmABM eFrmABM, Cliente cliente)
        {
            InitializeComponent();

            this.clienteDAO = clienteDAO;
            this.eFrmABM = eFrmABM;
            this.cliente = cliente;
            this.operacionFinalizada = false;
        }

        #region Metodos

        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (!string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                                                      !string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                                                      !string.IsNullOrWhiteSpace(this.txtDireccion.Text) ||
                                                      this.txtDni.Value > 0)) ||
                   (this.eFrmABM == eFrmABM.Editar && !this.operacionFinalizada && 
                                                     (this.txtNombre.Text.Trim() != this.cliente.Nombre.Trim() ||
                                                       this.txtApellido.Text.Trim() != this.cliente.Apellido.Trim() ||
                                                       this.txtDireccion.Text.Trim() != this.cliente.Direccion.Trim() ||
                                                       this.txtDni.Value != this.cliente.Dni ||
                                                       this.dtFechaNacimiento.Value != this.cliente.FechaNacimiento));

        }

        //private void ReiniciarCampos()
        //{
        //    this.txtNombre.Text = string.Empty;
        //    this.txtApellido.Text = string.Empty;
        //    this.txtDireccion.Text = string.Empty;
        //    this.txtDni.Value = 0;
        //}

        private void SeCompletaronTodosLosCampos()
        {
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text) ||
                string.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                string.IsNullOrWhiteSpace(this.txtDireccion.Text) ||
                this.txtDni.Value == 0)
            {
                throw new ValidacionException("Debe indicar todos los datos");
            }
        }

        private void EsDniUnico()
        {
            try
            {
                if (this.clienteDAO.Existe((long)this.txtDni.Value))
                {
                    throw new ValidacionException("Debe indicar un DNI diferente ya que hay otro cliente con el mismo.");
                }
            }
            catch (EntidadInexistenteException)
            {

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
            this.chkActivo.Enabled = editarDatos;
            if (this.eFrmABM == eFrmABM.Crear)
            {
                this.Text = "Cargar nuevo cliente";
                this.btnAceptar.Text = "Registrar";
            }
            else if (this.eFrmABM == eFrmABM.Editar)
            {
                this.Text = "Modificar datos de cliente";
                this.btnAceptar.Text = "Modificar";
            }
            else
            {
                this.Text = "Datos de cliente";
                this.btnAceptar.Visible = false;
                this.btnCancelar.Text = "Aceptar";
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
                this.chkActivo.Checked = cliente.Activo;
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
            if (this.eFrmABM != eFrmABM.Ver &&
                !this.operacionFinalizada &&
                SeRealizaronCambios() && 
                MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
            try
            {
                if (this.eFrmABM != eFrmABM.Ver)
                {
                    SeCompletaronTodosLosCampos();
                    EsDniUnico();
                    Cliente cliente = new Cliente(this.cliente.Id, (long)this.txtDni.Value, this.txtNombre.Text, this.txtApellido.Text, this.dtFechaNacimiento.Value, this.txtDireccion.Text, this.chkActivo.Checked);
                    if (this.eFrmABM == eFrmABM.Crear)
                    {
                        this.clienteDAO.Guardar(cliente);
                    }
                    else if (this.eFrmABM == eFrmABM.Editar)
                    {
                        this.clienteDAO.Modificar(cliente);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.operacionFinalizada = true;
                    this.Close();
                }
            }
            catch (ValidacionException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #endregion
    }
}
