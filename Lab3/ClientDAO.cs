using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    public class ClientDAO
    {
        public List<Client> GetAllClients()
        {
            List<Client> clients = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Clients";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    clients = new List<Client>();
                    while (reader.Read())
                    {
                        Client client = new Client();
                        client.Id = reader.GetInt32(0);
                        client.Name = reader.GetString(1);
                        client.Password = reader.GetString(2);
                    }
                }
                reader.Close();
                connection.Close();
            }
            return clients;
        }

        public Client GetClient(string name)
        {
            Client client = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Clients WHERE Name=@name";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    bool flag = true;
                    while (reader.Read() && flag)
                    {
                        client = new Client();
                        client.Id = reader.GetInt32(0);
                        client.Name = reader.GetString(1);
                        client.Password = reader.GetString(2);
                        flag = false;
                    }
                }
                reader.Close();
                connection.Close();
            }
            return client;
        }

        public void AddClient(Client client)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "INSERT INTO Clients (Name, Password) VALUES (@name, @password)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", client.Name);
                command.Parameters.Add(nameParam);
                SqlParameter passwordParam = new SqlParameter("@password", client.Password);
                command.Parameters.Add(passwordParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateClient(Client client)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Clients SET Name=@name, Password=@password WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", client.Name);
                command.Parameters.Add(nameParam);
                SqlParameter passwordParam = new SqlParameter("@password", client.Password);
                command.Parameters.Add(passwordParam);
                SqlParameter idParam = new SqlParameter("@id", client.Id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteClient(int id)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Clients WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
