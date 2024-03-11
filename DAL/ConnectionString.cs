using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ConnectionString
    {
        public static MySqlConnection Connection()
        {
            //return new MySqlConnection("server=localhost;database=useyourfridge;uid=root;pwd=Cesekar4e");
            return new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi507486;Database=dbi507486;Pwd=Cesekar4e; Convert Zero Datetime=True");
        }
    }
}
