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
            OblNumCalculate calc1 = new OblNumCalculate();
            calc1.Num1 = new OblInt(20);
            calc1.Num2 = new OblInt(12);
            calc1.Operator = OblNumCalculate.CalcOperator.SUB;

            OblNumCalculate calc2 = new OblNumCalculate();
            calc2.Num1 = calc1;
            calc2.Num2 = new OblInt(2);
            calc2.Operator = OblNumCalculate.CalcOperator.ADD;

            PrintBlock A = new PrintBlock();
            A.Value = calc2;

            calc2.Num2 = new OblInt(7);

            PrintBlock C = new PrintBlock();
            C.Value = calc2;

            A.NextBlock = C;

            A.Execute();
        }
    }
}
