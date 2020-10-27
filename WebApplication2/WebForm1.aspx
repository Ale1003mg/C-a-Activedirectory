<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 14px;
        }
        .auto-style2 {
            width: 1280px;
            height: 258px;
        }
        .auto-style4 {
            width: 284px;
        }
        .auto-style5 {
            width: 182px;
        }
        .auto-style6 {
            margin-left: 400px;
        }
    </style>
</head>
<body style="height: 188px">
    <br />
    <br />
    <h1 class="auto-style6"><label style="text-align:center">Prueba de Active Directory a C# </label></h1>
    <br />
    <br />
    <table class="auto-style2">
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style4">
                   <form id="form1" runat="server">
                        <div ">
                            <br />
                            <asp:Label ID="Label1"  runat="server" Text="Usuario">Usuario</asp:Label><br />
                             <asp:Label ID="Label3" runat="server" Text="intrucciones">Solo es el nombre no con el dominio</asp:Label><br />
                        <asp:TextBox ID="User" runat="server" Width="222px"></asp:TextBox><br />
                             <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label><br />
                        <asp:TextBox ID="PW" runat="server" Width="225px" TextMode="Password"></asp:TextBox><br />
                        <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" Width="232px" /><br /><br />
                            <asp:TextBox ID="permitido" runat="server" Width="228px" Enabled="False" Height="61px" TextMode="MultiLine"></asp:TextBox><br />

                        </div>
        
                    </form>

            </td>
            <td class="auto-style1"></td>
        </tr>
    </table>

 
</body>
</html>
