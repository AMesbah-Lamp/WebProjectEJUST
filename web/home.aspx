<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="YourProject.Home" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/home.css" rel="stylesheet" />
    <script src="js/home.js" defer></script>
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Background with animated shapes -->
        <div class="background">
            <div class="shape shape-1"></div>
            <div class="shape shape-2"></div>
            <div class="shape shape-3"></div>
        </div>

        <!-- Navbar at the top -->
        <nav class="navbar">
            <div class="navbar-container">
                <div class="navbar-brand">
                    <span>School-Platform</span>
                </div>
                <ul class="navbar-links">
                    <li><a href="home.aspx" class="nav-link">Home</a></li>
                    <li><a href="profile.aspx" class="nav-link">Profile</a></li>
                    <li><a href="courses.aspx" class="nav-link">Courses</a></li>
                    <li>
                        <!-- Logout button -->
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-button" OnClick="btnLogout_Click" />
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Main content -->
        <div class="main-content">
            <div class="glass-card">
                <h2>Welcome to Your School</h2>
                <asp:Label ID="lblWelcomeMessage" runat="server" CssClass="welcome-message"></asp:Label>
                <p>Here is Your Hub for Learning</p>
                <button class="cta-button">Explore Courses</button>
            </div>
        </div>
    </form>
</body>
</html>