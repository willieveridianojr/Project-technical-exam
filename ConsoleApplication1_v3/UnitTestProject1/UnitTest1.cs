using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System;

namespace UnitTestScenarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckScenario1()
        {
            SetPricing p = new SetPricing();
            Assert.IsTrue(ABCDABA(p));
        }
        [TestMethod]
        public void CheckScenario2()
        {
            SetPricing p = new SetPricing();
            Assert.IsTrue(CCCCCCC(p));
        }
        [TestMethod]
        public void CheckScenario3()
        {
            SetPricing p = new SetPricing();
            Assert.IsTrue(ABCD(p));
        }

        private bool ABCD(SetPricing p)
        {
            //Add to cart test case ABCD
            List<Product> cart = new List<Product>();
            cart.Add(p.Apple);
            cart.Add(p.Banana);
            cart.Add(p.Carrot);
            cart.Add(p.Dumpling);

            //Compute Total
            decimal totalAmount = Operations.ComputeTotal(cart);
            if (totalAmount == 7.25M)
            { return true; }
            else { return false; }
        }

        private bool ABCDABA(SetPricing p)
        {
            //Add to cart test case ABCDBA
            List<Product> cart = new List<Product>();
            cart.Add(p.Apple);
            cart.Add(p.Banana);
            cart.Add(p.Carrot);
            cart.Add(p.Dumpling);
            cart.Add(p.Apple);
            cart.Add(p.Banana);
            cart.Add(p.Apple);

            //Compute Total
            decimal totalAmount = Operations.ComputeTotal(cart);
            if (totalAmount == 13.25M)
            { return true; }
            else { return false; }
                
        }

        private bool CCCCCCC(SetPricing p)
        {
            //Add to cart test case CCCCCCC
            List<Product> cart = new List<Product>();

            cart.Add(p.Carrot);
            cart.Add(p.Carrot);
            cart.Add(p.Carrot);
            cart.Add(p.Carrot);
            cart.Add(p.Carrot);
            cart.Add(p.Carrot);
            cart.Add(p.Carrot); 

            //Compute Total
            decimal totalAmount = Operations.ComputeTotal(cart);
            if (totalAmount == 6.00M)
            { return true; }
            else { return false; }

        }
    }
}
