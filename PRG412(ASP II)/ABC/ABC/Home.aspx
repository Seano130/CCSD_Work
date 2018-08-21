<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblTitle" runat="server" Text="User"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Height="51px" OnClick="btnLogin_Click" Text="Login" Width="105px" />
        <br />
        <br />
        <asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Text="Reload" />
        <br />
    </form>
</body>
</html>
