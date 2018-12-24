using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    public class CommentDAO
    {
        public List<Comment> GetAllComments()
        {
            List<Comment> comments = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Comments";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    comments = new List<Comment>();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.Id = reader.GetInt32(0);
                        comment.Text = reader.GetString(1);
                        comment.Date = reader.GetDateTime(2);
                        comment.ClientId = reader.GetInt32(3);
                        comment.MovieId = reader.GetInt32(4);
                        comments.Add(comment);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return comments;
        }

        public List<Comment> GetCommentsByClient(int clientId)
        {
            List<Comment> comments = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Comments WHERE ClientId=@clientId";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter clientIdParam = new SqlParameter("@clientId", clientId);
                command.Parameters.Add(clientIdParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    comments = new List<Comment>();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.Id = reader.GetInt32(0);
                        comment.Text = reader.GetString(1);
                        comment.Date = reader.GetDateTime(2);
                        comment.ClientId = reader.GetInt32(3);
                        comment.MovieId = reader.GetInt32(4);
                        comments.Add(comment);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return comments;
        }

        public List<Comment> GetCommentsByMovie(int movieId)
        {
            List<Comment> comments = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Comments WHERE MovieId=@movieId";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter movieIdParam = new SqlParameter("@movieId", movieId);
                command.Parameters.Add(movieIdParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    comments = new List<Comment>();
                    while (reader.Read())
                    {
                        Comment comment = new Comment();
                        comment.Id = reader.GetInt32(0);
                        comment.Text = reader.GetString(1);
                        comment.Date = reader.GetDateTime(2);
                        comment.ClientId = reader.GetInt32(3);
                        comment.MovieId = reader.GetInt32(4);
                        comments.Add(comment);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return comments;
        }

        public void AddComment(Comment comment)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "INSERT INTO Comments (Text, Date, ClientId, MovieId) VALUES (@text, @date, @clientId, @movieId)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter textParam = new SqlParameter("@text", comment.Text);
                command.Parameters.Add(textParam);
                SqlParameter dateParam = new SqlParameter("@date", comment.Date);
                command.Parameters.Add(dateParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", comment.ClientId);
                command.Parameters.Add(clientIdParam);
                SqlParameter movieIdParam = new SqlParameter("@movieId", comment.MovieId);
                command.Parameters.Add(movieIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateComment(Comment comment)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Comments SET Text=@text, Date=@date, ClientId=@clientId, MovieId=@movieId WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", comment.Id);
                command.Parameters.Add(idParam);
                SqlParameter textParam = new SqlParameter("@text", comment.Text);
                command.Parameters.Add(textParam);
                SqlParameter dateParam = new SqlParameter("@date", comment.Date);
                command.Parameters.Add(dateParam);
                SqlParameter clientIdParam = new SqlParameter("@clientId", comment.ClientId);
                command.Parameters.Add(clientIdParam);
                SqlParameter movieIdParam = new SqlParameter("@movieId", comment.MovieId);
                command.Parameters.Add(movieIdParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteComment(int id)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Comments WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }        
    }
}
