using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Logica;
using EntidadesCompartidas;
using System.Web.Services.Protocols;
using System.Xml;

namespace ServicioWeb
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    public class WebService : System.Web.Services.WebService
    {
        #region Compañia

        [WebMethod]
        public Compania BuscarCompañia(string nombre)
        {
            try
            {
                IlogicaCompania compañia = FabricaLogica.GetLogicaCompania();
                return (compañia.BuscarCompaniaActivas(nombre));
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name,                                                       SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void AltaCompania(Compania C)
        {
            try
            {
                IlogicaCompania compañia = FabricaLogica.GetLogicaCompania();
                compañia.AltaCompania(C);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name,                                                       SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void BajaCompania(Compania C)
        {
            try
            {
                IlogicaCompania compañia = FabricaLogica.GetLogicaCompania();
                compañia.BajaCompania(C);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void ModificarCompania(Compania C)
        {
            try
            {
                IlogicaCompania compañia = FabricaLogica.GetLogicaCompania();
                compañia.ModificarCompania(C);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public List<Compania> ListarCompanias()
        {
            try
            {
                IlogicaCompania compañia = FabricaLogica.GetLogicaCompania();
                return (compañia.ListarCompanias());
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }
        #endregion

        #region Empleado

        [WebMethod]
        public Empleado Logeo(int ci, string contraseña)
        {
            try
            {
                IlogicaEmpleado empleado = FabricaLogica.GetLogicaEmpleado();
                return (empleado.Logeo(ci, contraseña));
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void AltaEmpleado(Empleado E)
        {
            try
            {
                IlogicaEmpleado empleado = FabricaLogica.GetLogicaEmpleado();
                empleado.AltaEmpleado(E);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void BajaEmpleado(Empleado E)
        {
            try
            {
                IlogicaEmpleado empleado = FabricaLogica.GetLogicaEmpleado();
                empleado.BajaEmpleado(E);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void ModificarEmpleado(Empleado E)
        {
            try
            {
                IlogicaEmpleado empleado = FabricaLogica.GetLogicaEmpleado();
                empleado.ModificarEmpleado(E);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public Empleado BuscarEmpleadosActivos(int ci)
        {
            try
            {
                IlogicaEmpleado empleado = FabricaLogica.GetLogicaEmpleado();
                return (empleado.BuscarEmpleadosActivos(ci));
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }
        #endregion

        #region Terminal

        [WebMethod]
        public void AltaTerminal(Terminal T)
        {
            try
            {
                IlogicaTerminal terminal = FabricaLogica.GetLogicaTerminal();
                terminal.AltaTerminal(T);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void BajaTerminal(Terminal T)
        {
            try
            {
                IlogicaTerminal terminal = FabricaLogica.GetLogicaTerminal();
                terminal.BajaTerminal(T);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void ModificarTerminal(Terminal T)
        {
            try
            {
                IlogicaTerminal terminal = FabricaLogica.GetLogicaTerminal();
                terminal.ModificarTerminal(T);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public Terminal BuscarTerminalActiva(string codigo)
        {
            try
            {
                IlogicaTerminal terminal = FabricaLogica.GetLogicaTerminal();
                return (terminal.BuscarTerminalActiva(codigo));
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public List<Terminal> ListarTerminales()
        { 
            try
            {
                IlogicaTerminal terminal = FabricaLogica.GetLogicaTerminal();
                return (terminal.ListarTerminales());
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }
        #endregion

        #region Viajes

        [WebMethod]
        public void AltaViaje(Viajes V)
        {
            try
            {
                IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
                viaje.AltaViaje(V);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void BajaViaje(Viajes V)
        {
            try
            {
                IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
                viaje.BajaViaje(V);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public void ModificarViaje(Viajes V)
        {
            try
            {
                IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
                viaje.ModificarViaje(V);
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public Viajes BuscarViaje(int numero)
        {
            try
            {
                IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
                return (viaje.BuscarViaje(numero));
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        [WebMethod]
        public List<Viajes> ListarViajes()
        {
            try
            {
                IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
                return (viaje.ListarViajes());
            }
            catch (Exception ex)
            {
                XmlDocument _undoc = new XmlDocument();
                XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
                _nodoDetalle.InnerText = ex.Message;

                _NodoError.AppendChild(_nodoDetalle);

                SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

                throw _MiEx;
            }
        }

        //[WebMethod]
        //public List<Viajes> ListarViajesTodos()
        //{
        //    try
        //    {
        //        IlogicaViajes viaje = FabricaLogica.GetLogicaViajes();
        //        return (viaje.ListarViajesTodos());
        //    }

        //    catch (Exception ex)
        //    {
        //        XmlDocument _undoc = new XmlDocument();
        //        XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

        //        XmlNode _nodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
        //        _nodoDetalle.InnerText = ex.Message;

        //        _NodoError.AppendChild(_nodoDetalle);

        //        SoapException _MiEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);

        //        throw _MiEx;
        //    }
        //}

        [WebMethod]
        public string Estadisticas()
        {
            try
            {
                IlogicaViajes FLogica = FabricaLogica.GetLogicaViajes();
                List<Viajes> lista = FLogica.ListarViajesTodos();
                XmlDocument xmldoc = new XmlDocument();

                xmldoc.LoadXml("<lista></lista>");

                foreach (Viajes v in lista)
                {
                    XmlNode nodoViaje = xmldoc.CreateNode(XmlNodeType.Element, "Viaje", "");

                    XmlNode nodoNumero = xmldoc.CreateNode(XmlNodeType.Element, "Número", "");
                    nodoNumero.InnerXml = v.numero.ToString();
                    nodoViaje.AppendChild(nodoNumero);

                    XmlNode nodoCiudadDestino = xmldoc.CreateNode(XmlNodeType.Element, "CiudadDestino", "");
                    nodoCiudadDestino.InnerXml = v.t.ciudad;
                    nodoViaje.AppendChild(nodoCiudadDestino);

                    XmlNode nodoPaisDestino = xmldoc.CreateNode(XmlNodeType.Element, "PaisDestino", "");
                    nodoPaisDestino.InnerXml = v.t.pais;
                    nodoViaje.AppendChild(nodoPaisDestino);

                    XmlNode nodoCompania = xmldoc.CreateNode(XmlNodeType.Element, "Compania", "");
                    nodoCompania.InnerXml = v.c.nombre;
                    nodoViaje.AppendChild(nodoCompania);

                    XmlNode nodoFechaPartida = xmldoc.CreateNode(XmlNodeType.Element, "FechaPartida", "");
                    nodoFechaPartida.InnerXml = v.partida.ToString();
                    nodoViaje.AppendChild(nodoFechaPartida);

                    xmldoc.DocumentElement.AppendChild(nodoViaje);
                }
                return (xmldoc.OuterXml);
            }
            catch (Exception ex)
            {
                XmlDocument unDoc = new System.Xml.XmlDocument();
                XmlNode noddoError = unDoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

                XmlNode nodeDetalle = unDoc.CreateNode(XmlNodeType.Element, "Error", "");
                nodeDetalle.InnerText = ex.Message;


                noddoError.AppendChild(nodeDetalle);

                SoapException miEx = new SoapException(ex.Message, SoapException.ClientFaultCode, Context.Request.Url.AbsolutePath, noddoError);

                throw miEx;
            }
        }

        #endregion



        [WebMethod]
        public Internacionales DeclaroVInternacional(Internacionales I) { return I; }

        [WebMethod]
        public Nacionales DeclaroVNacional(Nacionales N) { return N; }
    }
}
