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
using Vista.Exceptions;

namespace Vista
{
    public partial class FrmListadoDeTurnos : Form
    {
        private TurnoDAO turnoDAO;
        private EstadoTurnoDAO estadoTurnoDAO;

        public FrmListadoDeTurnos()
        {
            InitializeComponent();

            this.turnoDAO = new TurnoDAO();
            this.estadoTurnoDAO = new EstadoTurnoDAO();
        }

        #region Metodos

        /// <summary>
        /// Maneja las excepciones ocurridas en el formulario
        /// </summary>
        /// <param name="exception">Excepcion que ocurrio</param>
        private void ManejarExcepcion(Exception exception)
        {
            if (exception is ElementoNoSeleccionadoException ||
                exception is ArgumentException)
            {
                MessageBox.Show(exception.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (exception is NotImplementedException)
            {
                MessageBox.Show("Hay partes sin implementar de la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Error inesperado. {exception.Message} - {exception.StackTrace}");
            }
        }

        /// <summary>
        /// Busca todos los tunos generados
        /// </summary>
        private void BuscarTurnos()
        {
            BuscarTurnos(null);
        }

        /// <summary>
        /// Busca todos los turnos en un estado especifico
        /// </summary>
        /// <param name="estado">Estado con el que deben estar los turnos buscados</param>
        private void BuscarTurnos(EstadoTurno estado)
        {
            List<InformacionTurno> listadoDeTurnos = this.turnoDAO.ObtenerListadoDeTurnos(estado);
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

        /// <summary>
        /// Marca los turnos segun su estado
        /// </summary>
        private void MarcarFilas()
        {
            foreach (DataGridViewRow row in this.dtgTurnos.Rows)
            {
                if (Convert.ToInt16(row.Cells["EstadoTurnoId"].Value) == (short)EstadoTurno.eEstadoTurno.Cancelado)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToInt16(row.Cells["EstadoTurnoId"].Value) == (short)EstadoTurno.eEstadoTurno.Atendido)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        /// <summary>
        /// Cancela un turno
        /// </summary>
        /// <param name="turnoId">ID del turno</param>
        private void CancelarTurno(long turnoId)
        {
            if (MessageBox.Show("Desea cancelar el turno?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.turnoDAO.CambiarEstado(turnoId, EstadoTurno.eEstadoTurno.Cancelado);
            }
        }

        /// <summary>
        /// Reprograma un turno vigente
        /// </summary>
        /// <param name="turnoId">ID del turno</param>
        private void ReprogramarTurno(long turnoId)
        {
            Turno turno = this.turnoDAO.LeerPorId(turnoId, new Type[] { typeof(Mascota) });
            Form form = new FrmABMTurno(this.turnoDAO, eFrmABM.Editar, turno);
            form.ShowDialog();
        }

        /// <summary>
        /// Obtiene el ID del turno en una fila del DataGrid
        /// </summary>
        /// <param name="rowIndex">Indice de la fila</param>
        /// <returns>ID del turno</returns>
        private long ObtenerTurnoId(int rowIndex)
        {
            return Convert.ToInt64(this.dtgTurnos.Rows[rowIndex].Cells["TurnoId"].Value);
        }

        /// <summary>
        /// Coloca todos los estados de turnos posibles
        /// </summary>
        private void ColocarItemsEstadoTurno()
        {
            List<EstadoTurno> estados = this.estadoTurnoDAO.Leer();
            this.cmbEstadoTurno.Items.Clear();
            this.cmbEstadoTurno.Items.Insert(0, new EstadoTurno(0, "Todos"));
            this.cmbEstadoTurno.Items.AddRange(estados.ToArray());
            this.cmbEstadoTurno.SelectedIndex = 0;
        }

        /// <summary>
        /// Obtiene el estado del turno seleccionado
        /// </summary>
        /// <returns>Estado seleccionado</returns>
        /// <exception cref="ElementoNoSeleccionadoException">Lanzada cuando se llema sin haber seleccionado un turno</exception>
        private EstadoTurno EstadoSeleccionado()
        {
            EstadoTurno estado = this.cmbEstadoTurno.SelectedItem as EstadoTurno;
            if (estado is null)
            {
                throw new ElementoNoSeleccionadoException("Debe seleccionar un estado");
            }
            return estado;
        }

        #endregion

        #region Eventos

        #region Form

        private void FrmListadoDeTurnos_Load(object sender, EventArgs e)
        {
            try
            {
                this.turnoDAO.OnNuevosDatos += BuscarTurnos;
                this.turnoDAO.OnNuevosDatos += MarcarFilas;
                ColocarItemsEstadoTurno();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #region Grid

        private void dtgTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        private void dtgTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ReprogramarTurno(ObtenerTurnoId(e.RowIndex));
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #region ComboBox

        private void cmbEstadoTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarTurnos(EstadoSeleccionado());
                MarcarFilas();
            }
            catch (Exception ex)
            {
                ManejarExcepcion(ex);
            }
        }

        #endregion

        #endregion

    }
}
