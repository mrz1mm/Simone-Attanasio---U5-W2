using EpiHot.Models;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class UserSvc
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
    }
}
