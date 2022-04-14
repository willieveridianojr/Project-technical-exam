using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate
{
    public class InputValidation
    {
        public static void InvalidChoice()
        {
            Console.WriteLine("Invalid input! please try again valid inputs are A,B,C and D");
        }

        public static void InvalidYorN()
        {
            Console.WriteLine("Invalid input! please try again valid inputs Y or N");
        }

        public static void ValueMustBeNumeric()
        {
            Console.WriteLine("Invalid input! please try again valid input must be numeric");
        }
    }
}
