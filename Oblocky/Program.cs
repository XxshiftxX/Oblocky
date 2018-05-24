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
            OblNumber[] numbers = new OblNumber[5]
                {
                    new OblInt(10),
                    new OblInt(5),
                    new OblDouble(10.5),
                    new OblInt(-99),
                    new OblDouble(7.77)
                };

            OblNumber result = new OblInt();
            foreach (var n in numbers)
                result += n;

            Console.WriteLine(result.Value);
            Console.WriteLine(result.GetType());
        }
    }
}
