using System;
using System.Data;
using System.Data.SqlClient;

namespace YourProject
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["StudentId"] != null)
                {
                    int studentId = Convert.ToInt32(Session["StudentId"]);
                    LoadStudentDetails(studentId); // Load student details
                    LoadEnrolledCourses(studentId); // Load enrolled courses
                }
                else
                {
                    Response.Redirect("default.aspx"); // Redirect to login page if not logged in
                }
            }
        }

        // Method to load student details (e.g., ID and username)
        private void LoadStudentDetails(int studentId)
        {
            string query = "SELECT id, username FROM students WHERE id = @studentId";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display student details on the page
                        lblStudentId.Text = reader["id"].ToString();
                        lblUsername.Text = reader["username"].ToString();
                    }
                    else
                    {
                        // If no data is found, display "Not Found"
                        lblStudentId.Text = "Not Found";
                        lblUsername.Text = "Not Found";
                    }
                }
                catch (Exception ex)
                {
                    // Log the error and display a message
                    System.Diagnostics.Debug.WriteLine($"Error loading student details: {ex.Message}");
                    lblMessage.Text = "An error occurred while loading student details.";
                    lblMessage.Visible = true; // Show the error message
                }
            }
        }

        // Method to load the courses that the student is enrolled in
        private void LoadEnrolledCourses(int studentId)
        {
            string query = @"
                SELECT c.Course 
                FROM courses c
                INNER JOIN student_courses sc ON c.id = sc.course_id
                WHERE sc.student_id = @studentId";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the data to the GridView
                    gvCourses.DataSource = dt;
                    gvCourses.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the error and display a message
                    System.Diagnostics.Debug.WriteLine($"Error loading enrolled courses: {ex.Message}");
                    lblMessage.Text = "An error occurred while loading enrolled courses.";
                    lblMessage.Visible = true; // Show the error message
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