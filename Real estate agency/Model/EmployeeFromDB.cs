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
    public class EmployeeFromDB
    {
        public Employee FindAgentByPassword(string password, string login)
        {
            Employee agents = new Employee();
            NpgsqlConnection connection = new NpgsqlConnection(DBConnect.connectionStr);
            try
            {
                connection.Open();
                string sqlExp = $"SELECT * FROM find_employee_by_password('{password}', '{login}');";
                NpgsqlCommand command = new NpgsqlCommand(sqlExp, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        agents = (new Employee((int)reader[0], reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), (int)reader[6], reader[7].ToString(), Convert.ToDateTime(reader[8].ToString()), Convert.ToDateTime(reader[9].ToString()), reader[10].ToString()));
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
