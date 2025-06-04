using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class ViewedClients
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public ViewedClients(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
    }
}
