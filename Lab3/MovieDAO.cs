using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.SqlClient;

namespace Lab3
{
    public class MovieDAO
    {
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Movies";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    movies = new List<Movie>();
                    while (reader.Read())
                    {
                        Movie movie = new Movie();
                        movie.Id = reader.GetInt32(0);
                        movie.Name = reader.GetString(1);
                        movie.Date = reader.GetDateTime(2);
                        movie.Producer = reader.GetString(3);
                        movie.Genre = reader.GetString(4);
                        movie.Actors = reader.GetString(5);
                        movie.Duration = reader.GetInt32(6);
                        movies.Add(movie);
                    }
                    reader.Close();
                    connection.Close();
                } 
            }
            return movies;
        }

        public List<Movie> GetMoviesByName(string name)
        {
            List<Movie> movies = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Movies WHERE Name=@name";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    movies = new List<Movie>();
                    while (reader.Read())
                    {
                        Movie movie = new Movie();
                        movie.Id = reader.GetInt32(0);
                        movie.Name = reader.GetString(1);
                        movie.Date = reader.GetDateTime(2);
                        movie.Producer = reader.GetString(3);
                        movie.Genre = reader.GetString(4);
                        movie.Actors = reader.GetString(5);
                        movie.Duration = reader.GetInt32(6);
                        movies.Add(movie);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return movies;
        }

        public List<Movie> GetMoviesByProducer(string producer)
        {
            List<Movie> movies = null;
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM Movies WHERE Producer=@producer";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter producerParam = new SqlParameter("@producer", producer);
                command.Parameters.Add(producerParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    movies = new List<Movie>();
                    while (reader.Read())
                    {
                        Movie movie = new Movie();
                        movie.Id = reader.GetInt32(0);
                        movie.Name = reader.GetString(1);
                        movie.Date = reader.GetDateTime(2);
                        movie.Producer = reader.GetString(3);
                        movie.Genre = reader.GetString(4);
                        movie.Actors = reader.GetString(5);
                        movie.Duration = reader.GetInt32(6);
                        movies.Add(movie);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return movies;
        }

        public void AddMovie(Movie movie)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "INSERT INTO Movies (Name, Date, Producer, Genre, Actors, Duration) VALUES (@name, @date, @producer, @genre, @actors, @duration)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(nameParam);
                SqlParameter dateParam = new SqlParameter("@date", movie.Date);
                command.Parameters.Add(dateParam);
                SqlParameter producerParam = new SqlParameter("@producer", movie.Producer);
                command.Parameters.Add(producerParam);
                SqlParameter genreParam = new SqlParameter("@genre", movie.Genre);
                command.Parameters.Add(genreParam);
                SqlParameter actorsParam = new SqlParameter("@actors", movie.Actors);
                command.Parameters.Add(actorsParam);
                SqlParameter durationParam = new SqlParameter("@duration", movie.Duration);
                command.Parameters.Add(durationParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "UPDATE Movies SET Name=@name, Date=@date, Producer=@producer, Genre=@genre, Actors=@actors, Duration=@duration WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", movie.Id);
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter("@name", movie.Name);
                command.Parameters.Add(nameParam);
                SqlParameter dateParam = new SqlParameter("@date", movie.Date);
                command.Parameters.Add(dateParam);
                SqlParameter producerParam = new SqlParameter("@producer", movie.Producer);
                command.Parameters.Add(producerParam);
                SqlParameter genreParam = new SqlParameter("@genre", movie.Genre);
                command.Parameters.Add(genreParam);
                SqlParameter actorsParam = new SqlParameter("@actors", movie.Actors);
                command.Parameters.Add(actorsParam);
                SqlParameter durationParam = new SqlParameter("@duration", movie.Duration);
                command.Parameters.Add(durationParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteMovie(int id)
        {
            using (SqlConnection connection = Config.GetConnection())
            {
                connection.Open();
                string sqlExpression = "DELETE FROM Movies WHERE Id=@id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
