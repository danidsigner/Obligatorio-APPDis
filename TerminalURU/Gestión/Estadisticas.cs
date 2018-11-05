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
        string datos = WS.Estadisticas();

        public Estadisticas()
        {
            InitializeComponent();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarPaises();
        }

        public void CargarGrilla()
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

        public void CargarPaises()
        {
            XElement xel = XElement.Parse(datos);

            var resultado = (from unNodo in xel.Elements("Viaje")
                             select 
                             unNodo.Element("PaisDestino").Value).Distinct().ToList();

            cbPaises.DataSource = resultado;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime inicio = new DateTime(dtpInicio.Value.Year,dtpInicio.Value.Month,dtpInicio.Value.Day);
            DateTime final = new DateTime(dtpFinal.Value.Year, dtpFinal.Value.Month, dtpFinal.Value.Day, 23,59,0);

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

        private void btnFiltrarPais_Click(object sender, EventArgs e)
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

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
