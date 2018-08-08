<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="AirlineSurveys2.Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h1>Enter your survey</h1>
    <form id="form1" runat="server">

        <asp:ListBox ID="ListBox1" runat="server" CssClass="asp_Listbox">
        </asp:ListBox>

    <table runat="server" id="table">
<tr><td>Cleanliness</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_cleanliness" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList></td></tr>
        <tr><td>Friendliness</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_friendly" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList></td></tr>
        <tr><td>Noise</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_noise" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList></td></tr>
        <tr><td>Space</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_space" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList></td></tr>
        <tr><td>Comfort</td><td><asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_comfort" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList></td></tr>


    </table>

    <asp:RadioButton AutoPostBack
    <asp:Button ID="btnValidator" OnClick=""



        
        <div>
        </div>
    </form>
</body>
</html>
