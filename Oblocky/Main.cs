using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class Maine
    {
        public static void Main()
        {
            VariableExpression vari = new VariableExpression();
            vari.Name = "ACC";

            BinaryExpression exp = new BinaryExpression();
            exp.Operator = BinaryExpression.OperatorEnum.Sub;

            ConstExpression cos = new ConstExpression();
            cos.SetValue(15);

            ConstExpression cos2 = new ConstExpression();
            cos2.SetValue(20);

            exp.LeftOperand = vari;
            exp.RightOperand = cos;

            SetVarBlock blk = new SetVarBlock();
            blk.ValueExp = cos2;
            blk.VarName = "ACC";

            PrintBlock blk2 = new PrintBlock();
            blk2.Contents.Add(vari);
            blk.NextBlock = blk2;

            PrintBlock blk3 = new PrintBlock();
            blk3.Handler = (s) => Console.WriteLine($"blk3 : {s}");
            blk3.Contents.Add(exp);
            blk2.NextBlock = blk3;

            blk.Execute();
        }
    }
}
