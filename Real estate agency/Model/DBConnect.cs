using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_estate_agency.Model
{
    public class DBConnect
    {
        internal static string connectionStr = @"Server=localhost; Port=5432 ; DataBase=Real_Estate_Agency2; User Id=postgres ;Password=postgres";
        //internal static string connectionStr = @"Server=172.20.105.123; Port=5432 ; DataBase=Real_Estate_Agency; User Id=9po11-21-7 ;Password=oPieN9Ph";
        //internal static string connectionStr = @"Server=localhost; Port=5432 ; DataBase=AutoMotorsShop; User Id=postgres ;Password=1";
    }
}
