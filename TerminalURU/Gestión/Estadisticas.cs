using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestión.ServicioWeb;
using System.Xml;
using System.IO;
using System.Web;
using System.Xml.Linq;

namespace Gestión
{
    public partial class Estadisticas : Form
    {
        static WebService WS = new WebService();
        string datos = "";

        public void obtenerDatos()
        {
            try
            {
                datos = WS.Estadisticas();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                manejoErrorWS(ex.Message);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public Estadisticas()
        {
            InitializeComponent();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            obtenerDatos();
            CargarGrilla();
            CargarPaises();
        }

        public void CargarGrilla()
        {
            try
            {
                dtpInicio.Value = DateTime.Now;
                dtpFinal.Value = DateTime.Now;

                XElement xel = XElement.Parse(datos);

                var resultado = (from unNodo in xel.Elements("Viaje")
                                 select new
                                 {
                                     Numero = unNodo.Element("Número").Value,
                                     CiudadDestino = unNodo.Element("CiudadDestino").Value,
                                     PaisDestino = unNodo.Element("PaisDestino").Value,
                                     Compania = unNodo.Element("Compania").Value,
                                     FechaPartida = unNodo.Element("FechaPartida").Value
                                 }).ToList();

                dgvViajes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public void CargarPaises()
        {
            try
            {
                XElement xel = XElement.Parse(datos);

                var resultado = (from unNodo in xel.Elements("Viaje")
                                 select
                                 unNodo.Element("PaisDestino").Value).Distinct().ToList();

                cbPaises.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime inicio = new DateTime(dtpInicio.Value.Year, dtpInicio.Value.Month, dtpInicio.Value.Day);
                DateTime final = new DateTime(dtpFinal.Value.Year, dtpFinal.Value.Month, dtpFinal.Value.Day, 23, 59, 0);

                XElement xel = XElement.Parse(datos);
                var resultado = (from unNodo in xel.Elements("Viaje")
                                 where Convert.ToDateTime((string)unNodo.Element("FechaPartida")) >= inicio &&
                                       Convert.ToDateTime((string)unNodo.Element("FechaPartida")) <= final
                                 select new
                                 {
                                     Numero = unNodo.Element("Número").Value,
                                     CiudadDestino = unNodo.Element("CiudadDestino").Value,
                                     PaisDestino = unNodo.Element("PaisDestino").Value,
                                     Compania = unNodo.Element("Compania").Value,
                                     FechaPartida = unNodo.Element("FechaPartida").Value
                                 }).ToList();

                dgvViajes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void btnFiltrarPais_Click(object sender, EventArgs e)
        {
            try
            {
                XElement xel = XElement.Parse(datos);

                var resultado = (from unNodo in xel.Elements("Viaje")
                                 where unNodo.Element("PaisDestino").Value == cbPaises.SelectedItem.ToString()
                                 select new
                                 {
                                     Numero = unNodo.Element("Número").Value,
                                     CiudadDestino = unNodo.Element("CiudadDestino").Value,
                                     PaisDestino = unNodo.Element("PaisDestino").Value,
                                     Compania = unNodo.Element("Compania").Value,
                                     FechaPartida = unNodo.Element("FechaPartida").Value
                                 }).ToList();

                dgvViajes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnViajesAño_Click(object sender, EventArgs e)
        {
            try
            {
                XElement xel = XElement.Parse(datos);

                var resultado = (from unNodo in xel.Descendants("Viaje")
                                 group unNodo by new { unNodo.Element("Compania").Value, Convert.ToDateTime(unNodo.Element("FechaPartida").Value).Year }
                                     into grupo
                                     orderby grupo.Key.Value, grupo.Key.Year
                                     select new
                                     {
                                         compañia = grupo.Key.Value,
                                         año = grupo.Key.Year.ToString(),
                                         cantidad = grupo.Count()
                                     }).ToList();

                dgvViajes.DataSource = resultado;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void manejoErrorWS(string ex)
        {
            string palabraClave = "ExcepcionEX:";
            string palabraClaveFin = "FinExcepcionEX";
            int posicion = ex.IndexOf(palabraClave);
            int posicionFin = ex.IndexOf(palabraClaveFin);
            string errorOriginal = "";

            if (posicion != -1 && posicionFin != -1)
            {
                errorOriginal = ex.Substring(posicion + palabraClave.Length, (posicionFin - posicion) - 13);
                lblError.Text = errorOriginal;
            }
            else
            {
                errorOriginal = "Error de conexión.";
                MessageBox.Show(errorOriginal);
            }
        }
    }
}
