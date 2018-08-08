<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tutorial.aspx.cs" Inherits="AirlineSurveys2.Tutorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListBox runat="server" ID="FlightSelection"></asp:ListBox>

        Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_cleanliness" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_friendly" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
       Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_noise" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_space" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        Noise&nbsp;<asp:RadioButtonList runat="server" SelectedIndexChange="HandleClick" ID="R_comfort" RepeadDirection="Horizontal" AutoPostBack="true"></asp:RadioButtonList>
        <asp:Button ID="Submit" runat="server" OnClick="Submit_Review" Text="Submit Review" />
        <div>
        </div>
    </form>
</body>
</html>
