using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;

namespace Lab3.Tests
{
    [TestClass()]
    public class MovieDAOTests
    {

        [TestMethod()]
        public void GetMoviesByNameTest()
        {
            Movie movie = new Movie();
            movie.Name = "Cinderella";
            movie.Date = new DateTime(1950, 2, 15);
            movie.Producer = "Clyde Geronimi, Hamilton Luske, Wilfred Jackson";
            movie.Actors = "Ilene Woods, Eleanor Audley, Verna Felton";
            movie.Genre = "animated, musical, fantasy";
            movie.Duration = 75;
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.AddMovie(movie);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(movie));

            movie = new Movie();
            movie.Name = "Cinderella";
            movie.Date = new DateTime(2015, 2, 13);
            movie.Producer = "Kenneth Branagh";
            movie.Actors = "Cate Blanchett, Lily James, Richard Madden";
            movie.Genre = "romantic, fantasy";
            movie.Duration = 106;
            movieDAO.AddMovie(movie);
            expected.Add(ToStringWithoutId(movie));

            List<Movie> list = movieDAO.GetMoviesByName(movie.Name);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMoviesByProducerTest()
        {
            Movie movie = new Movie();
            movie.Name = "Harry Potter and the Philosopher's Stone";
            movie.Date = new DateTime(2001, 11, 4);
            movie.Producer = "Chris Columbus";
            movie.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson";
            movie.Genre = "fantasy";
            movie.Duration = 152;
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.AddMovie(movie);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(movie));

            movie = new Movie();
            movie.Name = "Harry Potter and the Chamber of Secrets";
            movie.Date = new DateTime(2002, 11, 3);
            movie.Producer = "Chris Columbus";
            movie.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson";
            movie.Genre = "fantasy";
            movie.Duration = 161;
            movieDAO.AddMovie(movie);
            expected.Add(ToStringWithoutId(movie));

            List<Movie> list = movieDAO.GetMoviesByProducer(movie.Producer);
            if (list == null|| list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddMovieTest()
        {
            Movie movie = new Movie();
            movie.Name = "Harry Potter and the Philosopher's Stone";
            movie.Date = new DateTime(2001, 11, 4);
            movie.Producer = "Chris Columbus";
            movie.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson";
            movie.Genre = "fantasy";
            movie.Duration = 152;
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.AddMovie(movie);

            List<Movie> list = movieDAO.GetMoviesByName(movie.Name);
            if (list == null || list.Count == 0)
                Assert.Fail();
            string expected = ToStringWithoutId(movie);
            string actual = ToStringWithoutId(list[list.Count - 1]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateMovieTest()
        {
            Movie movie = new Movie();
            movie.Name = "Harry Potter and the Philosopher's Stone";
            movie.Date = new DateTime(2001, 11, 4);
            movie.Producer = "Chris Columbus";
            movie.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson";
            movie.Genre = "fantasy";
            movie.Duration = 152;
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.AddMovie(movie);

            List<Movie> list = movieDAO.GetMoviesByName(movie.Name);
            movie = list[list.Count - 1];
            movie.Name = "Harry Potter 1";
            movieDAO.UpdateMovie(movie);

            list = movieDAO.GetMoviesByName(movie.Name);
            string expected = ToStringWithoutId(movie);
            string actual = ToStringWithoutId(list[list.Count - 1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteMovieTest()
        {
            Movie movie = new Movie();
            movie.Name = "Harry Potter and the Philosopher's Stone";
            movie.Date = new DateTime(2001, 11, 4);
            movie.Producer = "Chris Columbus";
            movie.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson";
            movie.Genre = "fantasy";
            movie.Duration = 152;
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.AddMovie(movie);

            List<Movie> list = movieDAO.GetMoviesByName(movie.Name);
            movie = list[list.Count - 1];
            movieDAO.DeleteMovie(movie.Id);

            list = movieDAO.GetMoviesByName(movie.Name);

            Assert.IsFalse(list.Exists(l => l.Id == movie.Id));
        }

        string ToStringWithoutId(Movie movie)
        {
            if (movie == null)
                return null;
            string line = movie.Name + " " + movie.Date.ToString() + " " + movie.Producer + " " + movie.Genre + " " + movie.Actors + " " + movie.Duration.ToString();
            return line;
        }
    }
}