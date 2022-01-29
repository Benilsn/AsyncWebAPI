using MySql.Data.MySqlClient;
using System;
using MyAPI.Business.Entities;
using System.Threading.Tasks;
using MyAPI.Business.Repositories;

namespace MyAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlConnection db = new MySqlConnection
        ("Server=localhost;Database=users;Uid=reykon;Pwd=19535313");

        public async Task<User> Get()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM registers WHERE userId = 2";

                try
                {
                    cmd.Connection = db;
                    await db.OpenAsync();

                    using MySqlDataReader dr = cmd.ExecuteReader();
                    {
                        if (dr.HasRows)
                        {
                            User u = new User();

                            dr.Read();

                            u.Id = dr.GetInt32(dr.GetOrdinal("userId"));
                            u.FirstName = dr.GetString(dr.GetOrdinal("firstName"));
                            u.LastName = dr.GetString(dr.GetOrdinal("lastName"));
                            u.Age = dr.GetInt32(dr.GetOrdinal("age"));
                            u.Email = dr.GetString(dr.GetOrdinal("email"));
                            u.Username = dr.GetString(dr.GetOrdinal("userName"));
                            u.Password = dr.GetString(dr.GetOrdinal("password"));

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
                    await db.CloseAsync();
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
