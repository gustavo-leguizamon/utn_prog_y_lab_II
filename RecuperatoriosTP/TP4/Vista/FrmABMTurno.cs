using Datos;
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
        private Mascota mascota;
        private TurnoDAO turnoDAO;

        public FrmABMTurno(TurnoDAO turnoDAO, Mascota mascota)
           : this(turnoDAO, eFrmABM.Crear, mascota)
        {
        }

        public FrmABMTurno(TurnoDAO turnoDAO, eFrmABM eFrmABM, Mascota mascota)
        {
            InitializeComponent();

            this.turnoDAO = turnoDAO;
            //this.clienteDAO = new ClienteDAO();
            this.eFrmABM = eFrmABM;
            this.mascota = mascota;
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
            if (this.mascota is not null)
            {
                this.txtNombreMascota.Text = mascota.Nombre;
                this.txtPeso.Value = (decimal)mascota.Peso;
                this.dtFechaNacimiento.Value = mascota.FechaNacimiento;
                //this.grpTurno.Enabled = true;
                this.btnAgregar.Enabled = true;
            }
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmCargarTurno_Load(object sender, EventArgs e)
        {
            dtFecha.MinDate = DateTime.Today;
            dtFecha.MaxDate = DateTime.Today.AddMonths(6);
            dtFecha.Value = DateTime.Today;
        }

        private void FrmCargarTurno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.eFrmABM != eFrmABM.Ver && SeRealizaronCambios() && MessageBox.Show("Se perderan los cambios realizados ¿Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        private bool SeRealizaronCambios()
        {
            return this.txtComentario.Text.Trim().Length > 0;

        }

        private bool SeCompletaronTodosLosCampos()
        {
            return this.txtComentario.Text.Trim().Length > 0;

        }

        private void ReiniciarCampos()
        {
            this.txtComentario.Text = string.Empty;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (SeCompletaronTodosLosCampos())
            {
                Turno turno = new Turno((long)txtIdMascota.Value, dtFecha.Value, txtComentario.Text);
                this.turnoDAO.Guardar(turno);
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
}
