using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class Demands
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientLastName { get; set; }

        public string CombinedClient => $"{ClientName} {ClientLastName}";
        public string ClientPhone { get; set; }

        public string ClientImage { get; set; }

        public string RealtyType { get; set; }

        public string Cost {  get; set; }

        public string Area { get; set; }

        public string Rooms { get; set; }

        public Demands(int id, int clientId, string clientName, string clientLastName, string clientPhone, string clientImage, string realtyType, string cost, string area, string rooms)
        {
            Id = id;
            ClientId = clientId;
            ClientName = clientName;
            ClientLastName = clientLastName;
            if (File.Exists(@"..\..\..\Images\Clients\" + clientImage))
            {
                ClientImage = @"..\..\..\Images\Clients\" + clientImage;
            }
            else
            {
                ClientImage = @"..\..\..\Images\user.png";
            }
            ClientPhone = clientPhone;
            RealtyType = realtyType;
            Cost = cost;
            Area = area;
            Rooms = rooms;
        }
    }
}
