using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class Employee
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public int Experience { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime HireDate { get; set; }


        public string Image { get; set; }

        public Employee() { }

        public Employee(int id, string login, string password, string name, string lastName, string phone, int experience, string email, DateTime birthday, DateTime hireDate, string image)
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
            if (File.Exists(@"..\..\..\Images\" + image))
            {
                Image = @"..\..\..\Images\" + image;
            }
            else
            {
                Image = @"..\..\..\Images\user.png";
            }
        }
    }
}
