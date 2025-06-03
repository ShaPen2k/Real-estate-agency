using Npgsql;
using Real_estate_agency.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Real_estate_agency.Model
{
    public class AgentsFromDB
    {
        public List<Agents> LoadAgents()
        {
            List<Agents> agents = new List<Agents>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM list_employees_sorted_by_id();";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Agents((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), (int)reader[6], reader[7].ToString(), Convert.ToDateTime(reader[8].ToString()), Convert.ToDateTime(reader[9].ToString()), Convert.ToInt32(reader[10]), Convert.ToDouble(reader[11]), reader[12].ToString()));
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

        public void DeleteAgent(Agents agent)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlQuery = $"CALL delete_agent_by_id(@agent_id);";
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@agent_id", agent.Id);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Деталь удалена");
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public void AddNewAgent(Agents agent)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = "select Max(agent_id) from agents";
                int idAgent = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = $"call add_agent(@agent_id, @agent_login, @agent_password, @agent_name, @agent_lastname, @agent_phone, @agent_experience, @agent_email, @agent_birthday, @agent_hiredate, @agent_percent, @agent_amount, @image)";
                cmd.Parameters.AddWithValue("@agent_id", idAgent + 1);
                cmd.Parameters.AddWithValue("@agent_login", agent.Login);
                cmd.Parameters.AddWithValue("@agent_password", agent.Password);
                cmd.Parameters.AddWithValue("@agent_name", agent.Name);
                cmd.Parameters.AddWithValue("@agent_lastname", agent.LastName);
                cmd.Parameters.AddWithValue("@agent_phone", agent.Phone);
                cmd.Parameters.AddWithValue("@agent_experience", agent.Experience);
                cmd.Parameters.AddWithValue("@agent_email", agent.Email);
                cmd.Parameters.AddWithValue("@agent_birthday", agent.Birthday);
                cmd.Parameters.AddWithValue("@agent_hiredate", agent.HireDate);
                cmd.Parameters.AddWithValue("@agent_percent", agent.Percent);
                cmd.Parameters.AddWithValue("@agent_amount", agent.Amount);
                string image = "user.png";
                cmd.Parameters.AddWithValue("@image", image);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Агент добавлен!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }


        public void UpdateAgent(Agents agent)
        {
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            connection.Open();
            NpgsqlTransaction transaction = connection.BeginTransaction();
            NpgsqlCommand cmd = connection.CreateCommand();
            cmd.Transaction = transaction;
            try
            {
                cmd.CommandText = $"call update_agent(@agent_id,@agent_login,@agent_password,@agent_name, @agent_lastname, @agent_phone, @agent_experience, @agent_email, @agent_birthday, @agent_hiredate, @agent_percent, @agent_amount)";
                cmd.Parameters.AddWithValue("@agent_id", agent.Id);
                cmd.Parameters.AddWithValue("@agent_login", agent.Login);
                cmd.Parameters.AddWithValue("@agent_password", agent.Password);
                cmd.Parameters.AddWithValue("@agent_name", agent.Name);
                cmd.Parameters.AddWithValue("@agent_lastname", agent.LastName);
                cmd.Parameters.AddWithValue("@agent_phone", agent.Phone);
                cmd.Parameters.AddWithValue("@agent_experience", agent.Experience);
                cmd.Parameters.AddWithValue("@agent_email", agent.Email);
                cmd.Parameters.AddWithValue("@agent_birthday", agent.Birthday);
                cmd.Parameters.AddWithValue("@agent_hiredate", agent.HireDate);
                cmd.Parameters.AddWithValue("@agent_percent", agent.Percent);
                cmd.Parameters.AddWithValue("@agent_amount", agent.Amount);
                cmd.ExecuteNonQuery();


                MessageBox.Show($"Агент обновлён!");
                transaction.Commit();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
        }

        public List<Agents> SearchAgents(string lastname)
        {
            List<Agents> agents = new List<Agents>();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM search_agents_by_last_name('{lastname}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents.Add(new Agents((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), (int)reader[6], reader[7].ToString(), Convert.ToDateTime(reader[8].ToString()), Convert.ToDateTime(reader[9].ToString()), Convert.ToInt32(reader[10]), Convert.ToDouble(reader[11]), reader[12].ToString()));
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

        public Agents FindAgentByPassword(string password, string login)
        {
            Agents agents = new Agents();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = "SELECT * FROM find_agent_by_password(@p_agent_password, @p_agent_login);";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                command.Parameters.AddWithValue("@p_agent_password", password);
                command.Parameters.AddWithValue("@p_agent_login", login);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents = (new Agents((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), (int)reader[6], reader[7].ToString(), Convert.ToDateTime(reader[8].ToString()), Convert.ToDateTime(reader[9].ToString()), Convert.ToInt32(reader[10]), Convert.ToDouble(reader[11]), reader[12].ToString()));
                    }
                }
                else { return null; }
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
