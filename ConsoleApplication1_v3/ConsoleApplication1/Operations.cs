using System.Collections.Generic;
using System.Linq;
using System;
using Model;
using Validate;
using System.Text.RegularExpressions;

namespace Controller
{
    public class Operations
    {
        public static decimal ComputeTotal(List<Product> cart)
        {
            //SortList 
            var cartGroupBy = cart.GroupBy(u => u.productName).Select(grp => grp.ToList()).ToList();

            decimal total = 0.0M;

            foreach (var cartItem in cartGroupBy)
            {
                foreach (Product item in cartItem)
                {
                    if (item.bulkPrice != 0 && cartItem.Count >= item.bulkQty)
                    {
                        for (int y = 0; y < cartItem.Count / item.bulkQty; y++) //computes bundled orders
                        {
                            total = total + item.bulkPrice;
                            Console.WriteLine("Item added: " + item.productName + " bundle amount: $" + item.bulkPrice);

                        }
                        if (cartItem.Count % item.bulkQty >= 1) // add items in excess of bulk orders
                        {
                            for (int i = 0; i < cartItem.Count % item.bulkQty; i++)
                            {
                                total = total + item.itemPrice;
                                Console.WriteLine("Item added: " + item.productName + " amount: $" + item.itemPrice);
                            }
                        }
                        break;
                    }
                    else
                    {
                        total = total + item.itemPrice;
                        Console.WriteLine("Item added: " + item.productName + " amount: $" + item.itemPrice);
                    }
                }
            }
            return total;
        }

        public static List<Product> AddtoCart(List<Product> cart, SetPricing p)
        {
            string addAnother = string.Empty;
            Product itemToAdd = null;

            do
            {
                reTypeChoice:
                Console.WriteLine("******************************");
                Console.WriteLine("Enter the item of your choice:");
                Console.WriteLine("******************************");
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "A":
                        itemToAdd = p.Apple;
                        break;
                    case "B":
                        itemToAdd = p.Banana;
                        break;
                    case "C":
                        itemToAdd = p.Carrot;
                        break;
                    case "D":
                        itemToAdd = p.Dumpling;
                        break;
                    default:
                        InputValidation.InvalidChoice();
                        goto reTypeChoice;
                }

                retypeQty:
                Console.WriteLine("******************************");
                Console.WriteLine("Enter Item Quantity:");
                Console.WriteLine("******************************");
                string inputQty = Console.ReadLine();
                int validQty = 0;
                if (!Regex.IsMatch(inputQty, @"^\d+$"))
                {
                    InputValidation.ValueMustBeNumeric();
                    goto retypeQty;
                }
                else
                {
                    validQty = Convert.ToInt16(inputQty);
                }

                for (int x = 0; x < validQty; x++)
                {
                    cart.Add(itemToAdd);
                    Console.WriteLine(itemToAdd.productName + " has been added to cart");
                }

                Console.WriteLine("**Item Summary**");
                decimal currentTotal = Operations.ComputeTotal(cart);
                Console.WriteLine("**Current total is:  $" + currentTotal.ToString());

                retypeAddtoAnother:
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Want to add another item? Press Y if yes, press N to checkout");
                Console.WriteLine("-------------------------------------------------------------------");
                addAnother = Console.ReadLine();

                if (addAnother.ToUpper() != "Y" && addAnother.ToUpper() != "N")
                {
                    InputValidation.InvalidYorN();
                    goto retypeAddtoAnother;
                }

            } while (addAnother.ToUpper() == "Y");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Checking out...... see item summary below.....");
            Console.WriteLine("-------------------------------------------------------------------");

            return cart;
        }

        public static void DisplayItems(SetPricing p)
        {
            Console.WriteLine("-----WELCOME TO MINI GROCERY------");
            Console.WriteLine("Choose which item to buy");
            Console.WriteLine("----------------------------------");

            //Product Apple
            Console.WriteLine("[A]: ---" + p.Apple.productName + " Price: $" + p.Apple.itemPrice);
            Console.WriteLine("Buy " + p.Apple.bulkQty + " " + p.Apple.productName + "s for only: $" + p.Apple.bulkPrice);
            Console.WriteLine("----------------------------------");
            //Product Banana
            Console.WriteLine("[B]: ---" + p.Banana.productName + " Price: $" + p.Banana.itemPrice);
            Console.WriteLine("----------------------------------");
            //Product Carrot
            Console.WriteLine("[C]: ---" + p.Carrot.productName + " Price: $" + p.Carrot.itemPrice);
            Console.WriteLine("Buy " + p.Carrot.bulkQty + " " + p.Carrot.productName + "s for only: $" + p.Carrot.bulkPrice);
            Console.WriteLine("----------------------------------");
            //Product Dumpling
            Console.WriteLine("[D]: ---" + p.Dumpling.productName + " Price: $" + p.Dumpling.itemPrice);
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Press Enter to continue: ");
            Console.ReadLine();
        }

        public static bool ComputePayment(decimal totalAmount, decimal payment)
        {
            bool success = false;
            if (payment < totalAmount)
            {
                Console.WriteLine("Insufficient funds, please pay the required amount");
                success = false;
            }
            else if (payment > totalAmount)
            {
                Console.WriteLine("Payment transaction complete. You paid $" + payment + ". Your change is $" + (payment - totalAmount));
                success = true;
            }
            else if (payment == totalAmount)
            {
                Console.WriteLine("Payment transaction complete. Thanks for paying the exact amount.");
                success = true;
            }
            return success;
        }

        public static decimal CheckOut(decimal totalAmount)
        {
            retypePaymentAmt:
            Console.WriteLine("Total Amount of items is: $" + totalAmount);
            Console.WriteLine("***************************************************");
            Console.WriteLine("Proceeding to payment, please enter payment amount");
            Console.WriteLine("***************************************************");
            string inputQty = Console.ReadLine();
            decimal validQty = 0;
            if (!Regex.IsMatch(inputQty, @"^\d+$"))
            {
                InputValidation.ValueMustBeNumeric();
                goto retypePaymentAmt;
            }
            else
            {
                validQty = Convert.ToInt16(inputQty);
            }
            decimal payment = validQty;

            return payment;
        }
    }
}
