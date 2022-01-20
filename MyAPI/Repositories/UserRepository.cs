using MySql.Data.MySqlClient;
using System;
using MyAPI.Model;
using MyAPI.ViewModel;
using System.Threading.Tasks;
using MyAPI.Database;

namespace MyAPI.Repositories
{
    public class UserRepository
    {

        private readonly MySqlDatabase db = new MySqlDatabase
        ("Server=localhost;Database=users;Uid=reykon;Pwd=19535313");


        public async Task<UserViewModel> Get()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM registers WHERE user_id = 1";

                try
                {
                    cmd.Connection = db.Get();
                    db.ConnectAsync();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            UserViewModel u = new UserViewModel();

                            await Task.Run(() => dr.Read());


                            u.Id = dr.GetInt32(dr.GetOrdinal("user_id"));
                            u.FirstName = dr.GetString(dr.GetOrdinal("first_name"));
                            u.LastName = dr.GetString(dr.GetOrdinal("last_name"));
                            u.Age = dr.GetInt32(dr.GetOrdinal("age"));
                            u.Email = dr.GetString(dr.GetOrdinal("email"));
                            u.Username = dr.GetString(dr.GetOrdinal("user_name"));
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
                    db.DisconnectAsync();
                }
                return null;
            }
        }


        public async Task InsertUser(User u)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO registers (first_name, last_name, age, email, user_name, password)" +
                                  " VALUES (@first_name, @last_name, @age, @email, @user_name, @password)";

                try
                {
                    cmd.Connection = db.Get();

                    cmd.Parameters.AddWithValue("@first_name", u.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", u.LastName);
                    cmd.Parameters.AddWithValue("@age", u.Age);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@user_name", u.Username);
                    cmd.Parameters.AddWithValue("@password", u.Password);

                    db.ConnectAsync();
                    await Task.Run(() => cmd.ExecuteNonQuery());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    db.DisconnectAsync();
                }
            }
        }

    }
}
