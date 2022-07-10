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
    public partial class FrmListadoDeTurnos : Form
    {
        private TurnoDAO turnoDAO;

        public FrmListadoDeTurnos()
        {
            InitializeComponent();

            this.turnoDAO = new TurnoDAO();
        }

        #region Metodos

        private void BuscarTurnos()
        {
            List<InformacionTurno> listadoDeTurnos = this.turnoDAO.ObtenerListadoDeTurnos();
            this.dtgTurnos.DataSource = listadoDeTurnos;

            this.dtgTurnos.Columns["EstadoTurnoId"].Visible = false;

            DataGridViewButtonColumn btnCancelar = new DataGridViewButtonColumn();
            btnCancelar.HeaderText = "";
            btnCancelar.Text = "Cancelar";
            btnCancelar.Name = "btnCancelar";
            btnCancelar.UseColumnTextForButtonValue = true;
            btnCancelar.DefaultCellStyle.BackColor = Color.Red;
            this.dtgTurnos.Columns.Add(btnCancelar);

            DataGridViewButtonColumn btnReprogramar = new DataGridViewButtonColumn();
            btnReprogramar.HeaderText = "";
            btnReprogramar.Text = "Reprogramar";
            btnReprogramar.Name = "btnReprogramar";
            btnReprogramar.UseColumnTextForButtonValue = true;
            btnReprogramar.DefaultCellStyle.BackColor = Color.Yellow;
            this.dtgTurnos.Columns.Add(btnReprogramar);

            this.dtgTurnos.Update();
            this.dtgTurnos.Refresh();
        }

        private void MarcarCancelados()
        {
            foreach (DataGridViewRow row in this.dtgTurnos.Rows)
            {
                if (Convert.ToInt16(row.Cells["EstadoTurnoId"].Value) == (short)EstadoTurno.eEstadoTurno.Cancelado)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void CancelarTurno(long turnoId)
        {
            if (MessageBox.Show("Desea cancelar el turno?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.turnoDAO.CambiarEstado(turnoId, EstadoTurno.eEstadoTurno.Cancelado);
            }
        }

        private void ReprogramarTurno(long turnoId)
        {
            Turno turno = this.turnoDAO.LeerPorId(turnoId, new Type[] { typeof(Mascota) });
            Form form = new FrmABMTurno(this.turnoDAO, eFrmABM.Editar, turno);
            form.ShowDialog();
        }

        private long ObtenerTurnoId(int rowIndex)
        {
            return Convert.ToInt64(this.dtgTurnos.Rows[rowIndex].Cells["TurnoId"].Value);
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmListadoDeTurnos_Load(object sender, EventArgs e)
        {
            this.turnoDAO.OnNuevosDatos += BuscarTurnos;
            this.turnoDAO.OnNuevosDatos += MarcarCancelados;
            BuscarTurnos();
        }

        #endregion

        #region Grid

        private void dtgTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) //Cancelar
            {
                CancelarTurno(ObtenerTurnoId(e.RowIndex));
            }
            else if (e.ColumnIndex == 8) //Reprogramar
            {
                ReprogramarTurno(ObtenerTurnoId(e.RowIndex));
            }
        }

        private void dtgTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReprogramarTurno(ObtenerTurnoId(e.RowIndex));
        }

        #endregion

        #endregion

    }
}
