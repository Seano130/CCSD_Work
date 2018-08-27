<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Age.aspx.cs" Inherits="Age" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMsg" runat="server" Font-Size="XX-Large"></asp:Label>
        </div>
        <asp:Button ID="btnLogout" runat="server" Font-Bold="True" OnClick="btnLogout_Click" Text="Logout" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnSubtract" runat="server" Height="41px" OnClick="btnSubtract_Click" Text="-" Width="30px" />
        <asp:Button ID="btnAdd" runat="server" Height="41px" OnClick="btnAdd_Click" Text="+" Width="30px" />
    </form>
</body>
</html>
