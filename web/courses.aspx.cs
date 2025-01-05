using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace YourProject
{
    public partial class courses : System.Web.UI.Page
    {
        // Check if user is logged in
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                // Redirect to login page if the user is not logged in
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindCourses();
            }
        }

        // Bind courses to the dropdown list
        private void BindCourses()
        {
            string query = "SELECT id, Course FROM courses";  // Fetching course id and title
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DropDownList1.DataSource = reader;
                DropDownList1.DataTextField = "Course";  // Display course title
                DropDownList1.DataValueField = "id";   // Value will be course id
                DropDownList1.DataBind();
            }

            // Add a default option
            DropDownList1.Items.Insert(0, new ListItem("Select a course", ""));
        }

        // When a new course is selected, show its description
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourseId = DropDownList1.SelectedValue;
            if (!string.IsNullOrEmpty(selectedCourseId))
            {
                string courseDescription = GetCourseDescription(selectedCourseId);
                lblCourseDescription.Text = courseDescription;  // Display description
            }
            else
            {
                lblCourseDescription.Text = "";  // Clear description if no course is selected
            }
        }

        // Function to get course description from the database
        private string GetCourseDescription(string courseId)
        {
            string description = string.Empty;
            string query = "SELECT description FROM courses WHERE id = @course_id";  // Query to fetch description

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@course_id", courseId);  // Pass course id as a parameter

                conn.Open();
                object result = cmd.ExecuteScalar();  // Get single value (description)

                if (result != null)
                {
                    description = result.ToString();
                }
            }

            return description;
        }

        // Button click event to enroll the student in the selected course
        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            string selectedCourseId = DropDownList1.SelectedValue;

            if (!string.IsNullOrEmpty(selectedCourseId))
            {
                string username = Session["Username"].ToString();  // Get logged-in user's username

                // Get student ID based on username
                int studentId = GetStudentId(username);

                if (studentId > 0)
                {
                    // Enroll the student in the course
                    EnrollStudentInCourse(studentId, selectedCourseId);
                }
                else
                {
                    lblCourseDescription.Text = "Error: Student not found.";
                }
            }
            else
            {
                lblCourseDescription.Text = "Please select a course to enroll.";
            }
        }

        // Function to get the student ID based on the username
        private int GetStudentId(string username)
        {
            int studentId = 0;
            string query = "SELECT id FROM students WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    studentId = Convert.ToInt32(result);
                }
            }

            return studentId;
        }

        // Function to enroll the student in the selected course
        private void EnrollStudentInCourse(int studentId, string courseId)
        {
            // First, check if the student is already enrolled in the course
            if (IsStudentEnrolledInCourse(studentId, courseId))
            {
                lblCourseDescription.Text = "You are already enrolled in this course.";
                return;
            }

            string query = "INSERT INTO student_courses (student_id, course_id) VALUES (@student_id, @course_id)";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_id", studentId);  // Pass student id
                cmd.Parameters.AddWithValue("@course_id", courseId);  // Pass course id

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();  // Execute insert query
                    lblCourseDescription.Text = "You have successfully enrolled in the course!";
                }
                catch (Exception ex)
                {
                    lblCourseDescription.Text = "An error occurred while enrolling in the course. " + ex.Message;
                }
            }
        }

        // Function to check if the student is already enrolled in the course
        private bool IsStudentEnrolledInCourse(int studentId, string courseId)
        {
            string query = "SELECT COUNT(*) FROM student_courses WHERE student_id = @student_id AND course_id = @course_id";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@student_id", studentId);  // Pass student id
                cmd.Parameters.AddWithValue("@course_id", courseId);  // Pass course id

                conn.Open();
                int count = (int)cmd.ExecuteScalar();  // Check if the student is already enrolled

                return count > 0;  // If count is greater than 0, the student is already enrolled
            }
        }

    }
}
