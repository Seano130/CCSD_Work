<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="AirlineSurveys2.Tutorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <tr><td>Cleanliness</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_cleanliness" RepeadDirection="Horizontal" AutoPostBack="true"</asp:RadioButtonList></td></tr>
        <tr><td>Friendliness</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_friendly" RepeadDirection="Horizontal" AutoPostBack="true"</asp:RadioButtonList></td></tr>
        <tr><td>Noise</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_noise" RepeadDirection="Horizontal" AutoPostBack="true"</asp:RadioButtonList></td></tr>
        <tr><td>Space</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_space" RepeadDirection="Horizontal" AutoPostBack="true"</asp:RadioButtonList></td></tr>
        <tr><td>Comfort</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_comfort" RepeadDirection="Horizontal" AutoPostBack="true"</asp:RadioButtonList></td></tr>
        <div>
        </div>
    </form>
</body>
</html>
