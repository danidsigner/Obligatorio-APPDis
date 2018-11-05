<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
     <link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 390px;
        }
        .style3
        {
            width: 280px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" CssClass="Login">
        
       <table class="style1">
            <tr>
                <td class="style3" rowspan="2">
                    <asp:Image ID="Image1" runat="server" Height="108px" 
                        ImageUrl="~/Imagenes/logueo.png" Width="247px" />
                </td>
                <td class="style4">
                    <asp:Label ID="lblTitulo" runat="server" Text="Bienvenido" Font-Bold="True" 
                        Font-Size="20pt" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6"  align="right">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Cédula"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6"  align="right">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña" ></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>


                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                        onclick="btnIngresar_Click" CssClass="Botones" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
