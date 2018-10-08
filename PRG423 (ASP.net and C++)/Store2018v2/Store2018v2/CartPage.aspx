<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CartPage.aspx.cs" Inherits="CartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Size="X-Large" Text="Shopping Cart"></asp:Label>
            <br />
            <br />
            <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:Label ID="lblTot" runat="server" Text="Total : $"></asp:Label>
            <asp:Label ID="lblTotValue" runat="server" Text="0.0"></asp:Label>
        </div>
    </form>
</body>
</html>
