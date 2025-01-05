using System;

namespace YourProject
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect to login page if session is not set
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    // Debugging: Log the session username
                    System.Diagnostics.Debug.WriteLine($"Session Username on Home Page: {Session["Username"]}");

                    // Display the welcome message
                    lblWelcomeMessage.Text = $"Welcome, {Session["Username"].ToString()}!";
                }
            }
        }

        // Logout button click event
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear(); // Clears all session variables
            Session.Abandon(); // Abandons the current session

            // Redirect to the login page
            Response.Redirect("default.aspx");
        }
    }
}