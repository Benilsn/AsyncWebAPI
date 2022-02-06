using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories.IRepositories;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;


namespace MyAPI.src.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlConnection db = new MySqlConnection
        ("Server=localhost;Database=users;Uid=reykon;Pwd=19535313");

        public User Get(string userEmail, string userName)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText =
               "SELECT userName, email FROM registers where userName = @userName || email = @email";

                try
                {
                    cmd.Connection = db;
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    db.OpenAsync();

                    using MySqlDataReader dr = cmd.ExecuteReader();
                    {
                        if (dr.HasRows)
                        {
                            User u = new User();

                            dr.Read();

                            u.Email = dr.GetString(dr.GetOrdinal("email"));
                            u.Username = dr.GetString(dr.GetOrdinal("userName"));

                            return u;
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    db.CloseAsync();
                }
                return null;
            }
        }

        public async Task InsertUser(User u)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO registers (firstName, lastName, age, email, userName, password)" +
                                  " VALUES (@firstName, @lastName, @age, @email, @userName, @password)";

                try
                {
                    cmd.Connection = db;

                    cmd.Parameters.AddWithValue("@firstName", u.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", u.LastName);
                    cmd.Parameters.AddWithValue("@age", u.Age);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@userName", u.Username);
                    cmd.Parameters.AddWithValue("@password", u.Password);

                    await db.OpenAsync();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    await db.CloseAsync();
                }
            }
        }

    }
}
