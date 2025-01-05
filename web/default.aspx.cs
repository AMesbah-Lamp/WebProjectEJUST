using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace YourProject
{
    public partial class Login : System.Web.UI.Page
    {
        // Method to check if a user exists in the database
        private bool UserExists(string username)
        {
            string query = "SELECT COUNT(*) FROM students WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Method to authenticate user during login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                return;
            }

            int? studentId = AuthenticateUser(username, password);
            if (studentId.HasValue)
            {
                // Create session after successful login
                Session["Username"] = username; // Set the username in the session
                Session["StudentId"] = studentId.Value; // Set the StudentId in the session

                // Debugging: Log the session values
                System.Diagnostics.Debug.WriteLine($"Session Username: {Session["Username"]}");
                System.Diagnostics.Debug.WriteLine($"Session StudentId: {Session["StudentId"]}");

                lblMessage.Text = "Login successful!";
                Response.Redirect("home.aspx"); // Redirect to home page after successful login
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }

        // Method to validate the user's credentials and return the StudentId
        private int? AuthenticateUser(string username, string password)
        {
            string query = "SELECT id, password FROM students WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string storedPassword = reader.GetString(1);

                    // Verify the hashed password
                    if (VerifyPassword(password, storedPassword))
                    {
                        return studentId;
                    }
                }
                return null;
            }
        }

        // Method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Method to verify the hashed password
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword == storedPassword;
        }

        // Method to register a new user
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtSignUpUsername.Text.Trim();
            string password = txtSignUpPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Debugging: Log the input values
            System.Diagnostics.Debug.WriteLine($"Signup - Username: {username}, Password: {password}, Confirm Password: {confirmPassword}");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                lblSignUpMessage.Text = "Please enter both username and password.";
                lblSignUpMessage.Visible = true; // Ensure the label is visible
                return;
            }

            if (password != confirmPassword)
            {
                lblSignUpMessage.Text = "Passwords do not match. Please try again.";
                lblSignUpMessage.Visible = true; // Ensure the label is visible
                return;
            }

            if (UserExists(username))
            {
                lblSignUpMessage.Text = "Username already exists. Please choose another.";
                lblSignUpMessage.Visible = true; // Ensure the label is visible
                return;
            }

            if (RegisterUser(username, password))
            {
                lblSignUpMessage.Text = "Registration successful!";
                lblSignUpMessage.Visible = true; // Ensure the label is visible

                // Clear the input fields after successful registration
                txtSignUpUsername.Text = "";
                txtSignUpPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            else
            {
                lblSignUpMessage.Text = "An error occurred during registration. Please try again.";
                lblSignUpMessage.Visible = true; // Ensure the label is visible
            }
        }

        // Method to register a new user in the database
        private bool RegisterUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);  // Hash the password before saving it

            string query = "INSERT INTO students (username, password) VALUES (@username, @password)";

            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);  // Store the hashed password

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception message for debugging
                    System.Diagnostics.Debug.WriteLine($"Error during registration: {ex.Message}");
                    lblSignUpMessage.Text = "Error: " + ex.Message; // Display error message on the UI
                    return false;
                }
            }
        }

        // Check if user is already logged in
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("home.aspx"); // Redirect to home page if already logged in
            }
        }
    }
}