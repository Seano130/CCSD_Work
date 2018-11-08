<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MgmtCreate.aspx.cs" Inherits="MgmtCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div runat ="server" id="divMain">

            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#00CC00" Text="Secret Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnMode" runat="server" OnClick="btnMode_Click" Text="Put current Mode here" />
            <br />
            <br />
            <br />
            <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbID" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlID_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="lblMfr" runat="server" Text="Manufacturer"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbMfr" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbModel" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPart" runat="server" Text="Part"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPart" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbDesc" runat="server" Height="72px" Width="159px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:FileUpload ID="fuImage" runat="server" Width="665px" />
            <asp:Button ID="btnPreview" runat="server" Text="Preview..." OnClick="btnPreview_Click" />
            <br />
            <br />
            <asp:Label ID="lblPreview" runat="server"></asp:Label>
            <br />
            <asp:Image ID="imgPreview" runat="server" Height="452px" Width="772px" />
        </div>
        <br />
        <asp:Label ID="lblMsg" runat="server" Font-Size="Large" ForeColor="Red" Text="C++ Sux"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnAddProduct" runat="server" OnClick="btnAddProduct_Click" Text="Add Product" />
        <asp:Button ID="btnUpdateProduct" runat="server" Text="Update..." OnClick="btnUpdateProduct_Click" />
    </form>
</body>
</html>
