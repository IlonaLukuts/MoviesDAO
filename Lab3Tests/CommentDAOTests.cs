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
    public class CommentDAOTests
    {
        [TestMethod()]
        public void GetCommentsByClientTest()
        {
            Comment comment = new Comment();
            comment.Text = "Very nice.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 10;
            CommentDAO commentDAO = new CommentDAO();
            commentDAO.AddComment(comment);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(comment));

            comment = new Comment();
            comment.Text = "It's the worst movie I've ever seen.";
            comment.Date = DateTime.Now;
            comment.MovieId = 7;
            comment.ClientId = 10;
            commentDAO.AddComment(comment);
            expected.Add(ToStringWithoutId(comment));

            List<Comment> list = commentDAO.GetCommentsByClient((int)comment.ClientId);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCommentsByMovieTest()
        {
            Comment comment = new Comment();
            comment.Text = "Very nice.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 10;
            CommentDAO commentDAO = new CommentDAO();
            commentDAO.AddComment(comment);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(comment));

            comment = new Comment();
            comment.Text = "It's the worst movie I've ever seen.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 7;
            commentDAO.AddComment(comment);
            expected.Add(ToStringWithoutId(comment));

            List<Comment> list = commentDAO.GetCommentsByMovie((int)comment.MovieId);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i <list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddCommentTest()
        {
            Comment comment = new Comment();
            comment.Text = "Very nice.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 10;
            CommentDAO commentDAO = new CommentDAO();
            commentDAO.AddComment(comment);

            List<Comment> list = commentDAO.GetCommentsByMovie((int)comment.MovieId);
            if (list == null || list.Count == 0)
                Assert.Fail();
            string expected = ToStringWithoutId(comment);
            string actual = ToStringWithoutId(list[list.Count - 1]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateCommentTest()
        {
            Comment comment = new Comment();
            comment.Text = "Very nice.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 10;
            CommentDAO commentDAO = new CommentDAO();
            commentDAO.AddComment(comment);

            List<Comment> list = commentDAO.GetCommentsByMovie((int)comment.MovieId);
            comment = list[list.Count - 1];
            comment.MovieId = 90;
            commentDAO.UpdateComment(comment);

            list = commentDAO.GetCommentsByMovie((int)comment.MovieId);
            string expected = ToStringWithoutId(comment);
            string actual = ToStringWithoutId(list[list.Count - 1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteCommentTest()
        {
            Comment comment = new Comment();
            comment.Text = "Very nice.";
            comment.Date = DateTime.Now;
            comment.MovieId = 5;
            comment.ClientId = 10;
            CommentDAO commentDAO = new CommentDAO();
            commentDAO.AddComment(comment);

            List<Comment> list = commentDAO.GetCommentsByMovie((int)comment.MovieId);
            comment = list[list.Count - 1];
            commentDAO.DeleteComment(comment.Id);

            list = commentDAO.GetCommentsByMovie((int)comment.MovieId);

            Assert.IsFalse(list.Exists(l => l.Id == comment.Id));
        }

        string ToStringWithoutId(Comment comment)
        {
            if (comment == null)
                return null;
            string line = comment.Text + " " + comment.Date.ToString()  + " " + comment.ClientId.ToString() + " " + comment.MovieId.ToString();
            return line;
        }
    }
}