using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab3
{
    public class Config
    {
        public static SqlConnection GetConnection()
        {
                            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBMovies.mdf;Integrated Security=True";
                    /*ConfigurationManager.ConnectionStrings["DBMovies"].ConnectionString;*/
                return new SqlConnection(connectionString);
        }
    }
}
