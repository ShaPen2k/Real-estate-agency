using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Classes
{
    public class Realty
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public double Area { get; set; }

        public int Rooms { get; set; }

        public string OwnerPhone { get; set; }

        public string Image {  get; set; }

        public string Url { get; set; }

        public int Floor { get; set; }

        public string Underground { get; set; }

        public string Residential_conplex {  get; set; }

        public Realty() { }

        public Realty(int id, string address, double price, string type, string status, double area, int rooms, string ownerPhone, string image, string url, int floor, string underground, string residential_conplex)
        {
            Id = id;
            Address = address;
            Price = price;
            Type = type;
            Status = status;
            Area = area;
            Rooms = rooms;
            OwnerPhone = ownerPhone;
            if (File.Exists(@"..\..\..\Images\Realty\" + image))
            {
                Image = @"..\..\..\Images\Realty\" + image;
            }
            else
            {
                Image = @"..\..\..\Images\home.png";
            }

            Url = url;
            Floor = floor;
            Underground = underground;
            Residential_conplex = residential_conplex;
        }
    }
}
