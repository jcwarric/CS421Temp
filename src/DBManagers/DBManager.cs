using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace ARTchive.DBManagers
{
    public class DBManager
    {

        protected string connectionString;
        private string provider;

        public DBManager()
        {
            provider = "System.Data.SqlClient";
            
            //path to connect to the SqlServer database
            connectionString = "Data Source=artchive.database.windows.net;Initial Catalog=ARTchive;User ID=capstone;Password=S0mething!23";

        }
    }
}
