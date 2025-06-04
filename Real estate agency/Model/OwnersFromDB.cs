using Npgsql;
using Real_estate_agency.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.IO.RecyclableMemoryStreamManager;

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
        public Owners GetOwnerByPhone(string phone)
        {
            Owners agents = new Owners();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM get_owner_by_phone('{phone}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents = (new Owners((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
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
        public List<Realty> GetApartmentsByOwnerId(int ownerId)
        {
            List<Realty> apartments = new List<Realty>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM Realty WHERE owner_id = @ownerId";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                command.Parameters.AddWithValue("@ownerId", ownerId);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    apartments.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
                }
                reader.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return apartments;
        }

        public Realty GetApartmentByAddress(string address)
        {
            Realty apartments = new Realty();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT r.realty_id, r.realty_address, r.realty_price, rt.realty_type_text, rs.realty_status_text, r.realty_area, r.realty_rooms, o.owner_phone, r.image, r.url, r.floor, r.underground, r.residential_complex FROM realty r INNER JOIN realty_status rs ON r.realty_status_id = rs.realty_status_id INNER JOIN owners o ON r.owner_id = o.owner_id INNER JOIN realty_type rt ON r.realty_type_id = rt.realty_type_id WHERE r.realty_address = '{address}';";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                command.Parameters.AddWithValue("@address", address);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    apartments = (new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
                }
                reader.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return apartments;
        }
    }
}