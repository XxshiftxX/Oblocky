﻿using System;

namespace Oblocky
{
    public class BinaryExpression : Expression
    {
        public enum OperatorEnum
        {
            ADD, SUB, MUL, DIV, MOD, BIG, SML, EQL, EBG, ESM
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
                    case OperatorEnum.ADD:
                        return a + b;
                    case OperatorEnum.SUB:
                        return a - b;
                    case OperatorEnum.MUL:
                        return a * b;
                    case OperatorEnum.DIV:
                        return a / b;
                    case OperatorEnum.MOD:
                        return a % b;
                    case OperatorEnum.BIG:
                        return a > b;
                    case OperatorEnum.SML:
                        return a < b;
                    case OperatorEnum.EQL:
                        return a == b;
                    case OperatorEnum.EBG:
                        return a >= b;
                    case OperatorEnum.ESM:
                        return a <= b;
                    default:
                        throw new Exception("??");
                }
            }
        }
    }
}