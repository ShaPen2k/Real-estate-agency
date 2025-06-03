using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Real_estate_agency.Model
{
    public class StatsFromDB
    {
        public string getAllAgents()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_agents();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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
        public string getPercentAgent()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select get_avg_agent_percent();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgAgentAmount()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_agent_amount();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostFlat1Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_1room_type_flat();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostFlat2Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_2room_type_flat();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostFlat3Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_3room_type_flat();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostFlat4Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_4room_type_flat();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostHouse5Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_5room_type_house();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostHouse6Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_6room_type_house();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostHouse7Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_7room_type_house();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getAvgCostHouse8Room()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "select avg_realty_8room_type_house();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountFlatStatus1()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_flat_and_status1();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountFlatStatus2()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_flat_and_status2();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountFlatStatus3()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_flat_and_status3();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountHouseStatus1()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_house_and_status1();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountHouseStatus2()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_house_and_status2();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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

        public string getCountHouseStatus3()
        {
            string value = "";
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = "SELECT count_realty_by_house_and_status3();";
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
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
    }
}
