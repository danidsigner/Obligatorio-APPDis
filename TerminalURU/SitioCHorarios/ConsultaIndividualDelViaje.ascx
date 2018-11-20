<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualDelViaje.ascx.cs" Inherits="ConsultaIndividualDelViaje" %>
<style type="text/css">
    .style6
    {
        width: 387px;
    }
    .style9
    {
        width: 544px;
    }
    .style10
    {
    }
    .style13
    {
        width: 10%;
    }
    .style14
    {
    }
    .style21
    {
    }
    .style22
    {
        width: 11%;
    }
    .style23
    {
        width: 27%;
    }
    .style31
    {
        width: 11%;
        height: 10px;
    }
    .style32
    {
        width: 27%;
        height: 10px;
    }
    .style33
    {
        width: 107%;
    }
    .style34
    {
        width: 947px;
    }
        
    .style35
    {
        width: 268435744px;
    }
        
    .style36
    {
        width: 106px;
    }
        
    .style38
    {
        width: 268435488px;
    }
        
    .style40
    {
        width: 16%;
    }
    .style41
    {
        width: 16%;
        height: 10px;
    }
        
    </style>
<link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
<%--<div id="Contenedor">--%>
<table >
       <%-- <thead>--%>
    <tr class="Encabezados">
        <th class="Encabezados">
            &nbsp;</th>
        <th class="Encabezados" colspan="20">
            <asp:Label ID="Label1" runat="server" Text="Datos del Viaje" Font-Size="18pt"></asp:Label>
        </th>
        <th class="Encabezados">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </th>
        <th class="Encabezados">
            <asp:Button ID="btnVolver" runat="server" onclick="btnVolver_Click" 
                Text="Volver" CssClass="Botones" />
        </th>
       
    </tr>
      <%--</thead>--%>
    
     
    <tr class="Datos">
    
        <th class="style40">
            Numero</th>
        <th class="style6" colspan="3">
            Empleado</th>
        <th colspan="6">
            Asientos</th>
        <th colspan="2" >
            Partida</th>
        <th >
            Arribo</th>
        <th class="style35" colspan="2" >
            Cantidad De Paradas</th>
        <th class="style33" colspan="3">
            Servicio Abordo</th>
        <th class="style6" colspan="3">
            Documentacion</th>
        <th class="style22">
            &nbsp;</th>
        <th class="style23">
            &nbsp;</th>
        
    </tr>
  
    <tr style="width:130%; height:150%;" >
        <td class="style40">
            <asp:Label ID="lblNumero" runat="server"></asp:Label>
        </td>
        <td class="style13">
            <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
        </td>
        <td class="style14" colspan="8">
            <asp:Label ID="lblCantAsientos" runat="server"></asp:Label>
        </td>
        <td colspan="2">
            <asp:Label ID="lblPartida" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblArribo" runat="server"></asp:Label>
        </td>
        <td class="style35" colspan="2">
            <asp:Label ID="lblParadas" runat="server"></asp:Label>
        </td>
        <td colspan="4" class="style34">
            <asp:Label ID="lblServAbordo" runat="server"></asp:Label>
        </td>
        <td colspan="2">
            <asp:Label ID="lblDocumentacion" runat="server"></asp:Label>
        </td>
        <td class="style22">
            &nbsp;</td>
        <td class="style23">
            &nbsp;</td>
    </tr>
    <tr class="Encabezados">
        <th class="style41">
            </th>
        <th class="Encabezados" colspan="20">
            <asp:Label ID="Label2" runat="server" Text="Datos de la Compañía" 
                Font-Size="18pt"></asp:Label>
        </th>
        <th class="style31">
            </th>
        <th class="style32">
            </th>
    </tr>
    <tr class="Datos">
        <th class="style40">
            &nbsp;</th>
        <th class="style6" colspan="4">
            &nbsp;</th>
        <th class="style6" colspan="4">
            &nbsp;</th>
        <th class="style6" colspan="2">
            Nombre</th>
        <th class="style6" colspan="2">
            Direcion</th>
        <th class="style38">
            Telefono&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </th>
        <th class="style6">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
        <th class="style6">
            &nbsp;</th>
        <th class="style6" colspan="2">
            &nbsp;</th>
        <th class="style6" colspan="5">
            &nbsp;</th>
    </tr>
    <tr>
        <td class="style40">
            &nbsp;</td>
        <td class="style9" colspan="6">
            &nbsp;</td>
        <td class="style10" colspan="3">
            &nbsp;</td>
        <td class="style10">
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </td>
        <td class="style10" colspan="2">
            <asp:Label ID="lblDireccion" runat="server"></asp:Label>
        </td>
        <td class="style38">
            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
        </td>
        <td class="style10">
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
        <td class="style10">
            &nbsp;</td>
        <td class="style10" colspan="2">
            &nbsp;</td>
        <td class="style10" colspan="3">
            &nbsp;</td>
        <td class="style22">
            &nbsp;</td>
    </tr>
    <tr class="Encabezados">
        <th class="style40">
            &nbsp;</th>
        <th class="Encabezados" colspan="20">
            <asp:Label ID="Label3" runat="server" Text="Datos de la Terminal" 
                Font-Size="18pt" style=""></asp:Label>
        </th>
        <th class="Encabezados">
            &nbsp;</th>
        <th class="Encabezados">
            &nbsp;</th>
    </tr>
    <tr class="Datos">
        <th class="style21" colspan="3">
            &nbsp;</th>
        <th class="style21" colspan="3">
            &nbsp;</th>
        <th class="style21" colspan="2">
            Codigo</th>
        <th class="style36">
            &nbsp;</th>
        <th class="style21" colspan="2">
            Ciudad</th>
        <th class="style21" colspan="3">
            Pais</th>
        <th class="style21" colspan="3">
            Facilidades</th>
        <th class="style21" colspan="3">
            &nbsp;</th>
        <th class="style21" colspan="3">
            &nbsp;</th>
    </tr>
    <tr >
        <td class="style21" colspan="3">
            &nbsp;</td>
        <td class="style21" colspan="3">
            &nbsp;</td>
        <td class="style21" colspan="2">
            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
        </td>
        <td class="style36">
            &nbsp;</td>
        <td class="style21" colspan="2">
            <asp:Label ID="lblCiudad" runat="server"></asp:Label>
        </td>
        <td class="style21" colspan="3">
            <asp:Label ID="lblPais" runat="server"></asp:Label>
        </td>
        <td class="style21" colspan="3">
            <asp:GridView ID="GDVFacilidades" runat="server" BorderStyle="None" 
                BorderWidth="0px" GridLines="None" >
            </asp:GridView>
        </td>
        <td class="style21" colspan="3">
            &nbsp;</td>
        <td class="style21" colspan="3">
            &nbsp;</td>
    </tr>
    </table>

<%--</div>--%>