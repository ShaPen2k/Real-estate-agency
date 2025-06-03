using Npgsql;
using Real_estate_agency.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Real_estate_agency.Model
{
    public class RealtyFromDB
    {
        //public List<Realty> LoadRealties()
        //{
        //    List<Realty> agents = new List<Realty>();
        //    NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
        //    try
        //    {
        //        connection.Open();
        //        string sqlExp = "SELECT * FROM get_realty_info();";
        //        NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
        //        NpgsqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                agents.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
        //            }
        //        }
        //        reader.Close();
        //        return agents;
        //    }
        //    catch (NpgsqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return agents;
        //    }
        //    finally { connection.Close(); }
        //}

        //public List<Realty> LoadRealties(int page, int pageSize, int? typeId, int? statusId)
        //{
        //    List<Realty> realties = new List<Realty>();
        //    using (var connection = new NpgsqlConnection(DBConnect.connectionStr))
        //    {
        //        connection.Open();
        //        string sql = "SELECT * FROM get_realty_info_filtered_paged(@page, @pageSize, @typeId, @statusId);";
        //        using (var command = new NpgsqlCommand(sql, connection))
        //        {
        //            command.Parameters.AddWithValue("@page", page);
        //            command.Parameters.AddWithValue("@pageSize", pageSize);
        //            command.Parameters.AddWithValue("@typeId", typeId.HasValue ? (object)typeId.Value : DBNull.Value);
        //            command.Parameters.AddWithValue("@statusId", statusId.HasValue ? (object)statusId.Value : DBNull.Value);
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    realties.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
        //                }
        //            }
        //        }
        //    }
        //    return realties;
        //}

        public List<Realty> LoadRealties(int page, int pageSize, int? typeId, int? statusId, decimal? minPrice, decimal? maxPrice, decimal? minArea, decimal? maxArea, int? roomsFilter)
        {
            List<Realty> realties = new List<Realty>();
            using (var connection = new NpgsqlConnection(DBConnect.connectionStr))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM get_realty_info_filtered_paged(@page, @pageSize, @typeId, @statusId, @minPrice, @maxPrice, @minArea, @maxArea, @roomsFilter);";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@page", page);
                        command.Parameters.AddWithValue("@pageSize", pageSize);
                        command.Parameters.AddWithValue("@typeId", typeId.HasValue ? (object)typeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@statusId", statusId.HasValue ? (object)statusId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minPrice", minPrice.HasValue ? (object)minPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxPrice", maxPrice.HasValue ? (object)maxPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minArea", minArea.HasValue ? (object)minArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxArea", maxArea.HasValue ? (object)maxArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@roomsFilter", roomsFilter.HasValue ? (object)roomsFilter.Value : DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                realties.Add(new Realty(
                                    (int)reader[0],                 // realty_id
                                    reader[1].ToString(),          // realty_address
                                    Convert.ToDouble(reader[2]),    // realty_price
                                    reader[3].ToString(),          // realty_type
                                    reader[4].ToString(),          // realty_status_text
                                    Convert.ToDouble(reader[5]),    // realty_area
                                    (int)reader[6],                // realty_rooms
                                    reader[7].ToString(),          // owner_phone
                                    reader[8].ToString(),          // image
                                    reader[9].ToString(),          // url
                                    (int)reader[10],               // floor
                                    reader[11].ToString(),         // underground
                                    reader[12].ToString()          // residential_complex
                                ));
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}");
                }
            }
            return realties;
        }

        public List<Realty> LoadAllRealties(int? typeId, int? statusId, decimal? minPrice, decimal? maxPrice, decimal? minArea, decimal? maxArea, int? roomsFilter)
        {
            List<Realty> realties = new List<Realty>();
            using (var connection = new NpgsqlConnection(DBConnect.connectionStr))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM get_all_realty_info_filtered(@typeId, @statusId, @minPrice, @maxPrice, @minArea, @maxArea, @roomsFilter);";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@typeId", typeId.HasValue ? (object)typeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@statusId", statusId.HasValue ? (object)statusId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minPrice", minPrice.HasValue ? (object)minPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxPrice", maxPrice.HasValue ? (object)maxPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minArea", minArea.HasValue ? (object)minArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxArea", maxArea.HasValue ? (object)maxArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@roomsFilter", roomsFilter.HasValue ? (object)roomsFilter.Value : DBNull.Value);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                realties.Add(new Realty(
                                    (int)reader[0],                 // realty_id
                                    reader[1].ToString(),          // realty_address
                                    Convert.ToDouble(reader[2]),    // realty_price
                                    reader[3].ToString(),          // realty_type
                                    reader[4].ToString(),          // realty_status_text
                                    Convert.ToDouble(reader[5]),    // realty_area
                                    (int)reader[6],                // realty_rooms
                                    reader[7].ToString(),          // owner_phone
                                    reader[8].ToString(),          // image
                                    reader[9].ToString(),          // url
                                    (int)reader[10],               // floor
                                    reader[11].ToString(),         // underground
                                    reader[12].ToString()          // residential_complex
                                ));
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}");
                }
            }
            return realties;
        }

        public int GetTotalRealtiesCount(int? typeId, int? statusId, decimal? minPrice, decimal? maxPrice, decimal? minArea, decimal? maxArea, int? roomsFilter)
        {
            using (var connection = new NpgsqlConnection(DBConnect.connectionStr))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT get_total_realties_count_filtered(@typeId, @statusId, @minPrice, @maxPrice, @minArea, @maxArea, @roomsFilter);";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@typeId", typeId.HasValue ? (object)typeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@statusId", statusId.HasValue ? (object)statusId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minPrice", minPrice.HasValue ? (object)minPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxPrice", maxPrice.HasValue ? (object)maxPrice.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@minArea", minArea.HasValue ? (object)minArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@maxArea", maxArea.HasValue ? (object)maxArea.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@roomsFilter", roomsFilter.HasValue ? (object)roomsFilter.Value : DBNull.Value);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}");
                    return 0;
                }
            }
        }


        public int GetTotalRealtiesCount(int? typeId, int? statusId)
        {
            using (var connection = new NpgsqlConnection(DBConnect.connectionStr))
            {
                connection.Open();
                string sql = "SELECT get_total_realties_count(@typeId, @statusId);";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@typeId", typeId.HasValue ? (object)typeId.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@statusId", statusId.HasValue ? (object)statusId.Value : DBNull.Value);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void DeleteRealty(Realty realty)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = $"CALL delete_realty_by_id(@client_id);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@client_id", realty.Id);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Недвижимость Удалена");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }


        public void AddNewRealty(Realty realty, int type, int status, int idOwner)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "select Max(realty_id) from realty";
                int idAgent = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = $"call add_realty(@realty_id,@realty_address, @realty_price, @realty_type, @realty_area, @realty_rooms, @realty_status, @owner_id, @image, @realty_url, @realty_floor, @realty_underground, @realty_jk)";
                cmd.Parameters.AddWithValue("@realty_id", idAgent+1);
                cmd.Parameters.AddWithValue("@realty_address", realty.Address);
                cmd.Parameters.AddWithValue("@realty_price", realty.Price);
                cmd.Parameters.AddWithValue("@realty_type", type);
                cmd.Parameters.AddWithValue("@realty_status", status);
                cmd.Parameters.AddWithValue("@realty_area", realty.Area);
                cmd.Parameters.AddWithValue("@realty_rooms", realty.Rooms);
                cmd.Parameters.AddWithValue("@realty_area", realty.Area);
                cmd.Parameters.AddWithValue("@owner_id", idOwner);
                cmd.Parameters.AddWithValue("@realty_url", realty.Url);
                cmd.Parameters.AddWithValue("@realty_floor", realty.Floor);
                cmd.Parameters.AddWithValue("@realty_underground", realty.Underground);
                cmd.Parameters.AddWithValue("@realty_jk", realty.Residential_conplex);
                string image = "home.png";
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Недвижимость добавлена!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public string SearchOwnersByPhone(string phone)
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            NpgsqlCommand cmd = connection.CreateCommand();
            try
            {
                connection.Open();
                string sqlQuery = $"SELECT get_owner_id_by_phone('{phone}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@phone", phone);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = reader[0].ToString();
                }
                reader.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return value;
        }


        public void UpdateRealty(Realty realty, int type, int status, int ownerId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = $"call update_realty(@realty_id,@realty_address, @realty_price, @realty_type, @realty_area, @realty_rooms, @realty_status, @owner_id, @realty_url, @realty_floor, @realty_underground, @realty_jk)";
                cmd.Parameters.AddWithValue("@realty_id", realty.Id);
                cmd.Parameters.AddWithValue("@realty_address", realty.Address);
                cmd.Parameters.AddWithValue("@realty_price", realty.Price);
                cmd.Parameters.AddWithValue("@realty_type", type);
                cmd.Parameters.AddWithValue("@realty_status", status);
                cmd.Parameters.AddWithValue("@realty_area", realty .Area);
                cmd.Parameters.AddWithValue("@realty_rooms", realty.Rooms);
                cmd.Parameters.AddWithValue("@owner_id", ownerId);
                cmd.Parameters.AddWithValue("@realty_url", realty.Url);
                cmd.Parameters.AddWithValue("@realty_floor", realty.Floor);
                cmd.Parameters.AddWithValue("@realty_underground", realty.Underground);
                cmd.Parameters.AddWithValue("@realty_jk", realty.Residential_conplex);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Недвижимость обновлёна");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }


        public List<Realty> SearchByType(int TypeId)
        {
            List<Realty> agents = new List<Realty>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM get_realty_info_by_type({TypeId});";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
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

        public List<Realty> SearchByStatus(int StatusId)
        {
            List<Realty> agents = new List<Realty>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM get_realty_info_by_status({StatusId});";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
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

        public List<Realty> SearchByBoth(int TypeId,int StatusId)
        {
            List<Realty> agents = new List<Realty>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM get_realty_info_by_both({TypeId},{StatusId});";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Realty((int)reader[0], reader[1].ToString(), Convert.ToDouble(reader[2]), reader[3].ToString(), reader[4].ToString(), Convert.ToDouble(reader[5]), (int)reader[6], reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10] == DBNull.Value ? 0 : (int)reader[10], reader[11].ToString(), reader[12].ToString()));
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
