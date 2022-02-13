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


        public string GetByEmail(string userEmail)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText =
               "SELECT email FROM registers where email = @email";

                try
                {
                    cmd.Connection = db;
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    db.OpenAsync();

                    using MySqlDataReader dr = cmd.ExecuteReader();
                    {
                        if (dr.HasRows)
                        {
                            string email;

                            dr.Read();

                            email = dr.GetString(dr.GetOrdinal("email"));

                            return email;
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
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
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
