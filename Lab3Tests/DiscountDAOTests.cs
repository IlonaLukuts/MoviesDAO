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
    public class DiscountDAOTests
    {
        [TestMethod()]
        public void GetDiscountTest()
        {
            Discount discount = new Discount();
            discount.Percent = 20;
            discount.Validity = DateTime.Now;
            discount.ClientId = 1000;
            DiscountDAO discountDAO = new DiscountDAO();
            discountDAO.AddDiscount(discount);
            List<string> expected = new List<string>();
            expected.Add(ToStringWithoutId(discount));
            discount = new Discount();
            discount.Percent = 50;
            discount.Validity = DateTime.Now;
            discount.ClientId = 1000;
            discountDAO.AddDiscount(discount);
            expected.Add(ToStringWithoutId(discount));

            List<Discount> list = discountDAO.GetDiscount((int)discount.ClientId);
            if (list == null || list.Count < 2)
                Assert.Fail();
            List<string> actual = new List<string>();
            for (int i = list.Count - 2; i < list.Count; i++)
                actual.Add(ToStringWithoutId(list[i]));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddDiscountTest()
        {
            Discount discount = new Discount();
            discount.Percent = 20;
            discount.Validity = DateTime.Now;
            discount.ClientId = 3;
            DiscountDAO discountDAO = new DiscountDAO();
            discountDAO.AddDiscount(discount);

            List<Discount> list = discountDAO.GetDiscount((int)discount.ClientId);
            if (list == null || list.Count == 0)
                Assert.Fail();
            string expected = ToStringWithoutId(discount);
            string actual = ToStringWithoutId(list[list.Count - 1]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateDiscountTest()
        {
            Discount discount = new Discount();
            discount.Percent = 20;
            discount.Validity = DateTime.Now;
            discount.ClientId = 1000;
            DiscountDAO discountDAO = new DiscountDAO();
            discountDAO.AddDiscount(discount);

            List<Discount> list = discountDAO.GetDiscount((int)discount.ClientId);
            discount = list[list.Count - 1];
            discount.Percent = 5;
            discountDAO.UpdateDiscount(discount);

            list = discountDAO.GetDiscount((int)discount.ClientId);
            string expected = ToStringWithoutId(discount);
            string actual = ToStringWithoutId(list[list.Count - 1]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteDiscountTest()
        {
            Discount discount = new Discount();
            discount.Percent = 20;
            discount.Validity = DateTime.Now;
            discount.ClientId = 1000;
            DiscountDAO discountDAO = new DiscountDAO();
            discountDAO.AddDiscount(discount);

            List<Discount> list = discountDAO.GetDiscount((int)discount.ClientId);
            discount = list[list.Count - 1];
            discountDAO.DeleteDiscount(discount.Id);

            list = discountDAO.GetDiscount((int)discount.ClientId);

            Assert.IsFalse(list.Exists(l => l.Id == discount.Id));
        }

        [TestMethod()]
        public void DeleteUnactiveDiscountTest()
        {
            Discount discount = new Discount();
            discount.Percent = 20;
            discount.Validity = new DateTime(2019, 12, 1);
            discount.ClientId = 1000;
            DiscountDAO discountDAO = new DiscountDAO();
            discountDAO.AddDiscount(discount);

            discount = new Discount();
            discount.Percent = 40;
            discount.Validity = new DateTime(1999, 12, 1);
            discount.ClientId = 1000;
            discountDAO.AddDiscount(discount);

            List<Discount> list = discountDAO.GetDiscount((int)discount.ClientId);
            discount = list[list.Count - 1];
            discountDAO.DeleteUnactiveDiscount();

            list = discountDAO.GetDiscount((int)discount.ClientId);

            Assert.IsFalse(list.Exists(l => l.Id == discount.Id));
        }

        string ToStringWithoutId(Discount discount)
        {
            if (discount == null)
                return null;
            string line = discount.Percent.ToString() + " " + discount.Validity.ToString() + " " + discount.ClientId.ToString();
            return line;
        }
    }
}