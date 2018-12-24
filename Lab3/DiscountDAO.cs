using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    public class DiscountDAO
    {
        public List<Discount> GetDiscount(int clientId)
        {
            List<Discount> discounts = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Discounts WHERE ClientId=@clientId";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter clientIdParam = new SqlParameter("@clientId", clientId);
                command.Parameters.Add(clientIdParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    discounts = new List<Discount>();
                    while (reader.Read())
                    {
                        Discount discount = new Discount();
                        discount.Id = reader.GetInt32(0);
                        discount.Percent = reader.GetInt32(1);
                        discount.Validity = reader.GetDateTime(2);
                        discount.ClientId = reader.GetInt32(3);
                        discounts.Add(discount);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return discounts;
        }

        public void AddDiscount(Discount discount)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "INSERT INTO Discounts (\"Percent\", Validity, ClientId) VALUES (@percent, @validity, @clientId)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter percentParam = new SqlParameter("@percent", discount.Percent);
                command.Parameters.Add(percentParam);
                SqlParameter validityParam = new SqlParameter("@validity", discount.Validity);
                command.Parameters.Add(validityParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", discount.ClientId);
                command.Parameters.Add(clientIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        
        public void UpdateDiscount(Discount discount)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Discounts SET \"Percent\"=@percent, Validity=@validity, ClientId=@clientId WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", discount.Id);
                command.Parameters.Add(idParam);
                SqlParameter percentParam = new SqlParameter("@percent", discount.Percent);
                command.Parameters.Add(percentParam);
                SqlParameter validityParam = new SqlParameter("@validity", discount.Validity);
                command.Parameters.Add(validityParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", discount.ClientId);
                command.Parameters.Add(clientIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteDiscount(int id)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Discounts WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteUnactiveDiscount()
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Discounts WHERE Validity < @validity";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                DateTime date = DateTime.Now;
                SqlParameter validityParam = new SqlParameter("@validity", date);
                command.Parameters.Add(validityParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
