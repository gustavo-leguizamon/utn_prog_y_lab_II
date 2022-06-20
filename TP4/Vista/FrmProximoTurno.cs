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
    public partial class FrmProximoTurno : Form
    {
        private DateTime proximoTurno;
        private Temporizador temporizadorActual;
        private Temporizador temporizadorRestante;

        public FrmProximoTurno(DateTime proximoTurno)
        {
            InitializeComponent();

            this.proximoTurno = proximoTurno;

            temporizadorActual = new Temporizador(1000);
            temporizadorActual.OnTimerCompleto += AsignarHoraActual;

            temporizadorRestante = new Temporizador(1000);
            temporizadorRestante.OnTimerCompleto += AsignarHoraRestante;
        }

        private void FrmProximoTurno_Load(object sender, EventArgs e)
        {
            lblHoraProximoTurno.Text = proximoTurno.ToString("dd/MM/yyyy HH:mm:ss");
            temporizadorActual.Comenzar();
            temporizadorRestante.Comenzar();
        }

        private void AsignarHoraActual()
        {
            if (lblHoraActual.InvokeRequired)
            {
                Action delegadoAsignarHora = AsignarHoraActual;
                lblHoraActual.Invoke(delegadoAsignarHora);
            }
            else
            {
                lblHoraActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void AsignarHoraRestante()
        {
            if (lblHoraRestante.InvokeRequired)
            {
                Action delegadoAsignarHora = AsignarHoraRestante;
                lblHoraRestante.Invoke(delegadoAsignarHora);
            }
            else
            {
                lblHoraRestante.Text = this.proximoTurno.Subtract(DateTime.Now).ToString("d' Días 'h' Horas 'm' Minutos 's' Segundos'");
            }
        }
    }
}
