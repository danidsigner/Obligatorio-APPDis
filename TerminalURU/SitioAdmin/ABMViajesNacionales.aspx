<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ABMViajesNacionales.aspx.cs" Inherits="ABMViajesNacionales" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>ABM Viajes Internacionales</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 30px;
        }
        .style3
        {
            width: 413px;
        }
        .style4
        {
            width: 153px;
        }
        .style5
        {
            height: 23px;
        }
    .style9
    {
        width: 302px;
    }
    .style10
    {
        width: 234px;
        height: 22px;
    }
    .style11
    {
        width: 263px;
        height: 22px;
    }
    .style13
    {
    }
    .style15
    {
        height: 23px;
        width: 130px;
    }
    .style16
    {
        height: 30px;
        width: 130px;
    }
        .style19
        {
            height: 30px;
            width: 69px;
        }
        .style21
        {
            height: 23px;
            width: 122px;
        }
        .style23
        {
        }
        .style24
        {
            width: 122px;
        }
        .style25
        {
            height: 30px;
            width: 33px;
        }
        .style26
        {
            width: 127px;
        }
        .style27
        {
            width: 153px;
        }
        .style29
        {
            width: 125px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" CssClass="forms">
            <table class="style1">
                <tr>
                    <td class="style23">
                        <asp:Label ID="lblTitulo" runat="server" Text="Viaje Nacional"></asp:Label>
                    </td>
                    <td class="style24" colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style23">
                        &nbsp;</td>
                    <td class="style24" colspan="2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style15">
                        <asp:Label ID="lblNumeroV" runat="server" Text="Número de Viaje"></asp:Label>
                        </td>
                    <td class="style21" colspan="2">
                        </td>
                    <td class="style5">
                        </td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
                    </td>
                    <td class="style19">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                            onclick="btnBuscar_Click" CssClass="Botones" />
                    </td>
                    <td class="style25">
                        &nbsp;</td>
                    <td class="style2">
                        <asp:Button ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" 
                            Text="Eliminar" Visible="False" CssClass="Botones" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                            onclick="btnCancelar_Click" CssClass="Botones" />
                    </td>
                </tr>
                <tr>
                    <td class="style23" colspan="4">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    <asp:Panel ID="Panel2" runat="server" Visible="False" CssClass="forms" 
        Enabled="False">
    
    <table class="style1">
        <tr>
            <td class="style29">
                <asp:Label ID="Label4" runat="server" Text="Compania"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Fecha y hora de Partida"></asp:Label>
               
            </td>
        </tr>
    </table>
        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtCompania" runat="server"></asp:TextBox>
                </td>
                <td class="style9">
                    <cc1:FechaYHora ID="FechaYHora3" runat="server" />
                </td>
                <td class="style13" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label5" runat="server" Text="Destino"></asp:Label>
                </td>
                <td class="style11" colspan="3">
                    <asp:Label ID="Label7" runat="server" Text="Fecha y hora de Arribo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtDestino" runat="server"></asp:TextBox>
                </td>
                <td class="style4" colspan="3">
                    <cc1:FechaYHora ID="FechaYHora4" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label8" runat="server" Text="Asientos"></asp:Label>
                </td>
                <td class="style4" colspan="3">
                    <asp:Label ID="Label9" runat="server" Text="Empleado"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtAsiento" runat="server"></asp:TextBox>
                   
                </td>
                <td class="style4" colspan="3">
                    <asp:TextBox ID="txtEmpleado" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    <asp:Label ID="Label10" runat="server" Text="Cantidas de paradas"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    <asp:TextBox ID="txtParadas" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style26" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Registrar" 
                        onclick="btnAgregar_Click" CssClass="Botones" />
                </td>
                <td class="style27">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        onclick="btnModificar_Click" CssClass="Botones" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4" colspan="3">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

