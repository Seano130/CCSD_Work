<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Size="Larger" Text="Please Enter Your Name: "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="tbUser" runat="server" Height="17px" Width="231px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Label ID="lblDifficulty" runat="server" Text="Difficulty: "></asp:Label>
&nbsp;
            <asp:DropDownList ID="ddlDiff" runat="server" AutoPostBack="True" Height="20px" Width="159px">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </div>
    </form>
</body>
</html>
