//using System;
//using System.Data;
//using Microsoft.Data.SqlClient;
//using System.Collections.Generic;
//using System.IO;
//using Microsoft.VisualBasic.ApplicationServices;

//namespace JWITConnect.DAL
//{
//    public class JWITAccessHelper
//    {
//        private string connectionString;
        
//        public JWITAccessHelper(string connString)
//        {
//            connectionString = connString;
//        }
        
//        // Get connection string from app.config or web.config
//        public JWITAccessHelper()
//        {

//            {
//                try
//                {
//                    connectionString = System.Configuration.ConfigurationManager
//                        .ConnectionStrings["JWITConnection"].ConnectionString;

//                    if (string.IsNullOrEmpty(connectionString))
//                    {
//                        throw new Exception("Connection string 'JWITConnection' not found in configuration.");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    LogError(ex);
//                    throw new Exception("Failed to initialize database connection: " + ex.Message);
//                }
//            }

//        }

//        public bool InitializeConnection(out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                LogError(ex);
//                errorMessage = "Database connection failed: " + ex.Message;
//                return false;
//            }
//        }

//        // Enhanced authenticate user with better error handling
//        public User AuthenticateUser(string username, string password, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
//                    SqlCommand command = new SqlCommand(query, connection);
//                    command.Parameters.AddWithValue("@Username", username);
//                    command.Parameters.AddWithValue("@Password", password); // In a production app, use hashed passwords

//                    connection.Open();
//                    SqlDataReader reader = command.ExecuteReader();

//                    if (reader.Read())
//                    {
//                        User user = new User
//                        {
//                            UserID = Convert.ToInt32(reader["UserID"]),
//                            Username = reader["Username"].ToString(),
//                            Password = reader["Password"].ToString(),
//                            Email = reader["Email"].ToString(),
//                            IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
//                            LastLogin = reader["LastLogin"] != DBNull.Value ?
//                                (DateTime?)Convert.ToDateTime(reader["LastLogin"]) : null
//                        };

//                        // Update last login time
//                        UpdateLastLogin(user.UserID);

//                        return user;
//                    }

//                    errorMessage = "Invalid username or password.";
//                    return null; // Authentication failed
//                }
//            }
//            catch (Exception ex)
//            {
//                LogError(ex);
//                errorMessage = "Login error: " + ex.Message;
//                return null;
//            }
//        }




//        #region Speaker Methods

//        // Get all speakers for speaker profile page 
       
//        public List<Speaker> GetAllSpeakers()
//        {
//            List<Speaker> speakers = new List<Speaker>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("SELECT * FROM Speakers", connection);
//                connection.Open();
                
//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    Speaker speaker = new Speaker
//                    {
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        FirstName = reader["FirstName"].ToString(),
//                        LastName = reader["LastName"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        Company = reader["Company"].ToString(),
//                        Expertise = reader["Expertise"].ToString(),
//                        Bio = reader["Bio"].ToString(),
//                        TalkTopic = reader["TalkTopic"].ToString(),
//                        DateAdded = Convert.ToDateTime(reader["DateAdded"]),
//                        UserId = reader["UserId"].ToString()
//                    };
//                    speakers.Add(speaker);
//                }
//            }
            
//            return speakers;
//        }
        
//        // Add a new speaker
//        public void AddSpeaker(Speaker speaker)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "INSERT INTO Speakers (FirstName, LastName, Email, Company, Expertise, Bio, TalkTopic, DateAdded, UserId) " +
//                              "VALUES (@FirstName, @LastName, @Email, @Company, @Expertise, @Bio, @TalkTopic, @DateAdded, @UserId)";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@FirstName", speaker.FirstName);
//                command.Parameters.AddWithValue("@LastName", speaker.LastName);
//                command.Parameters.AddWithValue("@Email", speaker.Email);
//                command.Parameters.AddWithValue("@Company", speaker.Company);
//                command.Parameters.AddWithValue("@Expertise", speaker.Expertise);
//                command.Parameters.AddWithValue("@Bio", speaker.Bio);
//                command.Parameters.AddWithValue("@TalkTopic", speaker.TalkTopic);
//                command.Parameters.AddWithValue("@DateAdded", speaker.DateAdded);
//                command.Parameters.AddWithValue("@UserId", speaker.UserId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Update an existing speaker
//        public void UpdateSpeaker(Speaker speaker)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "UPDATE Speakers SET FirstName = @FirstName, LastName = @LastName, " +
//                              "Email = @Email, Company = @Company, Expertise = @Expertise, " +
//                              "Bio = @Bio, TalkTopic = @TalkTopic, UserId = @UserId " +
//                              "WHERE SpeakerID = @SpeakerID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@SpeakerID", speaker.SpeakerID);
//                command.Parameters.AddWithValue("@FirstName", speaker.FirstName);
//                command.Parameters.AddWithValue("@LastName", speaker.LastName);
//                command.Parameters.AddWithValue("@Email", speaker.Email);
//                command.Parameters.AddWithValue("@Company", speaker.Company);
//                command.Parameters.AddWithValue("@Expertise", speaker.Expertise);
//                command.Parameters.AddWithValue("@Bio", speaker.Bio);
//                command.Parameters.AddWithValue("@TalkTopic", speaker.TalkTopic);
//                command.Parameters.AddWithValue("@UserId", speaker.UserId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Delete a speaker
//        public void DeleteSpeaker(int speakerId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "DELETE FROM Speakers WHERE SpeakerID = @SpeakerID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@SpeakerID", speakerId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Get speaker by ID
//        public Speaker GetSpeakerById(int speakerId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Speakers WHERE SpeakerID = @SpeakerID";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@SpeakerID", speakerId);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                if (reader.Read())
//                {
//                    return new Speaker
//                    {
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        FirstName = reader["FirstName"].ToString(),
//                        LastName = reader["LastName"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        Company = reader["Company"].ToString(),
//                        Expertise = reader["Expertise"].ToString(),
//                        Bio = reader["Bio"].ToString(),
//                        TalkTopic = reader["TalkTopic"].ToString(),
//                        DateAdded = Convert.ToDateTime(reader["DateAdded"]),
//                        UserId = reader["UserId"].ToString()
//                    };
//                }
                
//                return null;
//            }
//        }
        
//        // Get speakers by user ID
//        public List<Speaker> GetSpeakersByUserId(string userId)
//        {
//            List<Speaker> speakers = new List<Speaker>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Speakers WHERE UserId = @UserId";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@UserId", userId);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                while (reader.Read())
//                {
//                    Speaker speaker = new Speaker
//                    {
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        FirstName = reader["FirstName"].ToString(),
//                        LastName = reader["LastName"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        Company = reader["Company"].ToString(),
//                        Expertise = reader["Expertise"].ToString(),
//                        Bio = reader["Bio"].ToString(),
//                        TalkTopic = reader["TalkTopic"].ToString(),
//                        DateAdded = Convert.ToDateTime(reader["DateAdded"]),
//                        UserId = reader["UserId"].ToString()
//                    };
//                    speakers.Add(speaker);
//                }
//            }
            
//            return speakers;
//        }
        
//        // Try to add a speaker with error handling
//        public bool TryAddSpeaker(Speaker speaker, out string errorMessage)
//        {
//            errorMessage = string.Empty;
            
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    string query = "INSERT INTO Speakers (FirstName, LastName, Email, Company, Expertise, Bio, TalkTopic, DateAdded, UserId) " +
//                                  "VALUES (@FirstName, @LastName, @Email, @Company, @Expertise, @Bio, @TalkTopic, @DateAdded, @UserId)";
                    
//                    SqlCommand command = new SqlCommand(query, connection);
//                    command.Parameters.AddWithValue("@FirstName", speaker.FirstName);
//                    command.Parameters.AddWithValue("@LastName", speaker.LastName);
//                    command.Parameters.AddWithValue("@Email", speaker.Email);
//                    command.Parameters.AddWithValue("@Company", speaker.Company);
//                    command.Parameters.AddWithValue("@Expertise", speaker.Expertise);
//                    command.Parameters.AddWithValue("@Bio", speaker.Bio);
//                    command.Parameters.AddWithValue("@TalkTopic", speaker.TalkTopic);
//                    command.Parameters.AddWithValue("@DateAdded", speaker.DateAdded);
//                    command.Parameters.AddWithValue("@UserId", speaker.UserId);
                    
//                    connection.Open();
//                    command.ExecuteNonQuery();
//                    return true;
//                }
//            }
//            catch (SqlException ex)
//            {
//                // Log the error
//                LogError(ex);
                
//                // Provide user-friendly error message
//                if (ex.Number == 2627) // Violation of primary key
//                {
//                    errorMessage = "A speaker with this information already exists.";
//                }
//                else
//                {
//                    errorMessage = "Database error occurred. Please try again later.";
//                }
//                return false;
//            }
//            catch (Exception ex)
//            {
//                LogError(ex);
//                errorMessage = "An unexpected error occurred.";
//                return false;
//            }
//        }
        
//        #endregion
        
//        #region SpeakerEvent Methods
        
//        // Get all events
//        public List<SpeakerEvent> GetAllEvents()
//        {
//            List<SpeakerEvent> events = new List<SpeakerEvent>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("SELECT * FROM SpeakerEvents", connection);
//                connection.Open();
                
//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    SpeakerEvent speakerEvent = new SpeakerEvent
//                    {
//                        EventID = Convert.ToInt32(reader["EventID"]),
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        EventTitle = reader["EventTitle"].ToString(),
//                        EventDate = Convert.ToDateTime(reader["EventDate"]),
//                        Location = reader["Location"].ToString(),
//                        Status = reader["Status"].ToString(),
//                        GoogleCalendarID = reader["GoogleCalendarID"] != DBNull.Value ? 
//                            reader["GoogleCalendarID"].ToString() : null
//                    };
//                    events.Add(speakerEvent);
//                }
//            }
            
//            return events;
//        }
        
//        // Add a new event
//        public void AddEvent(SpeakerEvent speakerEvent)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "INSERT INTO SpeakerEvents (SpeakerID, EventTitle, EventDate, Location, Status, GoogleCalendarID) " +
//                              "VALUES (@SpeakerID, @EventTitle, @EventDate, @Location, @Status, @GoogleCalendarID)";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@SpeakerID", speakerEvent.SpeakerID);
//                command.Parameters.AddWithValue("@EventTitle", speakerEvent.EventTitle);
//                command.Parameters.AddWithValue("@EventDate", speakerEvent.EventDate);
//                command.Parameters.AddWithValue("@Location", speakerEvent.Location);
//                command.Parameters.AddWithValue("@Status", speakerEvent.Status);
//                command.Parameters.AddWithValue("@GoogleCalendarID", speakerEvent.GoogleCalendarID ?? (object)DBNull.Value);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Update an existing event
//        public void UpdateEvent(SpeakerEvent speakerEvent)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "UPDATE SpeakerEvents SET SpeakerID = @SpeakerID, EventTitle = @EventTitle, " +
//                              "EventDate = @EventDate, Location = @Location, Status = @Status, GoogleCalendarID = @GoogleCalendarID " +
//                              "WHERE EventID = @EventID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@EventID", speakerEvent.EventID);
//                command.Parameters.AddWithValue("@SpeakerID", speakerEvent.SpeakerID);
//                command.Parameters.AddWithValue("@EventTitle", speakerEvent.EventTitle);
//                command.Parameters.AddWithValue("@EventDate", speakerEvent.EventDate);
//                command.Parameters.AddWithValue("@Location", speakerEvent.Location);
//                command.Parameters.AddWithValue("@Status", speakerEvent.Status);
//                command.Parameters.AddWithValue("@GoogleCalendarID", speakerEvent.GoogleCalendarID ?? (object)DBNull.Value);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Delete an event
//        public void DeleteEvent(int eventId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "DELETE FROM SpeakerEvents WHERE EventID = @EventID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@EventID", eventId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Get event by ID
//        public SpeakerEvent GetEventById(int eventId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM SpeakerEvents WHERE EventID = @EventID";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@EventID", eventId);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                if (reader.Read())
//                {
//                    return new SpeakerEvent
//                    {
//                        EventID = Convert.ToInt32(reader["EventID"]),
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        EventTitle = reader["EventTitle"].ToString(),
//                        EventDate = Convert.ToDateTime(reader["EventDate"]),
//                        Location = reader["Location"].ToString(),
//                        Status = reader["Status"].ToString(),
//                        GoogleCalendarID = reader["GoogleCalendarID"] != DBNull.Value ? 
//                            reader["GoogleCalendarID"].ToString() : null
//                    };
//                }
                
//                return null;
//            }
//        }
        
//        // Get events by speaker ID
//        public List<SpeakerEvent> GetEventsBySpeakerId(int speakerId)
//        {
//            List<SpeakerEvent> events = new List<SpeakerEvent>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM SpeakerEvents WHERE SpeakerID = @SpeakerID";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@SpeakerID", speakerId);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                while (reader.Read())
//                {
//                    SpeakerEvent speakerEvent = new SpeakerEvent
//                    {
//                        EventID = Convert.ToInt32(reader["EventID"]),
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        EventTitle = reader["EventTitle"].ToString(),
//                        EventDate = Convert.ToDateTime(reader["EventDate"]),
//                        Location = reader["Location"].ToString(),
//                        Status = reader["Status"].ToString(),
//                        GoogleCalendarID = reader["GoogleCalendarID"] != DBNull.Value ? 
//                            reader["GoogleCalendarID"].ToString() : null
//                    };
//                    events.Add(speakerEvent);
//                }
//            }
            
//            return events;
//        }
        
//        // Get upcoming events (useful for dashboard)
//        public List<SpeakerEvent> GetUpcomingEvents()
//        {
//            List<SpeakerEvent> events = new List<SpeakerEvent>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM SpeakerEvents WHERE EventDate >= @Today ORDER BY EventDate ASC";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@Today", DateTime.Today);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                while (reader.Read())
//                {
//                    SpeakerEvent speakerEvent = new SpeakerEvent
//                    {
//                        EventID = Convert.ToInt32(reader["EventID"]),
//                        SpeakerID = Convert.ToInt32(reader["SpeakerID"]),
//                        EventTitle = reader["EventTitle"].ToString(),
//                        EventDate = Convert.ToDateTime(reader["EventDate"]),
//                        Location = reader["Location"].ToString(),
//                        Status = reader["Status"].ToString(),
//                        GoogleCalendarID = reader["GoogleCalendarID"] != DBNull.Value ? 
//                            reader["GoogleCalendarID"].ToString() : null
//                    };
//                    events.Add(speakerEvent);
//                }
//            }
            
//            return events;
//        }
        
//        // Join query to get events with speaker info
//        public DataTable GetEventsWithSpeakerInfo()
//        {
//            DataTable dataTable = new DataTable();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = @"SELECT e.EventID, e.EventTitle, e.EventDate, e.Location, e.Status, 
//                                s.FirstName, s.LastName, s.Email, s.Company
//                                FROM SpeakerEvents e
//                                INNER JOIN Speakers s ON e.SpeakerID = s.SpeakerID
//                                ORDER BY e.EventDate DESC";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
//                connection.Open();
//                adapter.Fill(dataTable);
//            }
            
//            return dataTable;
//        }
        
//        #endregion
        
//        #region User Methods
        
//        // Get all users
//        public List<User> GetAllUsers()
//        {
//            List<User> users = new List<User>();
            
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
//                connection.Open();
                
//                SqlDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    User user = new User
//                    {
//                        UserID = Convert.ToInt32(reader["UserID"]),
//                        Username = reader["Username"].ToString(),
//                        Password = reader["Password"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
//                        LastLogin = reader["LastLogin"] != DBNull.Value ? 
//                            (DateTime?)Convert.ToDateTime(reader["LastLogin"]) : null
//                    };
//                    users.Add(user);
//                }
//            }
            
//            return users;
//        }
        
//        // Authenticate user
//        public User AuthenticateUser(string username, string password)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@Username", username);
//                command.Parameters.AddWithValue("@Password", password); // Consider using hashed passwords
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                if (reader.Read())
//                {
//                    User user = new User
//                    {
//                        UserID = Convert.ToInt32(reader["UserID"]),
//                        Username = reader["Username"].ToString(),
//                        Password = reader["Password"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
//                        LastLogin = reader["LastLogin"] != DBNull.Value ? 
//                            (DateTime?)Convert.ToDateTime(reader["LastLogin"]) : null
//                    };
                    
//                    // Update last login time
//                    UpdateLastLogin(user.UserID);
                    
//                    return user;
//                }
                
//                return null; // Authentication failed
//            }
//        }
        
//        // Update last login time
//        private void UpdateLastLogin(int userId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "UPDATE Users SET LastLogin = @LastLogin WHERE UserID = @UserID";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@LastLogin", DateTime.Now);
//                command.Parameters.AddWithValue("@UserID", userId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Add a new user
//        public void AddUser(User user)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "INSERT INTO Users (Username, Password, Email, IsAdmin, LastLogin) " +
//                              "VALUES (@Username, @Password, @Email, @IsAdmin, @LastLogin)";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@Username", user.Username);
//                command.Parameters.AddWithValue("@Password", user.Password); // Consider using hashed passwords
//                command.Parameters.AddWithValue("@Email", user.Email);
//                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
//                command.Parameters.AddWithValue("@LastLogin", (object)user.LastLogin ?? DBNull.Value);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Update user
//        public void UpdateUser(User user)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "UPDATE Users SET Username = @Username, Password = @Password, " +
//                              "Email = @Email, IsAdmin = @IsAdmin " +
//                              "WHERE UserID = @UserID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@UserID", user.UserID);
//                command.Parameters.AddWithValue("@Username", user.Username);
//                command.Parameters.AddWithValue("@Password", user.Password);
//                command.Parameters.AddWithValue("@Email", user.Email);
//                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Delete user
//        public void DeleteUser(int userId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "DELETE FROM Users WHERE UserID = @UserID";
                
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@UserID", userId);
                
//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }
        
//        // Get user by ID
//        public User GetUserById(int userId)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Users WHERE UserID = @UserID";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@UserID", userId);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                if (reader.Read())
//                {
//                    return new User
//                    {
//                        UserID = Convert.ToInt32(reader["UserID"]),
//                        Username = reader["Username"].ToString(),
//                        Password = reader["Password"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
//                        LastLogin = reader["LastLogin"] != DBNull.Value ? 
//                            (DateTime?)Convert.ToDateTime(reader["LastLogin"]) : null
//                    };
//                }
                
//                return null;
//            }
//        }
        
//        // Get User by Username (useful for checking if username exists)
//        public User GetUserByUsername(string username)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Users WHERE Username = @Username";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@Username", username);
                
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
                
//                if (reader.Read())
//                {
//                    return new User
//                    {
//                        UserID = Convert.ToInt32(reader["UserID"]),
//                        Username = reader["Username"].ToString(),
//                        Password = reader["Password"].ToString(),
//                        Email = reader["Email"].ToString(),
//                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
//                        LastLogin = reader["LastLogin"] != DBNull.Value ? 
//                            (DateTime?)Convert.ToDateTime(reader["LastLogin"]) : null
//                    };
//                }
                
//                return null;
//            }
//        }
        
//        #endregion
        
//        #region Utility Methods
        
//        // Log errors to a file
//        private void LogError(Exception ex)
//        {
//            try
//            {
//                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");
//                File.AppendAllText(logPath, 
//                    $"{DateTime.Now}: {ex.Message}\r\nStack Trace: {ex.StackTrace}\r\n\r\n");
//            }
//            catch
//            {
//                // If logging fails, just swallow the exception
//                // In a real app, you might want to use a more robust logging framework
//            }
//        }
        
//        // Test database connection
//        public bool TestConnection()
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    return true;
//                }
//            }
//            catch
//            {
//                return false;
//            }
//        }
        
//        #endregion
//    }
//}
