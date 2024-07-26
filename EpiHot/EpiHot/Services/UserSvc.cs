using EpiHot.Models;
using EpiHot.Models.Dto;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class UserSvc : IUserSvc
    {
        private readonly IConfiguration _config;

        public UserSvc(IConfiguration config)
        {
            _config = config;
        }

        public User GetUser(LoginDto userDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_USER_COMMAND = @"
                    SELECT UserId, Username, Password
                    FROM Users
                    WHERE Username = @Username AND Password = @Password";

                    User user = null;
                    using (SqlCommand cmd = new SqlCommand(SELECT_USER_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", userDto.Username);
                        cmd.Parameters.AddWithValue("@Password", userDto.Password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Roles = new List<string>()
                                };
                            }
                        }
                    }

                    if (user != null)
                    {
                        const string SELECT_ROLES_COMMAND = @"
                        SELECT r.RoleType
                        FROM UsersRoles ur
                        JOIN Roles r ON ur.RoleId = r.RoleId
                        WHERE ur.UserId = @UserId";

                        using (SqlCommand cmd = new SqlCommand(SELECT_ROLES_COMMAND, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", user.UserId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    user.Roles.Add(reader.GetString(0));
                                }
                            }
                        }
                    }

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dell'utente", ex);
            }
        }

        public void AddUser(RegisterDto registerDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();

                    // Check if role exists
                    const string SELECT_ROLE_COMMAND = @"
                    SELECT RoleId FROM Roles WHERE RoleType = @RoleType";

                    int roleId;
                    using (SqlCommand cmd = new SqlCommand(SELECT_ROLE_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleType", registerDto.RoleType);

                        roleId = (int)cmd.ExecuteScalar();
                        if (roleId == 0)
                        {
                            throw new ArgumentException("Invalid role type");
                        }
                    }

                    // Insert new user
                    const string INSERT_USER_COMMAND = @"
                    INSERT INTO Users (Username, Password)
                    VALUES (@Username, @Password);
                    SELECT CAST(scope_identity() AS int);";

                    int userId;
                    using (SqlCommand cmd = new SqlCommand(INSERT_USER_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", registerDto.Username);
                        cmd.Parameters.AddWithValue("@Password", registerDto.Password);

                        userId = (int)cmd.ExecuteScalar();
                    }

                    // Assign role to user
                    const string INSERT_USER_ROLE_COMMAND = @"
                    INSERT INTO UsersRoles (UserId, RoleId)
                    VALUES (@UserId, @RoleId);";

                    using (SqlCommand cmd = new SqlCommand(INSERT_USER_ROLE_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@RoleId", roleId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la registrazione dell'utente", ex);
            }
        }
    }
}
