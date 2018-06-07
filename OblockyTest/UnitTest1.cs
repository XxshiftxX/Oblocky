using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblocky;

namespace OblockyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstTest1()
        {
            ConstExpression cos = new ConstExpression();
            cos.SetValue(20);
            Assert.AreEqual(cos.Value.GetType(), typeof(int));
        }

        [TestMethod]
        public void BinaryTest1()
        {
            BinaryExpression exp = new BinaryExpression();
            exp.Operator = BinaryExpression.OperatorEnum.ADD;

            ConstExpression cos = new ConstExpression();
            cos.SetValue(20);

            ConstExpression cos2 = new ConstExpression();
            cos2.SetValue(10);

            exp.LeftOperand = cos;
            exp.RightOperand = cos2;

            Assert.AreEqual(30, exp.Value);
        }

        [TestMethod]
        public void BinaryTest2()
        {
            BinaryExpression exp = new BinaryExpression();
            exp.Operator = BinaryExpression.OperatorEnum.EQL;

            ConstExpression cos = new ConstExpression();
            cos.SetValue(20);

            ConstExpression cos2 = new ConstExpression();
            cos2.SetValue(20);

            exp.LeftOperand = cos;
            exp.RightOperand = cos2;

            Assert.IsTrue((bool)exp.Value);
        }
        
        [TestMethod]
        public void VarTest1()
        {
            VariableExpression vari = new VariableExpression();
            vari.Name = "ACC";

            BinaryExpression exp = new BinaryExpression();
            exp.Operator = BinaryExpression.OperatorEnum.SUB;

            ConstExpression cos = new ConstExpression();
            cos.SetValue(15);

            ConstExpression cos2 = new ConstExpression();
            cos2.SetValue(20);

            exp.LeftOperand = vari;
            exp.RightOperand = cos;

            SetVarBlock blk = new SetVarBlock();
            blk.ValueExp = cos2;
            blk.VarName = "ACC";

            blk.Execute();

            Assert.AreEqual(5, exp.Value);
        }
    }
}
