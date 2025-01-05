<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="YourProject.profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Profile</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/styles.css" rel="stylesheet" />
    <script src="js/scripts.js" defer></script>
</head>
<body>
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
            </ul>
        </div>
    </nav>

    <!-- Main content -->
    <form id="form1" runat="server">
        <div class="main-content">
            <div class="glass-card">
                <h1 class="text-center">Student Profile</h1>
                <hr class="divider" />

                <!-- Error/Success Message -->
                <asp:Label ID="lblMessage" runat="server" CssClass="alert-message" Visible="false"></asp:Label>

                <!-- Student Details Section -->
                <div class="card mb-4">
                    <div class="card-header">
                        <h3 class="card-title">Details</h3>
                    </div>
                    <div class="card-body">
                        <p><strong>Student ID:</strong> <asp:Label ID="lblStudentId" runat="server" Text=""></asp:Label></p>
                        <p><strong>Username:</strong> <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></p>
                    </div>
                </div>

                <!-- Enrolled Courses Section -->
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Enrolled Courses</h3>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="True" CssClass="grid-view">
                            <HeaderStyle CssClass="grid-header" />
                            <RowStyle CssClass="grid-row" />
                        </asp:GridView>
                    </div>
                </div>

                <!-- Logout Button -->
                <div class="text-center mt-4">
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-button" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>