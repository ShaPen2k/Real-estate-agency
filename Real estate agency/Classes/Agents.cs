using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class Agents
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int Experience { get; set; }

        public string Email {  get; set; }

        public DateTime Birthday { get; set; }

        public DateTime HireDate { get; set; }

        public int Percent {  get; set; }

        public double Amount { get; set; }

        public string Image {  get; set; }

        public Agents() { }

        public Agents(int id, string login, string password,string name, string lastName, string phone, int experience, string email, DateTime birthday, DateTime hireDate, int percent, double amount, string image)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Experience = experience;
            Email = email;
            Birthday = birthday;
            HireDate = hireDate;
            Percent = percent;
            Amount = amount;
            if (File.Exists(@"..\..\..\Images\Agents\" + image))
            {
                Image = @"..\..\..\Images\Agents\" + image;
            }
            else
            {
                Image = @"..\..\..\Images\user.png";
            }
        }
    }
}
