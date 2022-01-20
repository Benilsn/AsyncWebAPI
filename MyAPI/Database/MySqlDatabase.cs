using System.Data;
using System;
using MySql.Data.MySqlClient;

namespace MyAPI.Database
{
    public class MySqlDatabase
    {
        private readonly MySqlConnection con;

        public MySqlDatabase(string connectionString) 
        {
            con = new MySqlConnection(connectionString);
        }

        public MySqlConnection Get()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    return con;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message) ;
            }

            return null;
        }

        public async void ConnectAsync()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    await con.OpenAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void DisconnectAsync()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    await con.CloseAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
