using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestión.ServicioWeb;

namespace Gestión
{
    public partial class Menu : Form
    {
        private ABMEmpleado EmpFrm;
        private ABMCompañia CompañiaFrm;
        private ABMTerminal TerminalFrm;
        private ViajesInternacionalesFrm InternacionalFrm;
        private ViajesNacionalesFrm NacionalesFrm;
        private Estadisticas frmEstadisticas;
        private Empleado EmpLogueado;

        public Menu(Empleado Emp)
        {
            InitializeComponent();
            EmpLogueado = Emp;
        }

        private void aBMEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpFrm == null)
                {
                    EmpFrm = new ABMEmpleado(EmpLogueado);
                    EmpFrm.FormClosed += new FormClosedEventHandler(ControlVentana);
                    EmpFrm.Show();
                }
                else
                {
                    EmpFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ControlVentana(object sender, FormClosedEventArgs e)
        {
            EmpFrm = null;
            CompañiaFrm = null;
            TerminalFrm = null;
            InternacionalFrm = null;
            NacionalesFrm = null;
            frmEstadisticas = null;
        }

        private void aBMCompañíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CompañiaFrm == null)
                {
                    CompañiaFrm = new ABMCompañia(EmpLogueado);
                    CompañiaFrm.FormClosed += new FormClosedEventHandler(ControlVentana);
                    CompañiaFrm.Show();
                }
                else
                {
                    CompañiaFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        private void aBMTerminalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TerminalFrm == null)
                {
                    TerminalFrm = new ABMTerminal();
                    TerminalFrm.FormClosed += new FormClosedEventHandler(ControlVentana);
                    TerminalFrm.Show();
                }
                else
                {
                    TerminalFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void internacionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (InternacionalFrm == null)
                {
                    InternacionalFrm = new ViajesInternacionalesFrm(EmpLogueado);
                    InternacionalFrm.FormClosed += new FormClosedEventHandler(ControlVentana);
                    InternacionalFrm.Show();
                }
                else
                {
                    InternacionalFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        private void nacionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (NacionalesFrm == null)
                {
                    NacionalesFrm = new ViajesNacionalesFrm(EmpLogueado);
                    NacionalesFrm.FormClosed += new FormClosedEventHandler(ControlVentana);
                    NacionalesFrm.Show();
                }
                else
                {
                    NacionalesFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmEstadisticas == null)
                {
                    frmEstadisticas = new Estadisticas();
                    frmEstadisticas.FormClosed += new FormClosedEventHandler(ControlVentana);
                    frmEstadisticas.Show();
                }
                else
                {
                    frmEstadisticas.Activate();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
