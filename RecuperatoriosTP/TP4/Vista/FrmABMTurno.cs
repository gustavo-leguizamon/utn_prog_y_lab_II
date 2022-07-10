﻿using Datos;
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
    public partial class FrmABMTurno : Form
    {
        //private MascotaDAO mascotaDAO;
        private eFrmABM eFrmABM;
        private Turno turno;
        private TurnoDAO turnoDAO;

        public FrmABMTurno(TurnoDAO turnoDAO, Mascota mascota)
           : this(turnoDAO, eFrmABM.Crear, new Turno(mascota))
        {
        }

        public FrmABMTurno(TurnoDAO turnoDAO, eFrmABM eFrmABM, Turno turno)
        {
            InitializeComponent();

            this.turnoDAO = turnoDAO;
            //this.clienteDAO = new ClienteDAO();
            this.eFrmABM = eFrmABM;
            this.turno = turno;
        }

        //public FrmABMTurno(TurnoDAO turnoDAO)
        //{
        //    InitializeComponent();

        //    this.mascotaDAO = new MascotaDAO();
        //    this.turnoDAO = turnoDAO;
        //}

        //private void EstablecerMascota()
        //{
        //    try
        //    {
        //        Mascota mascota = this.mascotaDAO.LeerPorId((long)txtIdMascota.Value);
        //        this.txtNombreMascota.Text = mascota.Nombre;
        //        txtPeso.Value = (decimal)mascota.Peso;
        //        dtFechaNacimiento.Value = mascota.FechaNacimiento;
        //        this.grpTurno.Enabled = true;
        //        this.btnAgregar.Enabled = true;
        //    }
        //    catch (EntidadInexistenteException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        this.grpMascota.Enabled = false;
        //        this.btnAgregar.Enabled = false;
        //        this.txtNombreMascota.Text = string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.grpMascota.Enabled = false;
        //        this.btnAgregar.Enabled = false;
        //        this.txtNombreMascota.Text = string.Empty;
        //    }
        //}


        #region Metodos

        private void ColocarDatos()
        {
            if (this.turno is not null)
            {
                this.txtComentario.Text = this.turno.Comentario;
                if (turno.Id > 0)
                {
                    this.txtNombreMascota.Text = this.turno.Mascota.Nombre;
                    this.txtPeso.Value = (decimal)this.turno.Mascota.Peso;
                    this.dtFechaNacimiento.Value = this.turno.Mascota.FechaNacimiento;
                    //this.grpTurno.Enabled = true;
                    this.btnAceptar.Enabled = true;
                }
            }
        }

        private bool SeRealizaronCambios()
        {
            return (this.eFrmABM == eFrmABM.Crear && (!string.IsNullOrWhiteSpace(this.txtComentario.Text))) ||
                   (this.eFrmABM == eFrmABM.Editar && (this.txtComentario.Text.Trim() != this.turno.Comentario.Trim()));
        }

        private bool SeCompletaronTodosLosCampos()
        {
            return !string.IsNullOrWhiteSpace(this.txtComentario.Text);

        }

        private void ReiniciarCampos()
        {
            this.txtComentario.Text = string.Empty;
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmCargarTurno_Load(object sender, EventArgs e)
        {
            dtFecha.MaxDate = DateTime.Today.AddMonths(6);
            dtFecha.MinDate = DateTime.Today;
            dtFecha.Value = DateTime.Today;
            ColocarDatos();
        }

        private void FrmCargarTurno_FormClosing(object sender, FormClosingEventArgs e)
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
            if (SeCompletaronTodosLosCampos())
            {
                Turno turno = new Turno((long)txtIdMascota.Value, dtFecha.Value, txtComentario.Text);
                if (this.eFrmABM == eFrmABM.Crear)
                {
                    this.turnoDAO.Guardar(turno);
                }
                else if (this.eFrmABM == eFrmABM.Editar)
                {
                    this.turnoDAO.Modificar(turno);
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

        #endregion

        #endregion



    }
}