<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="YourProject.courses" %>

<!DOCTYPE html>
<html>
<head>
    <title>Courses</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/courses.css" rel="stylesheet" />
    <script src="js/courses.js" defer></script>
</head>
<body>
    <nav class="navbar">
        <ul>
            <li><a href="home.aspx">Home</a></li>
            <li><a href="profile.aspx">Profile</a></li>
            <li><a href="courses.aspx">Courses</a></li>
        </ul>
    </nav>
    <form id="form1" runat="server">
        <h1>Welcome to the Courses Page</h1>

        <div>
            <label for="DropDownList1">Select a Course:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>

        <div>
            <label for="lblCourseDescription">Course Description:</label>
            <asp:Label ID="lblCourseDescription" runat="server" Text="Select a course to view the description."></asp:Label>
        </div>

        <div>
            <asp:Button ID="btnEnroll" runat="server" Text="Enroll" OnClick="btnEnroll_Click" CssClass="btn" />
        </div>
    </form>
</body>
</html>