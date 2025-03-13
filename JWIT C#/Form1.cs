using System;
using System.Data.SqlClient;
using System.Windows.Forms; 

namespace JWIT_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPwd.Text;

            if (AuthenticateUser(username, password))
            {
                // Open NotificationsHUB (Main Menu)
                NotificationsHUB mainMenu = new NotificationsHUB();
                mainMenu.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string connectionString = "Data Source=DESKTOP-E7R9A89\\SQLEXPRESS;Initial Catalog=JWIT_db;Integrated Security=True"; // Replace with your DB connection string
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }

}
