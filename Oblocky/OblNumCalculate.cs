using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class OblNumCalculate : OblNumber
    {
        public enum CalcOperator
        {
            ADD, SUB, MUL, DIV, MOD
        }

        public CalcOperator Operator { get; set;}
        public OblNumber Num1 { get; set; }
        public OblNumber Num2 { get; set; } 

        public override dynamic Value
        {
            get
            {
                switch (Operator)
                {
                    case CalcOperator.ADD:
                        return (Num1 + Num2).Value;
                    case CalcOperator.SUB:
                        return (Num1 - Num2).Value;
                    case CalcOperator.MUL:
                        return (Num1 * Num2).Value;
                    case CalcOperator.DIV:
                        return (Num1 / Num2).Value;
                    case CalcOperator.MOD:
                        return (Num1 % Num2).Value;
                    default:
                        throw new Exception("Error!");
                }
            }
        }

        protected override Type ValueType => Value.GetType();
    }
}
