using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;
using Real_estate_agency.Classes;

namespace Real_estate_agency.Model
{
    public class ClientsRequestsFromDB
    {
        public List<ClientRequests> LoadClientsRequests()
        {
            List<ClientRequests> agents = new List<ClientRequests>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM get_client_requests();";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new ClientRequests((int)reader[0], (int)reader[1], (int)reader[2], reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToDateTime(reader[6].ToString())));
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

        public void AddNewClient(ClientRequests clients)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "select Max(client_request_id) from client_requests";
                int idAgent = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = $"call add_client_request(@client_id, @client_name, @client_lastname)";
                cmd.Parameters.AddWithValue("@client_id", idAgent + 1);
                cmd.Parameters.AddWithValue("@client_name", clients.ClientId);
                cmd.Parameters.AddWithValue("@client_lastname", clients.RealtyId);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Заявка добавлена!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void UpdateClient(ClientRequests clients)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = $"call update_client_request(@client_id, @client_name, @client_lastname)";
                cmd.Parameters.AddWithValue("@client_id", clients.Id);
                cmd.Parameters.AddWithValue("@client_name", clients.ClientId);
                cmd.Parameters.AddWithValue("@client_lastname", clients.RealtyId);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Заявка обновлена!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void delete_client_request(ClientRequests client)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = $"CALL delete_client_request(@client_id);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@client_id", client.Id);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Заявка удалена");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public List<ClientRequests> SearchClients(string lastname)
        {
            List<ClientRequests> agents = new List<ClientRequests>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM search_client_requests_by_query('{lastname}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new ClientRequests((int)reader[0], (int)reader[1], (int)reader[2], reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToDateTime(reader[6].ToString())));
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
