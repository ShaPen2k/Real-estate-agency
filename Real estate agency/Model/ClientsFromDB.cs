using Npgsql;
using Real_estate_agency.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Real_estate_agency.Model
{
    public class ClientsFromDB
    {
        public List<Clients> LoadClients()
        {
            List<Clients> agents = new List<Clients>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM list_clients_sorted_by_id();";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Clients((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                    }
                }
                reader.Close();
                return agents;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return agents;
            }
            finally { connection.Close(); }
        }

        public void AddNewClient(Clients clients)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "select Max(client_id) from clients";
                int idAgent = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = $"call add_client(@client_id, @client_name, @client_lastname, @client_phone, @client_email, @image)";
                cmd.Parameters.AddWithValue("@client_id", idAgent + 1);
                cmd.Parameters.AddWithValue("@client_name", clients.Name);
                cmd.Parameters.AddWithValue("@client_lastname", clients.LastName);
                cmd.Parameters.AddWithValue("@client_phone", clients.Phone);
                cmd.Parameters.AddWithValue("@client_email", clients.Email);
                string image = "user.png";
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Клиент добавлен!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void UpdateClient(Clients clients)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = $"call update_client(@client_id,@client_name, @client_lastname, @client_phone, @client_email)";
                cmd.Parameters.AddWithValue("@client_id", clients.Id);
                cmd.Parameters.AddWithValue("@client_name", clients.Name);
                cmd.Parameters.AddWithValue("@client_lastname", clients.LastName);
                cmd.Parameters.AddWithValue("@client_phone", clients.Phone);
                cmd.Parameters.AddWithValue("@client_email", clients.Email);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Клиент обновлён!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void DeleteClient(Clients clients)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = $"CALL delete_client_by_id(@client_id);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@client_id", clients.Id);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Клиент Удалён");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public List<Clients> SearchClients(string lastname)
        {
            List<Clients> agents = new List<Clients>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM search_clients_by_last_name('{lastname}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Clients((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                    }
                }
                reader.Close();
                return agents;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return agents;
            }
            finally { connection.Close(); }
        }
    }
}
