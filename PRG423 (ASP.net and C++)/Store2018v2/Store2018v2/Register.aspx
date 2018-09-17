<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Register New User"></asp:Label>
            <br />
            <br />
            <asp:ValidationSummary ID="vSummary" runat="server" />
            <br />
            <br />
            Username:<asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vUser" runat="server" ControlToValidate="tbUser" ErrorMessage="Must have Username">Username Required</asp:RequiredFieldValidator>
            <br />
            Password:<asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword" ErrorMessage="Password required"></asp:RequiredFieldValidator>
            <br />
            Confirm:<asp:TextBox ID="tbConfirm" runat="server" Width="130px" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirm" ErrorMessage="Must Match" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            First Name:<asp:TextBox ID="tbFirst" runat="server"></asp:TextBox>
            <br />
            Last Name:<asp:TextBox ID="tbLast" runat="server"></asp:TextBox>
            <br />
            Email:<asp:TextBox ID="tbEmail" runat="server" Width="152px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Proper Formatted Email required" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Requires Formatted Email Address</asp:RegularExpressionValidator>
            <br />
            Age:<asp:TextBox ID="tbAge" runat="server" Width="160px"></asp:TextBox>
            <br />
            <br />
            Gender:
            <br />
            <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
            <br />
            <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            <br />
            <asp:RadioButton ID="rbUnknown" runat="server" GroupName="Gender" Text="Unknown" />
            <br />
            <br />
            <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Font-Size="X-Large" OnClick="btnRegister_Click" Text="Register" />
            <br />
        </div>
    </form>
</body>
</html>
