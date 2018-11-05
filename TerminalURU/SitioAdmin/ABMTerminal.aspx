<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMTerminal.aspx.cs" MasterPageFile="~/MasterAdmin.master" Inherits="ABMTerminal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <title>ABM Terminal</title>
    <style type="text/css">
       
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Panel ID="Panel1" runat="server" CssClass="forms">
            <table class="style1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblABM" runat="server" Text="ABM Terminal"></asp:Label>
                    </td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblNom" runat="server" Text="Ingrese código de terminal"></asp:Label>
                    </td>
                    <td class="style12">
                        <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                            Text="Buscar" CssClass="Botones" />
                    </td>
                    <td>
                        <asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" Text="Eliminar" 
                            Enabled="False" CssClass="Botones" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="Botones" 
                            onclick="btnCancelar_Click" Text="Cancelar" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:Label ID="lblInfo" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    <asp:Panel ID="Panel2" runat="server" CssClass="forms" Enabled="False">
        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="lblTitulo0" runat="server"></asp:Label>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblCiudad" runat="server">Ciudad</asp:Label>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblPais" runat="server">País</asp:Label>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblFacilidades" runat="server">Facilidades</asp:Label>
                </td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:TextBox ID="txtFacilidad" runat="server"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Height="26px" 
                        onclick="btnAgregar_Click" CssClass="Botones" />
                </td>
                <td class="style11">
                    <asp:ListBox ID="lbFacilidades" runat="server" Height="162px" Width="270px"></asp:ListBox>
                </td>
                <td class="style5">
                    <asp:Button ID="btnEliminar" runat="server" onclick="btnEliminar_Click" 
                        Text="Eliminar" CssClass="Botones" />
                </td>
            </tr>
            <tr>
                <td class="style6">
                </td>
                <td class="style10">
                    <asp:Button ID="btnRegistrar" runat="server" onclick="btnRegistrar_Click" 
                        Text="Registrar" CssClass="Botones" />
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                        Text="Modificar" CssClass="Botones" />
                </td>
                <td class="style7">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>