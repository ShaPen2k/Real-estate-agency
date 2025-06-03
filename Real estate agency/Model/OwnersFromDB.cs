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
    public class OwnersFromDB
    {
        public List<Owners> LoadOwners()
        {
            List<Owners> agents = new List<Owners>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM list_owners_sorted_by_id();";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Owners((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
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

        public void AddNewOwner(Owners owners)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "select Max(owner_id) from owners";
                int idAgent = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = $"call add_owner(@client_id, @client_name, @client_lastname, @client_phone, @client_email, @image)";
                cmd.Parameters.AddWithValue("@client_id", idAgent + 1);
                cmd.Parameters.AddWithValue("@client_name", owners.Name);
                cmd.Parameters.AddWithValue("@client_lastname", owners.LastName);
                cmd.Parameters.AddWithValue("@client_phone", owners.Phone);
                cmd.Parameters.AddWithValue("@client_email", owners.Email);
                string image = "user.png";
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Владелец добавлен!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void UpdateOwner(Owners owners)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = $"call update_owner(@client_id,@client_name, @client_lastname, @client_phone, @client_email)";
                cmd.Parameters.AddWithValue("@client_id", owners.Id);
                cmd.Parameters.AddWithValue("@client_name", owners.Name);
                cmd.Parameters.AddWithValue("@client_lastname", owners.LastName);
                cmd.Parameters.AddWithValue("@client_phone", owners.Phone);
                cmd.Parameters.AddWithValue("@client_email", owners.Email);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Владелец обновлён!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public void DeleteOwner(Owners owners)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = $"CALL delete_owner_by_id(@client_id);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@client_id", owners.Id);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Владелец Удалён");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public List<Owners> SearchOwners(string lastname)
        {
            List<Owners> agents = new List<Owners>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM search_owners_by_last_name('{lastname}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Owners((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
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
