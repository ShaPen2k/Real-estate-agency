using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Real_estate_agency.Classes
{
    public class Deals
    {
        public int Id { get; set; }

        public string RealtyImage { get; set; }

        public string OwnerName { get; set; }

        public string OwnerLastname { get; set; }

        public string CombinedOwner => $"{OwnerName} {OwnerLastname}";

        public string OwnerPhone { get; set; }

        public string OwnerImage { get; set; }

        public string ClientName { get; set; }

        public string ClientLastname { get; set; }

        public string CombinedClient => $"{ClientName} {ClientLastname}";

        public string ClientPhone { get; set; }

        public string ClientImage { get; set; }

        public string AgentName { get; set; }

        public string AgentLastname { get; set; }

        public string CombinedAgent => $"{AgentName} {AgentLastname}";

        public string AgentPhone { get; set; }

        public string AgentImage { get; set; }


        public DateTime DealDate { get; set; }

        public double DealCost { get; set; }

        public Deals() { }
        public Deals(int id, string realtyImage, string ownerName, string ownerLastname, string ownerPhone, string ownerImage, string clientName, string clientLastname, string clientPhone, string clientImage, string agentName, string agentLastname, string agentPhone, string agentImage, DateTime dealDate, double dealCost)
        {
            Id = id;
            if (File.Exists(@"..\..\..\Images\Realty\" + realtyImage))
            {
                RealtyImage = @"..\..\..\Images\Realty\" + realtyImage;
            }
            else
            {
                RealtyImage = @"..\..\..\Images\home.png";
            }
            OwnerName = ownerName;
            OwnerLastname = ownerLastname;
            OwnerPhone = ownerPhone;
            if (File.Exists(@"..\..\..\Images\Owners\" + ownerImage))
            {
                OwnerImage = @"..\..\..\Images\Owners\" + ownerImage;
            }
            else
            {
                OwnerImage = @"..\..\..\Images\user.png";
            }
            ClientName = clientName;
            ClientLastname = clientLastname;
            ClientPhone = clientPhone;
            if (File.Exists(@"..\..\..\Images\Clients\" + clientImage))
            {
                ClientImage = @"..\..\..\Images\Clients\" + clientImage;
            }
            else
            {
                ClientImage = @"..\..\..\Images\user.png";
            }
            AgentName = agentName;
            AgentLastname = agentLastname;
            AgentPhone = agentPhone;
            if (File.Exists(@"..\..\..\Images\Agents\" + agentImage))
            {
                AgentImage = @"..\..\..\Images\Agents\" + agentImage;
            }
            else
            {
                AgentImage = @"..\..\..\Images\user.png";
            }
            DealDate = dealDate;
            DealCost = dealCost;
        }
    }
}
