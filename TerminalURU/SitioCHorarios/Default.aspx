<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ConsultaViajes" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
    <title>Listado de viajes</title>
    <style type="text/css">
        .style1
        {
            width: 112%;
        }
        .style2
        {
        }
        .style3
        {
            width: 280px;
            }
        .style5
        {
        }
        .style6
        {
            width: 161px;
        }
        .style9
        {
        }
        .style11
        {
            width: 123px;
        }
        .Forms
        {}
        .style13
        {
            width: 423px;
        }
        .style14
        {
            width: 110px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Panel ID="Panel1"  runat="server" 
            Width="100%">
            <table >
                <tr class="Encabezados">
                    <th class="Encabezados" colspan="4">
                        <asp:Label ID="Label2" runat="server" Text="Consulta de Viajes" 
                            Font-Size="18pt"></asp:Label>
                    </th>
                </tr>
                <tr class="Datos">
                    <th class="style9">
                        &nbsp;</th>
                    <th class="style5">
                        <asp:Label ID="Label3" runat="server" Text="Destinos"></asp:Label>
                    </th>
                    <th class="style11">
                        <asp:Label ID="Label4" runat="server" Text="Companias"></asp:Label>
                    </th>
                    <th class="Datos">
                        <asp:Label ID="Label5" runat="server" Text="Partida"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td class="style3">
                        </td>
                    <td class="style6">
                        <asp:DropDownList ID="DDLDestino" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLDestino_SelectedIndexChanged">
                            <asp:ListItem>Todos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="DDLCompania" runat="server" 
                            AutoPostBack="True">
                            <asp:ListItem>Todas</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <cc1:Dias ID="Dias1" runat="server">
                            
                        </cc1:Dias>
                        <cc1:Meses ID="Meses1" runat="server">
                           
                        </cc1:Meses>
                        <cc1:Años ID="Años1" runat="server">
                            
                        </cc1:Años>
                        <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
                            Text="Filtrar" />
                        <asp:Button ID="bntLimpiarFiltros" runat="server" CssClass="Botones" 
                            onclick="bntLimpiarFiltros_Click" Text="Limpiar filtros" />
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                   <%-- <td colspan="4" width="100%">--%>
                        <asp:Repeater ID="RepeaterCViajes" runat="server" 
                            onitemcommand="RepeaterCViajes_ItemCommand">
                            
                            <HeaderTemplate>                     
                                    <tr class = "Datos">
                                        <th>Numero</th>
                                        <th>Compania</th>
                                        <th>Partida</th>
                                        <th>Arribo</th>
                                        <th>Destino</th>
                                        <th>Seleccionar</th>
                                    </tr>         
                            </HeaderTemplate>
                            
                            <ItemTemplate>
                                    <tr>
                                    <br />
                                        <td>
                                            <asp:Label ID="lblNumero" runat="server" Text ='<%#Bind("Numero") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCompania" runat="server" Text ='<%#Bind("C.nombre") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPartida" runat="server" Text ='<%#Bind("Partida") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblArribo" runat="server" Text ='<%#Bind("Arribo") %>'></asp:Label>
                                        </td>
                                        <td>
                                           <asp:Label ID="lblDestino" runat="server" Text ='<%#Bind("T.codigo") %>'></asp:Label>
                                        </td>
                                        <td>
                                           <asp:Button ID="btnSeleccionar" runat="server" CommandName="Seleccionar"  CssClass="Botones" style="text-align:center" Text="Seleccionar"></asp:Button>
                                            <br />
                                        </td>
                                    </tr>
                            </ItemTemplate>


                        </asp:Repeater>
                   <%-- </td>--%>
                </tr>
            </table>
        </asp:Panel>

    
    </form>
</body>
</html>
