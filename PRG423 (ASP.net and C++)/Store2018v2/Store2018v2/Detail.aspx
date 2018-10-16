<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPart" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Part #"></asp:Label>
            <br />
            <br />
            <asp:Image ID="imgProduct" runat="server" Height="246px" Width="348px" />
            <br />
            <br />
            <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
            <br />
            <asp:Label ID="lblMfr" runat="server" Text="Manufacturer"></asp:Label>
            <br />
            <asp:Label ID="lblModel" runat="server" Text="Model Number"></asp:Label>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            <br />
            <asp:TextBox ID="tbDesc" runat="server" Height="63px" TextMode="MultiLine" Width="334px">Description goes here</asp:TextBox>
            <br />
            <asp:Button ID="btnProducts" runat="server" Text="Back to Products..." />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblQty" runat="server" Text="Qty:"></asp:Label>
            <asp:TextBox ID="tbQty" runat="server" Width="41px"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" />
        </div>
    </form>
</body>
</html>
