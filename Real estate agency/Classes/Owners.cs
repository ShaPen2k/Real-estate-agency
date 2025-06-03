using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class Owners
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public Owners() { }

        public Owners(int id, string name, string lastName, string phone, string email, string image)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Email = email;
            if (File.Exists(@"..\..\..\Images\Owners\" + image))
            {
                Image = @"..\..\..\Images\Owners\" + image;
            }
            else
            {
                Image = @"..\..\..\Images\user.png";
            }
        }
    }
}
