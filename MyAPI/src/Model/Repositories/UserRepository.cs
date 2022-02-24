using MyAPI.src.Model.Entities.User;
using MyAPI.src.Model.Repositories.IRepositories;
using MyAPI.src.Model.Services.Password;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;


namespace MyAPI.src.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlConnection db = new MySqlConnection
        ("Server=localhost;Database=users;Uid=reykon;Pwd=19535313");


        public async Task<string> GetByEmail(string userEmail)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText =
               "SELECT email FROM registers where email = @email";

                try
                {
                    cmd.Connection = db;
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    await db.OpenAsync();

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
                    await db.CloseAsync();
                }
                return null;
            }
        }

        public async Task<HashSalt> CheckPassword(string userEmail)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText =
               "SELECT hash, salt FROM registers where email = @email";

                try
                {
                    cmd.Connection = db;
                    cmd.Parameters.AddWithValue("@email", userEmail);
                    await db.OpenAsync();

                    using MySqlDataReader dr = cmd.ExecuteReader();
                    {
                        if (dr.HasRows)
                        {
                            HashSalt hash = new HashSalt();

                            dr.Read();

                            hash.Hash = dr.GetString(dr.GetOrdinal("hash"));
                            hash.Salt = dr.GetString(dr.GetOrdinal("salt"));

                            return hash;
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

        public async Task InsertUser(User u, HashSalt hash)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO registers (firstName, lastName, age, email, hash, salt)" +
                                  " VALUES (@firstName, @lastName, @age, @email, @hash, @salt)";

                try
                {
                    cmd.Connection = db;

                    cmd.Parameters.AddWithValue("@firstName", u.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", u.LastName);
                    cmd.Parameters.AddWithValue("@age", u.Age);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@hash", hash.Hash);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);

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
