<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualDeViaje.aspx.cs" Inherits="ConsultaIndividualDeViaje" %>

<%@ Register src="ConsultaIndividualDelViaje.ascx" tagname="ConsultaIndividualDelViaje" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta individual de viaje</title>
     <link href="Estilos/css/MisEstilos.css" rel ="Stylesheet" type ="text/css" />
</head>
<body>
    <form id="form1" class="Forms" runat="server">
    <div>
    
        <uc1:ConsultaIndividualDelViaje ID="ConsultaIndividualDelViaje1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
