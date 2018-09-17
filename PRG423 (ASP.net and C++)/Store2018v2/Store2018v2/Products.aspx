<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Display Products" />
            <br />
            <br />
            <asp:DropDownList ID="ddlProducts" runat="server">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
