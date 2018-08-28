<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Larger" Text="Welcome to the Wheel of Fortune!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblWelcome" runat="server" Text="Placeholder"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
            <br />
            <br />
            <asp:TextBox ID="tbHidden" runat="server" BackColor="#6699FF" Font-Size="Larger" Width="151px"></asp:TextBox>
&nbsp;<br />
            <br />
            <asp:Label ID="lblGuessChar" runat="server" Font-Size="Large" Text="Guess Character:    "></asp:Label>
            <asp:TextBox ID="tbGuessChar" runat="server" Width="24px"></asp:TextBox>
&nbsp;<asp:Button ID="btnGuess" runat="server" OnClick="btnGuess_Click" Text="Enter" />
            <br />
            <br />
            <asp:Label ID="lblTries" runat="server" Text="Guesses Remaining : "></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAlready" runat="server" Text="Already Attempted"></asp:Label>
            :
            <asp:TextBox ID="tbAlready" runat="server" ReadOnly="True" Width="213px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
