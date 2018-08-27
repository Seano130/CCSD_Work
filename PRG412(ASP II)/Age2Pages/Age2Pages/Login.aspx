<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUser" runat="server" Text="User:"></asp:Label>
            <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAge" runat="server" Text="Age: "></asp:Label>
            <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
