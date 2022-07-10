using Datos;
using Datos.Exceptions;
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
    public partial class FrmCargarTurno : Form
    {
        private MascotaDAO mascotaDAO;
        private TurnoDAO turnoDAO;

        public FrmCargarTurno(TurnoDAO turnoDAO)
        {
            InitializeComponent();

            this.mascotaDAO = new MascotaDAO();
            this.turnoDAO = turnoDAO;
        }

        private void EstablecerMascota()
        {
            try
            {
                Mascota mascota = this.mascotaDAO.LeerPorId((long)txtIdMascota.Value);
                this.txtNombreMascota.Text = mascota.Nombre;
                txtPeso.Value = (decimal)mascota.Peso;
                dtFechaNacimiento.Value = mascota.FechaNacimiento;
                this.grpTurno.Enabled = true;
                this.btnAgregar.Enabled = true;
            }
            catch (EntidadInexistenteException ex)
            {
                MessageBox.Show(ex.Message);
                this.grpMascota.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.txtNombreMascota.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.grpMascota.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.txtNombreMascota.Text = string.Empty;
            }
        }


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

        private void FrmCargarTurno_Load(object sender, EventArgs e)
        {
            dtFecha.MaxDate = DateTime.Now.AddMonths(3);
            dtFecha.MinDate = DateTime.Now.Date;
            dtFecha.Value = DateTime.Now;
        }

        private void FrmCargarTurno_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtIdMascota_ValueChanged(object sender, EventArgs e)
        {
            EstablecerMascota();
        }

        private void txtIdMascota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtIdMascota.ValueChanged -= txtIdMascota_ValueChanged;
                EstablecerMascota();
                this.txtIdMascota.ValueChanged += txtIdMascota_ValueChanged;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (SeCompletaronTodosLosCampos())
            {
                //Turno turno = new Turno((long)txtIdMascota.Value, dtFecha.Value, txtComentario.Text);
                //this.turnoDAO.Guardar(turno);
                //this.DialogResult = DialogResult.OK;
                //ReiniciarCampos();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Debe indicar todos los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
