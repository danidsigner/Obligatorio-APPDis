<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMEmpleado.aspx.cs" MasterPageFile="~/MasterAdmin.master" Inherits="ABMEmpleado" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>ABM Empleado</title>
    <style type="text/css">
        .style5
        {
            height: 30px;
        }
        .style7
        {
            height: 30px;
            width: 237px;
        }
        .style8
        {
            width: 237px;
        }
        .style10
        {
            width: 317px;
            height: 23px;
        }
        .style11
        {
            height: 23px;
        }
        .style13
        {
            height: 23px;
            width: 123px;
        }
        .style14
        {
            width: 317px;
        }
        .style15
        {
            width: 123px;
        }
        .style16
        {
            width: 172px;
        }
        .style17
        {
            width: 172px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="285px" CssClass="forms">
        <table class="style1" style="height: 219px">
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="lblCI" runat="server" 
                        Text="Ingrese Cédula"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                        onclick="btnBuscar_Click" CssClass="Botones" />
                </td>
                <td class="style5">
                    <asp:Button ID="btnCancelar" runat="server" CssClass="Botones" 
                        onclick="btnCancelar_Click" Text="Cancelar" />
                </td>
                <td class="style5">
                    <asp:Button ID="btnEliminar" runat="server" CssClass="Botones" Enabled="False" 
                        onclick="btnEliminar_Click" Text="Eliminar" />
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
          </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="forms">
            <table class="style1">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        &nbsp;</td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style17">
                        <asp:Label ID="lblN" runat="server">Nombre</asp:Label>
                    </td>
                    <td class="style13">
                        &nbsp;</td>
                    <td class="style11">
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txtNom" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:Label ID="lblP" runat="server">Contraseña</asp:Label>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txtPass" runat="server" Enabled="False" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:Button ID="btnAlta" runat="server" CssClass="Botones" Enabled="False" 
                            onclick="btnAlta_Click" Text="Registrar" />
                    </td>
                    <td class="style15">
                        <asp:Button ID="btnModificarC" runat="server" onclick="btnModificarC_Click" 
                            Text="Modificar " Enabled="False" CssClass="Botones" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
  
</asp:Content>

