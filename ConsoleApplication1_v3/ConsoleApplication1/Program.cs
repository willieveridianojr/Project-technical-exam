using System;
using Model;
using Controller;
using System.Collections.Generic;

namespace PointOfSale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize values
            SetPricing p = new SetPricing();
            List<Product> cart = new List<Product>();

            //Welcome Display
            Operations.DisplayItems(p);

            //Add items to cart
            cart = Operations.AddtoCart(cart, p);

            //Compute Total
            decimal totalAmount = Operations.ComputeTotal(cart);

            //Check out
            checkout:
            decimal payment = Operations.CheckOut(totalAmount);

            //Compute Payment
            bool success = Operations.ComputePayment(totalAmount, payment);
            if(!success)
            { goto checkout; }

            //end
            Console.WriteLine("Thank you, come again!");
            Console.ReadLine();

        }



    }

}
