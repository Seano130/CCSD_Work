using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Multi_DBMS
{
    class Program
    {
        static void Main(string[] args)
        {

            Wrapper_MySQLConnection ORACLE = new Wrapper_MySQLConnection();
            Wrapper_SQLConnection MICROSOFT = new Wrapper_SQLConnection();
            API_SQL_Connection connection = new API_SQL_Connection(ORACLE);
            connection.Open();


        }
    }
}
