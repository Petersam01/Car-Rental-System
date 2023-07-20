using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Car_Rental_System.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;

namespace Car_Rental_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DataHandler
    {

        /*
        * handling users s
        * initialising user
        * registration
        * login
        * update user
        * 
        */
        private User initUsers(SqlDataReader reader)
        {
  
            return new User
            {
                UserID = Convert.ToInt32(reader["UserID"]),
                Name = reader["Name"].ToString(),
                Surname = reader["Surname"].ToString(),
                IDNumber = reader["IDNumber"].ToString(),
                LicenseNumber = reader["LicenseNumber"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"].ToString(),
                UserType = reader["UserType"].ToString(),
                Password = reader["Password"].ToString(),
               
            };
        }

        public bool CreateUser(User newUser)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                string sql = "INSERT INTO Users(Name, Surname, IDNumber, LicenseNumber, Phone, Email,UserType, Password) " +
                    "VALUES(@Name, @Surname, @IDNumber, @LicenseNumber, @Phone, @Email,@UserType, @Password)";


                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", newUser.Name);
                    cmd.Parameters.AddWithValue("@Surname", newUser.Surname);
                    cmd.Parameters.AddWithValue("@IDNumber", newUser.IDNumber);
                    cmd.Parameters.AddWithValue("@LicenseNumber", newUser.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", newUser.Phone);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@UserType", newUser.UserType);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);


                    if (cmd != null)
                    {
                        isCreated = true;
                    }
                    cmd.ExecuteNonQuery();


                }
            }

            return isCreated;
        }

        public List<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Users";
                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<User> users = new List<User>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(initUsers(reader));
                        }
                    }
                    connection.Close();
                    return users;
                }
            }
        }


        public User GetUsersById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Users " +
                    "WHERE UserID =" + id + ";";

                using (SqlCommand sqlCmd = new SqlCommand(SQL_QUERY, connection))
                {
                    User user = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = initUsers(reader);

                        }
                    }
                    connection.Close();
                    return user;
                }
            }

        }
        public string GetUserTypeById(int id)
        {
            string UserType = "";
            string SQL_QUERY = "SELECT * FROM Users " +
                    "WHERE UserID =" + id + ";";


            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    User user = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string name, string surname, string email, string contacts, string DOB, string userType, string status, string password)
                            user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                UserType = reader["UserType"].ToString(),


                            };

                        }
                    }
                    connection.Close();
                    return user.UserType;
                }
            }

        }


        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Users " +
                    "WHERE Email ='" + email + "';";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    User user = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = initUsers(reader);

                        }
                    }
                    connection.Close();
                    return user;
                }
            }
        }


        public User UpdateUser(User updateUser)
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "UPDATE Users " +
                    " SET Name=@Name, Surname=@Surname,IDNumber=@IDNumber, LicenseNumber=@LicenseNumber," +
                    "Phone=@Phone, Email=@Email,UserType=@UserType,Password=@Password" +
                    "WHERE UserID=@UserID";
                //UserID=@UserID,
                User tmpUser = GetUserByEmail(updateUser.Email);
                int ID = 0;
                if (tmpUser == null)
                {
                    return null;
                }
                else
                {
                    ID = GetUserByEmail(updateUser.Email).UserID;
                }


                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", ID);
                    cmd.Parameters.AddWithValue("@Name", updateUser.Name);
                    cmd.Parameters.AddWithValue("@Surname", updateUser.Surname);
                    cmd.Parameters.AddWithValue("@IDNumber", updateUser.IDNumber);
                    cmd.Parameters.AddWithValue("@LicenseNumber", updateUser.LicenseNumber);
                    cmd.Parameters.AddWithValue("@Phone", updateUser.Phone);
                    cmd.Parameters.AddWithValue("@Email", updateUser.Email);
                    cmd.Parameters.AddWithValue("@UserType", updateUser.UserType);
                    cmd.Parameters.AddWithValue("@Password", updateUser.Password);

                    cmd.ExecuteNonQuery();
                }
            }
            return updateUser;
        }


        public User UserLogin(string email, string passwd)
        {
            string SQL_USER = "SELECT * FROM Users Where Email = '" + email + "' and Password = '" + passwd + "';";


            User user = null;

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                //Login for the User
                using (SqlCommand cmd = new SqlCommand(SQL_USER, connection))
                {

                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = initUsers(reader);

                        }
                    }

                    connection.Close();
                    return user;
                }


            }



        }

        public bool CheckIfEmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(Settings.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private AdminRent initAdmins(SqlDataReader reader)
        {

            return new AdminRent
            {
                AdminID = Convert.ToInt32(reader["AdminID"]),
                Name = reader["Name"].ToString(),
                Surname = reader["Surname"].ToString(),
                Email = reader["Email"].ToString(),
                Position = reader["Position"].ToString(),
                AdminType = reader["AdminType"].ToString(),
                Password = reader["Password"].ToString(),

            };
        }

        public bool CreateAdmin(AdminRent newAdmin)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                string sql = "INSERT INTO Admins(Name, Surname, Email,Position,AdminType, Password) " +
                    "VALUES(@Name, @Surname, @Email,@Position,@AdminType, @Password)";


                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", newAdmin.Name);
                    cmd.Parameters.AddWithValue("@Surname", newAdmin.Surname);
                    cmd.Parameters.AddWithValue("@Email", newAdmin.Email);
                    cmd.Parameters.AddWithValue("@Password", newAdmin.Position);
                    cmd.Parameters.AddWithValue("@AdminType", newAdmin.AdminType);
                    cmd.Parameters.AddWithValue("@Password", newAdmin.Password);


                    if (cmd != null)
                    {
                        isCreated = true;
                    }
                    cmd.ExecuteNonQuery();


                }
            }

            return isCreated;
        }


        public List<AdminRent> GetAllAdmins()
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins";
                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<AdminRent> admins = new List<AdminRent>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins.Add(initAdmins(reader));
                        }
                    }
                    connection.Close();
                    return admins;
                }
            }
        }


        public AdminRent GetAdminById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins " +
                    "WHERE AdminID =" + id + ";";

                using (SqlCommand sqlCmd = new SqlCommand(SQL_QUERY, connection))
                {
                    AdminRent admins = null;
                    sqlCmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins = initAdmins(reader);

                        }
                    }
                    connection.Close();
                    return admins;
                }
            }

        }
        public string GetAdminTypeById(int id)
        {
            string AdminType = "";
            string SQL_QUERY = "SELECT * FROM Admins " +
                    "WHERE AdminID =" + id + ";";


            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    AdminRent admin = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string name, string surname, string email, string contacts, string DOB, string userType, string status, string password)
                            admin = new AdminRent
                            {
                                AdminID = Convert.ToInt32(reader["AdminID"]),
                                AdminType = reader["AdminType"].ToString(),


                            };

                        }
                    }
                    connection.Close();
                    return admin.AdminType;
                }
            }

        }



        public AdminRent GetAdminByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Admins " +
                    "WHERE Email ='" + email + "';";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    AdminRent admin = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin = initAdmins(reader);

                        }
                    }
                    connection.Close();
                    return admin;
                }
            }
        }

        public AdminRent UpdateAdmin(AdminRent updateAdmin)
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                var SQL_UPDATE = "UPDATE Admins " +
                    " SET Name=@Name, Surname=@Surname, Email=@Email, Position=@Position, AdminType=@AdminType, Password=@Password" +
                    "WHERE AdminID=@AdminID";
                
                AdminRent tmpAdmin = GetAdminByEmail(updateAdmin.Email);
                int ID = 0;
                if (tmpAdmin == null)
                {
                    return null;
                }
                else
                {
                    ID = GetAdminByEmail(updateAdmin.Email).AdminID;
                }


                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE, connection))
                {
                    cmd.Parameters.AddWithValue("@AdminID", ID);
                    cmd.Parameters.AddWithValue("@Name", updateAdmin.Name);
                    cmd.Parameters.AddWithValue("@Surname", updateAdmin.Surname);
                    cmd.Parameters.AddWithValue("@Email", updateAdmin.Email);
                    cmd.Parameters.AddWithValue("@Position", updateAdmin.Position);
                    cmd.Parameters.AddWithValue("@AdminType", updateAdmin.AdminType);
                    cmd.Parameters.AddWithValue("@Password", updateAdmin.Password);

                    cmd.ExecuteNonQuery();
                }
            }
            return updateAdmin;
        }


        public AdminRent AdminLogin(string email, string passwd)
        {
            string SQL_USER = "SELECT * FROM Admins Where Email = '" + email + "' and Password = '" + passwd + "';";


            AdminRent admin = null;

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                //Login for the admin
                using (SqlCommand cmd = new SqlCommand(SQL_USER, connection))
                {

                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admin = initAdmins(reader);

                        }
                    }

                    connection.Close();
                    return admin;
                }


            }



        }

        public bool CheckIfAdminEmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(Settings.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /*
         
         * function on which admin can create a secretry
         * a function on which admin can remove a car
         * a function which tells admin if car has been rented 10 times or more
         * a function on which a user can make a booking
         * function which calculated the number of times a type of car has been booked in a month
         * a function which calculated the total number of booking for all cars
         
         * a function which gets a type of a car model
         * a function which takes the car to service and removes the car from cars available to rent
         * a function of when a ar is rented is removed from cars available
         * a function on which admin returns car to list of cars available to rent 
         */


        //functions to create SUV

        private Suv initSUV(SqlDataReader reader)
        {
            byte[] image = null;
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }
            return new Suv
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                SuvType = reader["SuvType"].ToString(),
                Description = reader["Description"].ToString(),
                Distance = reader["Distance"].ToString(),
                Image = (byte[])reader["Image"],
                AdminID = Convert.ToInt32(reader["AdminID"]),

            };
        }
        public bool InsertSUV(Suv newSUV)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();

                var sql = "INSERT INTO SUVs (Name, SuvType, Description, Distance, Image, AdminID) " +
                             "VALUES (@Name, @SuvType, @Description, @Distance, @Image, @AdminID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name",newSUV.Name);
                    command.Parameters.AddWithValue("@SuvType", newSUV.SuvType);
                    command.Parameters.AddWithValue("@Description", newSUV.Description);
                    command.Parameters.AddWithValue("@Distance", newSUV.Distance);
                    command.Parameters.AddWithValue("@Image", newSUV.Image);
                    command.Parameters.AddWithValue("@AdminID", newSUV.AdminID);
                   // command.ExecuteNonQuery();

                    if (command != null)
                    {
                        isCreated = true;
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        //functions to create barkies
        private Barky initBarkie(SqlDataReader reader)
        {
            byte[] image = null;
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }
            return new Barky
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                BarkieType = reader["BarkieType"].ToString(),
                Description = reader["Description"].ToString(),
                Distance = reader["Distance"].ToString(),
                Image = image,
                //Image = (byte[])reader["Image"],
                AdminID = Convert.ToInt32(reader["AdminID"]),

            };
        }

        




    public bool InsertBarkie(Barky newBarkie)
        {
            bool isCreated = false;

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();
                //GRANT INSERT ON Barkies TO CEO;
                   // INSERT INTO Barkies
                var sql = "INSERT INTO Barkies(Name, BarkieType, Description, Distance, Image, AdminID) " +
                             "VALUES(@Name, @BarkieType, @Description, @Distance, @Image, @AdminID)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", newBarkie.Name);
                    command.Parameters.AddWithValue("@BarkieType", newBarkie.BarkieType);
                    command.Parameters.AddWithValue("@Description", newBarkie.Description);
                    command.Parameters.AddWithValue("@Distance", newBarkie.Distance);
                    command.Parameters.AddWithValue("@Image",newBarkie.Image);
                   // command.Parameters.AddWithValue("@CarID", Session["AdminID"]);
                    command.Parameters.AddWithValue("@AdminID", newBarkie.AdminID);
                    if (command != null)
                    {
                        isCreated = true;
                    }
                   
                  //  command.ExecuteNonQuery();



                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        //functions to create hatchbacks
        private HatchB initatch(SqlDataReader reader)
        {
            byte[] image = null;
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }
            return new HatchB
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                HatchType = reader["HatchType"].ToString(),
                Description = reader["Description"].ToString(),
                Distance = reader["Distance"].ToString(),
                Image = (byte[])reader["Image"],
                AdminID = Convert.ToInt32(reader["AdminID"]),

            };
        }
        public bool InsertHatch(HatchB newHatch)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();

                var sql = "INSERT INTO Hatchbacks(Name, HatchType, Description, Distance, Image, AdminID) " +
                             "VALUES (@Name, @HatchType, @Description, @Distance, @Image, @AdminID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", newHatch.Name);
                    command.Parameters.AddWithValue("@HatchType", newHatch.HatchType);
                    command.Parameters.AddWithValue("@Description", newHatch.Description);
                    command.Parameters.AddWithValue("@Distance", newHatch.Distance);
                    command.Parameters.AddWithValue("@Image", newHatch.Image);
                    command.Parameters.AddWithValue("@AdminID", newHatch.AdminID);
                   
                   // command.ExecuteNonQuery();

                    if (command != null)
                    {
                        isCreated = true;
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        //functions to create minibuses
        private MiniB initMiniBus(SqlDataReader reader)
        {
            byte[] image = null;
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }
            return new MiniB
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                MiniType = reader["MiniType"].ToString(),
                Description = reader["Description"].ToString(),
                Distance = reader["Distance"].ToString(),
                Image = (byte[])reader["Image"],
                AdminID = Convert.ToInt32(reader["AdminID"]),

            };
        }
        public bool InsertMiniBus(MiniB newMinibus)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();

                var sql = "INSERT INTO Minibuses (Name, MiniType, Description, Distance, Image, AdminID) " +
                             "VALUES (@Name, @MiniType, @Description, @Distance, @Image, @AdminID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", newMinibus.Name);
                    command.Parameters.AddWithValue("@MiniType", newMinibus.MiniType);
                    command.Parameters.AddWithValue("@Description", newMinibus.Description);
                    command.Parameters.AddWithValue("@Distance", newMinibus.Distance);
                    command.Parameters.AddWithValue("@Image", newMinibus.Image);
                    command.Parameters.AddWithValue("@AdminID", newMinibus.AdminID);
                   
                   // command.ExecuteNonQuery();

                    if (command != null)
                    {
                        isCreated = true;
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        //functions for sedan
        private CarSedan initSedan(SqlDataReader reader)
        {
            byte[] image = null;
            if (!Convert.IsDBNull(reader["Image"]))
            {
                image = (byte[])reader["Image"];
            }
            return new CarSedan
            {
                Id = Convert.ToInt32(reader["ID"]),
                Name = reader["Name"].ToString(),
                SedanType = reader["SedanType"].ToString(),
                Description = reader["Description"].ToString(),
                Distance = reader["Distance"].ToString(),
                Image = (byte[])reader["Image"],
                AdminID = Convert.ToInt32(reader["AdminID"]),

            };
        }
        public bool InsertSedan(CarSedan newSedan)
        {
            bool isCreated = false;
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                connection.Open();

                var sql = "INSERT INTO Sedans (Name, SedanType, Description, Distance, Image, AdminID) " +
                             "VALUES (@Name, @SedanType, @Description, @Distance, @Image, @AdminID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", newSedan.Name);
                    command.Parameters.AddWithValue("@SedanType", newSedan.SedanType);
                    command.Parameters.AddWithValue("@Description", newSedan.Description);
                    command.Parameters.AddWithValue("@Distance", newSedan.Distance);
                    command.Parameters.AddWithValue("@Image", newSedan.Image);
                    command.Parameters.AddWithValue("@AdminID", newSedan.AdminID);
                   
                   // command.ExecuteNonQuery();

                    if (command != null)
                    {
                        isCreated = true;
                    }
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return isCreated;
        }

        //function to get all cars
        public List<CarsView> GetAllCars()
        {
            List<CarsView> cars = new List<CarsView>();
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Car " +
                             "INNER JOIN SUVs ON Car.ID = SUVs.ID " +
                             "INNER JOIN Barkies ON Car.ID = Barkies.ID " +
                             "INNER JOIN Minibuses ON Car.ID = Minibuses.ID " +
                             "INNER JOIN Hatchbacks ON Car.ID = Hatchbacks.ID " +
                             "INNER JOIN Sedans ON Car.ID = Sedans.ID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    
                    command.CommandType = CommandType.Text;
                    //connection.Open();

                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarsView car = new CarsView();
                            car.CarID = reader.GetInt32(0);
                            car.ID = reader.GetInt32(1);
                            cars.Add(car);
                        }
                        reader.Close();
                    }
                    connection.Close();

                }
            }

            return cars;
        }

        //authentication admin
        public bool Authenticate(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string sql = "SELECT COUNT(*) FROM Admins WHERE Email = @Email AND Password = @Password";
                

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);


                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    // If the count is greater than zero, authentication is successful
                    return count > 0;
                }
            }
        }


     
      

        //get barkie by id
        public Barky GetBarkieById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Barkies " +
                    "WHERE ID =" + id + ";";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    Barky barkie = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string Name, string Surname, string Email, string Contacts, string DOB, string UserType, string Status, string Password)
                            barkie = initBarkie(reader);

                        }
                    }
                    connection.Close();
                    return barkie;
                }
            }

        }

      
        public string GetBarkieTypeById(int id)
        {
            string userType = "";

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a SqlCommand object
                SqlCommand command = new SqlCommand("SELECT BarkieType FROM Barkies WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userType = reader["BarkieType"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return userType;
        }


        public List<Barky> getBarkies()
        {   
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Barkies ";
                
                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<Barky> barkies = new List<Barky>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            barkies.Add(initBarkie(reader));
                        }
                    }
                    connection.Close();
                    return barkies;
                }

            }
        }

        //get all hatchbaks
        public List<HatchB> getHatchbacks()
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Hatchbacks ";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<HatchB> hatch = new List<HatchB>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hatch.Add(initatch(reader));
                        }
                    }
                    connection.Close();
                    return hatch;
                }

            }
        }

        //get hatchback by id
        public HatchB GetHatchbackById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Hatchbacks " +
                    "WHERE ID =" + id + ";";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    HatchB hatch = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string Name, string Surname, string Email, string Contacts, string DOB, string UserType, string Status, string Password)
                            hatch = initatch(reader);

                        }
                    }
                    connection.Close();
                    return hatch;
                }
            }

        }

        public string GetHatchTypeById(int id)
        {
            string userType = "";

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a SqlCommand object
                SqlCommand command = new SqlCommand("SELECT HatchType FROM Hatchbacks WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userType = reader["HatchType"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return userType;
        }
        //get all minibus
        public List<MiniB> getMinibus()
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Minibuses ";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<MiniB> minibus = new List<MiniB>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            minibus.Add(initMiniBus(reader));
                        }
                    }
                    connection.Close();
                    return minibus;
                }

            }
        }

        //get minibus by id
        public MiniB GetMinibusById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Minibuses " +
                    "WHERE ID =" + id + ";";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    MiniB mini = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string Name, string Surname, string Email, string Contacts, string DOB, string UserType, string Status, string Password)
                            mini = initMiniBus(reader);

                        }
                    }
                    connection.Close();
                    return mini;
                }
            }

        }

        public string GetMiniTypeById(int id)
        {
            string userType = "";

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a SqlCommand object
                SqlCommand command = new SqlCommand("SELECT MiniType FROM Minibuses WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userType = reader["MiniType"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return userType;
        }


        //get all sedans
        public List<CarSedan> getSedan()
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Sedans ";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<CarSedan> sedan = new List<CarSedan>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            sedan.Add(initSedan(reader));
                        }
                    }
                    connection.Close();
                    return sedan;
                }

            }
        }

        //get sdan by id
        public CarSedan GetSedanById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM Sedans " +
                    "WHERE TID =" + id + ";";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    CarSedan sedan = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string Name, string Surname, string Email, string Contacts, string DOB, string UserType, string Status, string Password)
                            sedan = initSedan(reader);

                        }
                    }
                    connection.Close();
                    return sedan;
                }
            }

        }

        public string GetSedanTypeById(int id)
        {
            string userType = "";

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a SqlCommand object
                SqlCommand command = new SqlCommand("SELECT SedanType FROM Sedans WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userType = reader["SedanType"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return userType;
        }


        //get all Suv
        public List<Suv> getSuv()
        {

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM SUVs ";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    List<Suv> suv = new List<Suv>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            suv.Add(initSUV(reader));
                        }
                    }
                    connection.Close();
                    return suv;
                }

            }
        }

        //get suv by id
        public Suv GetSuvById(int id)
        {
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                string SQL_QUERY = "SELECT * FROM SUVs " +
                    "WHERE ID =" + id + ";";

                using (SqlCommand cmd = new SqlCommand(SQL_QUERY, connection))
                {
                    Suv suv = null;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {//public User(string Name, string Surname, string Email, string Contacts, string DOB, string UserType, string Status, string Password)
                            suv = initSUV(reader);

                        }
                    }
                    connection.Close();
                    return suv;
                }
            }

        }
        public string GetSubTypeById(int id)
        {
            string userType = "";

            // Connect to the database
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {
                // Create a SqlCommand object
                SqlCommand command = new SqlCommand("SELECT SuvType FROM SUVs WHERE ID = @ID", connection);

                // Add the parameter for the user ID
                command.Parameters.AddWithValue("@ID", id);

                // Open the connection
                connection.Open();

                // Execute the command and get the user type
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    userType = reader["SuvType"].ToString();
                }

                // Close the reader and the connection
                reader.Close();
                connection.Close();
            }

            return userType;
        }


        //Rent barkie funtion

        public void BookBarkie(DateTime current, string bookDate, string returnDate, int userId,int id)
        {
            Barky barky = GetBarkieById(id);
            User user = GetUsersById(userId);
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                connection.Open();
                var sql = "INSERT INTO RentBarkie(CurrentDate,Booking_date, Return_date, isApproved,UserID,ID) " +
                    "VALUES(@CurrentDate, @Booking_date, @Return_date, @IsApproved, @UserID,@ID)";



                //[IsApproved]
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", current);
                    cmd.Parameters.AddWithValue("@Booking_date", bookDate);
                    cmd.Parameters.AddWithValue("@Return_date", returnDate);
                    cmd.Parameters.AddWithValue("@IsApproved", "Pending");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@ID", barky.Id);// fix dis line

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //booking hatchback 
        public void BookHatchback(DateTime current, string bookDate, string returnDate, int userId, int Id)
        {
            HatchB hatch = GetHatchbackById(Id);
            User user = GetUsersById(userId);
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                connection.Open();
                var sql = "INSERT INTO RentHatchBack(CurrentDate,Booking_date, Return_date, isApproved,UserID,ID) " +
                    "VALUES(@CurrentDate, @Booking_date, @Return_date, @IsApproved, @UserID,@ID)";



                //[IsApproved]
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", current);
                    cmd.Parameters.AddWithValue("@Booking_date", bookDate);
                    cmd.Parameters.AddWithValue("@Return_date", returnDate);
                    cmd.Parameters.AddWithValue("@IsApproved", "Pending");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@ID", hatch.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //booking minibus
        public void BookMinibus(DateTime current, string bookDate, string returnDate, int userId, int Id)
        {
            MiniB mini = GetMinibusById(Id);
            User user = GetUsersById(userId);
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                connection.Open();
                var sql = "INSERT INTO RentMinibus(CurrentDate,Booking_date, Return_date, isApproved,UserID,ID) " +
                    "VALUES(@CurrentDate, @Booking_date, @Return_date, @IsApproved, @UserID,@ID)";



                //[IsApproved]
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", current);
                    cmd.Parameters.AddWithValue("@Booking_date", bookDate);
                    cmd.Parameters.AddWithValue("@Return_date", returnDate);
                    cmd.Parameters.AddWithValue("@IsApproved", "Pending");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@ID", mini.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //book sedan
        public void BookSedan(DateTime current, string bookDate, string returnDate, int userId, int Id)
        {
            CarSedan sedan = GetSedanById(Id);
            User user = GetUsersById(userId);
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                connection.Open();
                var sql = "INSERT INTO RentSedan(CurrentDate,Booking_date, Return_date, isApproved,UserID,ID) " +
                    "VALUES(@CurrentDate, @Booking_date, @Return_date, @IsApproved, @UserID,@ID)";



                //[IsApproved]
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", current);
                    cmd.Parameters.AddWithValue("@Booking_date", bookDate);
                    cmd.Parameters.AddWithValue("@Return_date", returnDate);
                    cmd.Parameters.AddWithValue("@IsApproved", "Pending");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@ID", sedan.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //book suv
        public void BookSuv(DateTime current, string bookDate, string returnDate, int userId, int Id)
        {
            Suv suv = GetSuvById(Id);
            User user = GetUsersById(userId);
            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                connection.Open();
                var sql = "INSERT INTO RentSUV(CurrentDate,Booking_date, Return_date, isApproved,UserID,ID) " +
                    "VALUES(@CurrentDate, @Booking_date, @Return_date, @IsApproved, @UserID,@ID)";



                //[IsApproved]
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CurrentDate", current);
                    cmd.Parameters.AddWithValue("@Booking_date", bookDate);
                    cmd.Parameters.AddWithValue("@Return_date", returnDate);
                    cmd.Parameters.AddWithValue("@IsApproved", "Pending");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@ID", suv.Id);

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public List<BarkieRent> getBarkieUserBookings(int id, string status)
        {


            string sqlQ = "SELECT * FROM RentBarkie WHERE UserID =  " + id + " AND IsApproved ='" + status + "';";

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                using (SqlCommand cmd = new SqlCommand(sqlQ, connection))
                {
                    List<BarkieRent> barkieBooking = new List<BarkieRent>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            barkieBooking.Add(new BarkieRent
                            {
                                BookingID = Convert.ToInt32(reader["ID"]),
                                CurrentDate = (DateTime)reader["CurrentDate"],
                                Booking_date = reader["CurrentDate"].ToString(),
                                Return_date = reader["Return_date"].ToString(),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                ID = Convert.ToInt32(reader["ID"]),


                            });

                        }
                    }
                    connection.Close();
                    return barkieBooking;
                }
            }

        }

        //cars bookings barkie,hatch,sedan,minibus,suv
        public List<BarkieRent> getBKBookings()
        {
            int id = 0;
            string status = " ";

            string sqlQ = "SELECT * FROM RentBarkie WHERE BookingID =  " + id + " AND IsApproved ='" + status + "';";

            using (SqlConnection connection = new SqlConnection(Settings.CONNECTION_STRING))
            {

                using (SqlCommand cmd = new SqlCommand(sqlQ, connection))
                {
                    List<BarkieRent> barkieBooking = new List<BarkieRent>();
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            barkieBooking.Add(new BarkieRent
                            {

                                BookingID = Convert.ToInt32(reader["ID"]),
                                CurrentDate = (DateTime)reader["CurrentDate"],
                                Booking_date = reader["CurrentDate"].ToString(),
                                Return_date = reader["Return_date"].ToString(),
                                isApproved = reader["IsApproved"].ToString(),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                ID = Convert.ToInt32(reader["ID"]),


                            });

                        }
                    }
                    connection.Close();
                    return barkieBooking;
                }
            }

        }

    }

}

