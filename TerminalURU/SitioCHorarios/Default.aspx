<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ConsultaViajes" %>

<%@ Register assembly="Controles" namespace="Controles" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
    <title>Listado de viajes</title>

</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Panel ID="Panel1"  runat="server" 
            Width="100%">
            <table >
                <tr class="Encabezados">
                    <th class="Encabezados" colspan="7">
                        <asp:Label ID="Label2" runat="server" Text="Consulta de Viajes" 
                            Font-Size="18pt"></asp:Label>
                    </th>
                </tr>
                <tr class="Datos">
                    <th class="style13">
                        <asp:Label ID="Label3" runat="server" Text="Destinos"></asp:Label>
                    </th>
                    <th class="style15">
                        <asp:Label ID="Label4" runat="server" Text="Companias"></asp:Label>
                    </th>
                    <th class="style16" colspan="2">
                        <asp:Label ID="Label5" runat="server" Text="Rango de Fechas"></asp:Label>
                    </th>
                    <th class="style11">
                        &nbsp;</th>
                    <th class="Datos" colspan="2">
                        &nbsp;</th>
                </tr>
                <tr>
                    <td class="style13">
                        <asp:DropDownList ID="DDLDestino" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DDLDestino_SelectedIndexChanged">
                            <asp:ListItem>Todos</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    <td class="style15">
                        <asp:DropDownList ID="DDLCompania" runat="server" AutoPostBack="True">
                            <asp:ListItem>Todas</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style18">
                        <cc1:Dias ID="Dias1" runat="server">
                        </cc1:Dias>
                        <cc1:Meses ID="Meses1" runat="server">
                        </cc1:Meses>
                        <cc1:Años ID="Años1" runat="server">
                        </cc1:Años>
                    </td>
                    <td class="style6">
                        <cc1:Dias ID="Dias2" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </cc1:Dias>
                        <cc1:Meses ID="Meses2" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="Enero">Enero</asp:ListItem>
                            <asp:ListItem Value="Febrero">Febrero</asp:ListItem>
                            <asp:ListItem Value="Marzo">Marzo</asp:ListItem>
                            <asp:ListItem Value="Abril">Abril</asp:ListItem>
                            <asp:ListItem Value="Mayo">Mayo</asp:ListItem>
                            <asp:ListItem Value="Junio">Junio</asp:ListItem>
                            <asp:ListItem Value="Julio">Julio</asp:ListItem>
                            <asp:ListItem Value="Agosto">Agosto</asp:ListItem>
                            <asp:ListItem Value="Setiembre">Setiembre</asp:ListItem>
                            <asp:ListItem Value="Octubre">Octubre</asp:ListItem>
                            <asp:ListItem Value="Noviembre">Noviembre</asp:ListItem>
                            <asp:ListItem Value="Diciembre">Diciembre</asp:ListItem>
                        </cc1:Meses>
                        <cc1:Años ID="Años2" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True">2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                        </cc1:Años>
                    </td>
                    <td class="style11">
                        <asp:Button ID="btnFiltro" runat="server" onclick="btnFiltro_Click" 
                            Text="Filtrar" />
                    </td>
                    <td class="style17">
                        <asp:Button ID="bntLimpiarFiltros" runat="server" CssClass="Botones" 
                            onclick="bntLimpiarFiltros_Click" Text="Limpiar filtros" />
                    </td>
                    <td>
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
