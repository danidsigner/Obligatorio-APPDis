<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ABMViajesInternacionales.aspx.cs" Inherits="ABMViajesInternacionales" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>ABM Viajes Nacionales</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 153px;
        }
        .style6
        {
            width: 149px;
        }
        .style8
        {
        }
        .style13
        {
            width: 199px;
        }
        .style14
        {
            width: 51px;
        }
        .style15
        {
            width: 90px;
        }
        .style16
        {
            height: 30px;
            width: 346px;
        }
        .style17
        {
            height: 30px;
            width: 351px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
    
        <asp:Panel ID="Panel1" runat="server" CssClass="forms">
            <table class="style1">
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblTitulo" runat="server" Text="Viaje Internacional"></asp:Label>
                    </td>
                    <td class="style8" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Label ID="lblNumeroV" runat="server" Text="Número de viaje"></asp:Label>
                    </td>
                    <td class="style8" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style8" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
                    </td>
                    <td class="style17">
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
                            onclick="BtnBuscar_Click" CssClass="Botones"/>
                    </td>
                    <td class="style17">
                        <asp:Button ID="btnCancelar" runat="server" CssClass="Botones" 
                            onclick="btnCancelar_Click" Text="Cancelar" />
                        <asp:Button ID="BtnEliminar" runat="server" CssClass="Botones" Enabled="False" 
                            onclick="BtnEliminar_Click" Text="Eliminar" />
                    </td>
                </tr>
                <tr>
                    <td class="style6">
                        &nbsp;</td>
                    <td class="style8" colspan="2">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    <asp:Panel ID="Panel2" runat="server" CssClass="forms" Enabled="False">
    <table class="style1">
        <tr>
            <td class="style13" colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Compania"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="Label7" runat="server" Text="Fecha y hora de Partida"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:TextBox ID="txtCompania" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                <cc1:FechaYHora ID="FechaYHora1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Destino"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Fecha y hora de Arribo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:TextBox ID="txtDestino" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                <cc1:FechaYHora ID="FechaYHora2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:Label ID="Label8" runat="server" Text="Asientos"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="Label9" runat="server" Text="Empleado"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:TextBox ID="txtAsiento" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtEmpleado" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:Label ID="Label10" runat="server" Text="Servicio abordo"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                <asp:RadioButtonList ID="rblSAbordo" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="True">Si</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Documentación"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" CssClass="Botones" />
            </td>
            <td class="style14">
                <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                    Text="Modificar" CssClass="Botones" />
            </td>
            <td class="style4">
                <asp:TextBox ID="txtDocumentacion" runat="server" Height="47px" 
                    TextMode="MultiLine" Width="202px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13" colspan="2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
        </asp:Panel>
</asp:Content>

