using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    public class OrderDAO
    {
        public List<Order> GetAllOrders()
        {
            List<Order> orders = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Orders";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    orders = new List<Order>();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id = reader.GetInt32(0);
                        order.Date = reader.GetDateTime(1);
                        order.Kinotheatr = reader.GetString(2);
                        order.IsPayed = reader.GetBoolean(3);
                        order.ClientId = reader.GetInt32(4);
                        order.MovieId = reader.GetInt32(5);
                        orders.Add(order);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return orders;
        }

        public List<Order> GetOrdersByClient(int clientId)
        {
            List<Order> orders = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Orders WHERE ClientId=@clientId";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter clientIdParam = new SqlParameter("@clientId", clientId);
                command.Parameters.Add(clientIdParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    orders = new List<Order>();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id = reader.GetInt32(0);
                        order.Date = reader.GetDateTime(1);
                        order.Kinotheatr = reader.GetString(2);
                        order.IsPayed = reader.GetBoolean(3);
                        order.ClientId = reader.GetInt32(4);
                        order.MovieId = reader.GetInt32(5);
                        orders.Add(order);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return orders;
        }
        
        public List<Order> GetOrdersByMovie(int movieId)
        {
            List<Order> orders = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Orders WHERE MovieId=@movieId";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter movieIdParam = new SqlParameter("@movieId", movieId);
                command.Parameters.Add(movieIdParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    orders = new List<Order>();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id = reader.GetInt32(0);
                        order.Date = reader.GetDateTime(1);
                        order.Kinotheatr = reader.GetString(2);
                        order.IsPayed = reader.GetBoolean(3);
                        order.ClientId = reader.GetInt32(4);
                        order.MovieId = reader.GetInt32(5);
                        orders.Add(order);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "INSERT INTO Orders (Date, Kinotheatr, IsPayed, ClientId, MovieId) VALUES (@date, @kinotheatr, @isPayed, @clientId, @movieId)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter dateParam = new SqlParameter("@date", order.Date);
                command.Parameters.Add(dateParam);
                SqlParameter kinotheatrParam = new SqlParameter("@kinotheatr", order.Kinotheatr);
                command.Parameters.Add(kinotheatrParam);
                SqlParameter isPayedParam = new SqlParameter("@isPayed", order.IsPayed);
                command.Parameters.Add(isPayedParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", order.ClientId);
                command.Parameters.Add(clientIdParam);
                SqlParameter movieIdParam = new SqlParameter("@movieId", order.MovieId);
                command.Parameters.Add(movieIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Orders SET Date=@date, Kinotheatr=@kinotheatr, IsPayed=@isPayed, ClientId=@clientId, MovieId=@movieId WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", order.Id);
                command.Parameters.Add(idParam);
                SqlParameter dateParam = new SqlParameter("@date", order.Date);
                command.Parameters.Add(dateParam);
                SqlParameter kinotheatrParam = new SqlParameter("@kinotheatr", order.Kinotheatr);
                command.Parameters.Add(kinotheatrParam);
                SqlParameter isPayedParam = new SqlParameter("@isPayed", order.IsPayed);
                command.Parameters.Add(isPayedParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", order.ClientId);
                command.Parameters.Add(clientIdParam);
                SqlParameter movieIdParam = new SqlParameter("@movieId", order.MovieId);
                command.Parameters.Add(movieIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateOrderPayed(int id, bool isPayed)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Orders SET IsPayed=@isPayed WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                SqlParameter isPayedParam = new SqlParameter("@isPayed", isPayed);
                command.Parameters.Add(isPayedParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Orders WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
