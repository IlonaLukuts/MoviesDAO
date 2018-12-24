using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    class AdministratorDAO
    {
        public Administrator GetAdministrator(string name)
        {
            Administrator administrator = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Administrators WHERE Name=@name";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    administrator = new Administrator();
                    administrator.Id = reader.GetInt32(0);
                    administrator.Name = reader.GetString(1);
                    administrator.Password = reader.GetString(2);
                }
                reader.Close();
                connection.Close();
            }
            return administrator;            
        }
    }
}
