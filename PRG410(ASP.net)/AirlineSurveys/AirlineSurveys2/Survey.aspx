<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="AirlineSurveys2.Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox runat="server" ID="FlightSelection"></asp:ListBox>

        Cleanliness&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_cleanliness" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Friendliness&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_friendly" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
       Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_noise" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Space&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_space" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Comfort&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_comfort" RepeatDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
       
        <div>
        </div>
    </form>
</body>
</html>
