<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualDelViaje.ascx.cs" Inherits="ConsultaIndividualDelViaje" %>
<style type="text/css">
    .style2
    {
        width: 290px;
    }
    .style5
    {
        width: 129px;
    }
    .style6
    {
        width: 387px;
    }
    .style7
    {
        width: 111px;
    }
    .style9
    {
        width: 544px;
    }
    .style10
    {
        width: 367px;
    }
    .style11
    {
        width: 393px;
    }
    .style12
    {
        width: 428px;
    }
    .style13
    {
        width: 647px;
    }
    .style14
    {
        width: 436px;
    }
    .style15
    {
        width: 409px;
    }
</style>
<link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
<div class="caja">
<table class="UControl" 
        style="font-family: 'Segoe UI Emoji'; background-color: #FFFFFF; border-style: solid; border-color: #000000">
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            <asp:Label ID="Label1" runat="server" Text="Datos del Viaje" Font-Size="18pt"></asp:Label>
        </td>
        <td class="style7">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnVolver" runat="server" onclick="btnVolver_Click" 
                Text="Volver" CssClass="Botones" />
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:Label ID="lblNumero" runat="server"></asp:Label>
        </td>
        <td class="style12">
            <asp:Label ID="lblPartida" runat="server"></asp:Label>
        </td>
        <td class="style13">
            <asp:Label ID="lblArribo" runat="server"></asp:Label>
        </td>
        <td class="style14">
            <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
        </td>
        <td class="style15">
            <asp:Label ID="lblCantAsientos" runat="server"></asp:Label>
        </td>
        <td class="style11">
            <asp:Label ID="lblParadas" runat="server"></asp:Label>
        </td>
        <td class="style7">
            <asp:Label ID="lblServAbordo" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblDocumentacion" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            <asp:Label ID="Label2" runat="server" Text="Datos de la Compañía" 
                Font-Size="18pt"></asp:Label>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </td>
        <td class="style9" colspan="2">
            <asp:Label ID="lblDireccion" runat="server"></asp:Label>
            </td>
        <td class="style10" colspan="2">
            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
        </td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            &nbsp;</td>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            &nbsp;</td>
        <td class="style6" colspan="4">
            <asp:Label ID="Label3" runat="server" Text="Datos de la Terminal" 
                Font-Size="18pt"></asp:Label>
        </td>
        <td class="style7">
            <asp:Label ID="Label4" runat="server" Text="Facilidades"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" colspan="2">
            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
        </td>
        <td class="style9" colspan="2">
            <asp:Label ID="lblCiudad" runat="server"></asp:Label>
            </td>
        <td class="style10" colspan="2">
            <asp:Label ID="lblPais" runat="server"></asp:Label>
        </td>
        <td class="style7">
            <asp:GridView ID="GDVFacilidades" runat="server">
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>

</div>