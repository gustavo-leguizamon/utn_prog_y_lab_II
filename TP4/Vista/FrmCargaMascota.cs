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
    public partial class FrmCargaMascota : Form
    {
        //private List<Cliente> clientes;
        private BusquedaCliente busquedaCliente;
        private BusquedaMascota busquedaMascota;
        private Cliente cliente;

        public FrmCargaMascota(List<Cliente> clientes)
        {
            InitializeComponent();

            //this.clientes = clientes;
            this.busquedaCliente = new BusquedaCliente(clientes);
        }

        #region Methods

        private bool SeRealizaronCambios()
        {
            return this.txtNombre.Text.Trim().Length > 0 ||
                   this.txtPeso.Value > 0;

        }

        private bool SeCompletaronTodosLosCampos()
        {
            return this.txtNombre.Text.Trim().Length > 0 &&
                   this.txtPeso.Value > 0;

        }

        private void ReiniciarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtPeso.Value = 0;
        }

        private bool ValidaMascotaUnica()
        {
            this.busquedaMascota = new BusquedaMascota(this.cliente.Mascotas);
            return !this.busquedaMascota.Existe((long)this.txtDni.Value);
        }

        private void EstablecerCliente()
        {
            try
            {
                this.cliente = this.busquedaCliente.Buscar((long)this.txtDni.Value);
                this.txtNombreCliente.Text = $"{this.cliente.Nombre} {this.cliente.Apellido}";
                this.grpMascota.Enabled = true;
                this.btnAgregar.Enabled = true;
            }
            catch (EntidadInexistenteException ex)
            {
                MessageBox.Show(ex.Message);
                this.grpMascota.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.txtNombreCliente.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.grpMascota.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.txtNombreCliente.Text = string.Empty;
            }
        }

        #endregion

        private void FrmCargaMascota_Load(object sender, EventArgs e)
        {
            this.dtFechaNacimiento.MaxDate = DateTime.Now;
        }

        private void FrmCargaMascota_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtDni_ValueChanged(object sender, EventArgs e)
        {
            EstablecerCliente();
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDni.ValueChanged -= txtDni_ValueChanged;
                EstablecerCliente();
                this.txtDni.ValueChanged += txtDni_ValueChanged;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidaMascotaUnica())
            {
                if (SeCompletaronTodosLosCampos())
                {
                    this.cliente.Mascotas.Add(new Mascota()
                    {
                        DniDuenio = this.cliente.Dni,
                        FechaNacimiento = this.dtFechaNacimiento.Value,
                        Nombre = this.txtNombre.Text,
                        Peso = (float)this.txtPeso.Value,
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
                MessageBox.Show("Debe indicar una mascota diferente ya que el cliente ya la registró.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
