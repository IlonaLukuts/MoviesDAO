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
    public class OrderDAOTests
    {
        [TestMethod()]
        public void GetOrdersByClientTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 5;
            order.ClientId = 10;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(order));

            order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = false;
            order.Kinotheatr = "October";
            order.MovieId = 7;
            order.ClientId = 10;
            orderDAO.AddOrder(order);
            expected.Add(ToStringWithoutId(order));

            List<Order> list = orderDAO.GetOrdersByClient((int)order.ClientId);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetOrdersByMovieTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 10;
            order.ClientId = 0;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(order));

            order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = false;
            order.Kinotheatr = "October";
            order.MovieId = 10;
            order.ClientId = 8;
            orderDAO.AddOrder(order);
            expected.Add(ToStringWithoutId(order));

            List<Order> list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 10;
            order.ClientId = 20;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);

            List<Order> list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            if (list == null || list.Count == 0)
                Assert.Fail();
            string expected = ToStringWithoutId(order);
            string actual = ToStringWithoutId(list[list.Count - 1]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateOrderTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 10;
            order.ClientId = 80;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);

            List<Order> list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            order = list[list.Count - 1];
            order.MovieId = 90;
            orderDAO.UpdateOrder(order);

            list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            string expected = ToStringWithoutId(order);
            string actual = ToStringWithoutId(list[list.Count - 1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateOrderPayedTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 10;
            order.ClientId = 80;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);

            List<Order> list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            order = list[list.Count - 1];
            order.IsPayed = false;
            orderDAO.UpdateOrderPayed(order.Id, order.IsPayed);

            list = orderDAO.GetOrdersByMovie((int)order.MovieId);

            Assert.AreEqual(order.IsPayed, list[list.Count - 1].IsPayed);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Order order = new Order();
            order.Date = DateTime.Now;
            order.IsPayed = true;
            order.Kinotheatr = "Red Star";
            order.MovieId = 10;
            order.ClientId = 80;
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.AddOrder(order);

            List<Order> list = orderDAO.GetOrdersByMovie((int)order.MovieId);
            order = list[list.Count - 1];
            orderDAO.DeleteOrder(order.Id);

            list = orderDAO.GetOrdersByMovie((int)order.MovieId);

            Assert.IsFalse(list.Exists(l => l.Id == order.Id));
        }

        string ToStringWithoutId(Order order)
        {
            if (order == null)
                return null;
            string line = order.Date.ToString() + " " + order.Kinotheatr + " " + order.IsPayed.ToString() + " " + order.ClientId.ToString() + " " + order.MovieId.ToString();
            return line;
        }
    }
}