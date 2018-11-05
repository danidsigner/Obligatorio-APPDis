<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="ABMCompanias.aspx.cs" Inherits="ABMCompanias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<title>ABM Companias</title>

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

        .style15
        {
            width: 123px;
        }
        .style16
        {
            width: 232px;
        }
        .style17
        {
            width: 232px;
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
                    <asp:Label ID="lblNombre" runat="server" 
                        Text="Ingrese el nombre de la compania"></asp:Label>
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
                    <asp:TextBox ID="txtNombre" runat="server" 
                       ></asp:TextBox>
                </td>

                <td class="style5">
                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                        Text="Buscar" CssClass="Botones" />
                </td>
                <td class="style5">
                    <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                        Text="Eliminar" Visible="False" Enabled="False" CssClass="Botones" />
                </td>
                <td class="style5">
                    <asp:Button ID="btnCancelar" runat="server" CssClass="Botones" 
                        onclick="btnCancelar_Click" Text="Cancelar" />
                </td>
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
                        <asp:Label ID="lblDir" runat="server">Dirección</asp:Label>
                    </td>
                    <td class="style13">
                        &nbsp;</td>
                    <td class="style11">
                    </td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txtDir" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:Label ID="lblTel" runat="server">Teléfono</asp:Label>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:TextBox ID="txttel" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style15">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style16">
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="Botones" Enabled="False" 
                            onclick="btnAccion_Click" Text="Registrar" />
                    </td>
                    <td class="style15">
                        <asp:Button ID="btnModificarC" runat="server" CssClass="Botones" 
                            Enabled="False" onclick="btnModificarC_Click" Text="Modificar " />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
  
</asp:Content>

