<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="YourProject.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Login - Edu-Platform</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/login.js" defer></script>
</head>
<body>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>
    <form id="form1" runat="server" class="form-container">
        <h1>Welcome to Edu-Platform</h1>
        <div class="form-toggle">
            <button type="button" id="login-toggle" class="active">Login</button>
            <button type="button" id="signup-toggle">Sign Up</button>
        </div>

        <div class="form-wrapper">
            <div class="form login-form active">
                <asp:Label ID="lblUsername" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" placeholder="Username" />
                <asp:Label ID="lblPassword" runat="server" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" placeholder="Password" />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
            </div>

            <div class="form signup-form">
                <asp:Label ID="lblSignUpUsername" runat="server" />
                <asp:TextBox ID="txtSignUpUsername" runat="server" CssClass="input-field" placeholder="Username" />
                <asp:Label ID="lblSignUpPassword" runat="server" />
                <asp:TextBox ID="txtSignUpPassword" runat="server" TextMode="Password" CssClass="input-field" placeholder="Password" />
                <asp:Label ID="lblConfirmPassword" runat="server" />
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="input-field" placeholder="Confirm Your Password" />
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="btn" />
                <asp:Label ID="lblSignUpMessage" runat="server" ForeColor="Red" />
            </div>
        </div>
    </form>
</body>
</html>