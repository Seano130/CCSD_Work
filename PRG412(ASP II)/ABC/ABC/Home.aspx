<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </div>
        User:
        <asp:TextBox ID="tbUser" runat="server" Width="102px"></asp:TextBox>
        <br />
        Age: 
        <asp:TextBox ID="tbAge" runat="server" Width="106px"></asp:TextBox>
        <br />&nbsp;<br />
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="+" Width="22px" />
        <asp:Button ID="btnSubtract" runat="server" OnClick="btnSubtract_Click" Text="-" />
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Height="51px" OnClick="btnLogin_Click" Text="Login" Width="105px" />
        <asp:Button ID="btnLogout" runat="server" Height="51px" OnClick="btnLogout_Click" Text="Logout" Width="105px" />
        <br />
        <br />
        <asp:Button ID="btnReload" runat="server" OnClick="btnReload_Click" Text="Reload" />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
