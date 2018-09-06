<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            User:
            <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:
            <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" />
        </div>
    </form>
</body>
</html>
