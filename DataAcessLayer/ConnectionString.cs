using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Configuration.Internal;



namespace DataAcessLayer
{
    public class ConnectionString
    {
        public static string ConnString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
    }
}
