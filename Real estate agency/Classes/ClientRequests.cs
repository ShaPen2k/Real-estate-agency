using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class ClientRequests
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int RealtyId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string RealtyAddress { get; set; }

        public DateTime Request_date { get; set; }

        public ClientRequests() { }
        public ClientRequests(int id, int clientId, int realtyId, string name, string lastName, string realtyAddress, DateTime request_date)
        {
            Id = id;
            ClientId = clientId;
            RealtyId = realtyId;
            Name = name;
            LastName = lastName;
            RealtyAddress = realtyAddress;
            Request_date = request_date;
        }
    }
}
