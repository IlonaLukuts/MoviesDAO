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
    public class ClientDAOTests
    {
        [TestMethod()]
        public void GetClientTest()
        {
            Client client = new Client();
            client.Name = "user";
            client.Password = "password";
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.AddClient(client);
            string expected = ToStringWithoutId(client);
            
            Client client1 = clientDAO.GetClient(client.Name);
            if (client1 == null)
                Assert.Fail();
            string actual = ToStringWithoutId(client1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddClientTest()
        {
            Client client = new Client();
            client.Name = "user1";
            client.Password = "password1";
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.AddClient(client);
            string expected = ToStringWithoutId(client);

            Client client1 = clientDAO.GetClient(client.Name);
            if (client1 == null)
                Assert.Fail();
            string actual = ToStringWithoutId(client1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateClientTest()
        {
            Client client = new Client();
            client.Name = "user2";
            client.Password = "password2";
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.AddClient(client);

            client = clientDAO.GetClient(client.Name);
            client.Password = "pass";
            clientDAO.UpdateClient(client);

            Client client1 = clientDAO.GetClient(client.Name);
            string expected = ToStringWithoutId(client);
            string actual = ToStringWithoutId(client1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteClientTest()
        {
            Client client = new Client();
            client.Name = "user3";
            client.Password = "password3";
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.AddClient(client);

            client = clientDAO.GetClient(client.Name);
            clientDAO.DeleteClient(client.Id);

            client = clientDAO.GetClient(client.Name);

            Assert.IsNull(client);
        }

        string ToStringWithoutId(Client client)
        {
            if (client == null)
                return null;
            string line = client.Name + " " + client.Password;
            return line;
        }
    }
}