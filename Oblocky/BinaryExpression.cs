using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class BinaryExpression : Expression
    {
        public enum OperatorEnum
        {
            Add, Sub, Mul, Div, Mod, Big, Sml, Eql, Ebg, Esm
        }

        public OperatorEnum Operator;

        public Expression LeftOperand;
        public Expression RightOperand;

        public override object Value
        {
            get
            {
                dynamic a = LeftOperand.Value;
                dynamic b = RightOperand.Value;
                switch (Operator)
                {
                    case OperatorEnum.Add:
                        return a + b;
                    case OperatorEnum.Sub:
                        return a - b;
                    case OperatorEnum.Mul:
                        return a * b;
                    case OperatorEnum.Div:
                        return a / b;
                    case OperatorEnum.Mod:
                        return a % b;
                    case OperatorEnum.Big:
                        return a > b;
                    case OperatorEnum.Sml:
                        return a < b;
                    case OperatorEnum.Eql:
                        return a == b;
                    case OperatorEnum.Ebg:
                        return a >= b;
                    case OperatorEnum.Esm:
                        return a <= b;
                    default:
                        throw new Exception("??");
                }
            }
        }
    }
}