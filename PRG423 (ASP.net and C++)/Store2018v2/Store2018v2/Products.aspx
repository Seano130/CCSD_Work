<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="Products for Sale"></asp:Label>
            <br />
            <br />
            <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
