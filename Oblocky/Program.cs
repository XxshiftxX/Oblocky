using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class Program
    {
        static void Main(string[] args)
        {
            OblInt num1 = new OblDouble(12.2);
            OblInt num2 = new OblDouble(1.2);

            OblNumber result = num1 + num2;

            Console.WriteLine(result.Value);
            Console.WriteLine(result.GetType());
        }
    }
}
