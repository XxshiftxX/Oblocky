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

        [TestMethod]
        public void IfTest1()
        {
            VariableExpression vaexp = new VariableExpression();
            vaexp.Name = "VAR1";

            ConstExpression cst = new ConstExpression();
            cst.SetValue(true);

            ConstExpression cst2 = new ConstExpression();
            cst2.SetValue(10);

            ConstExpression cst3 = new ConstExpression();
            cst3.SetValue(5);

            IfBlock ifblk = new IfBlock();
            SetVarBlock setvar1 = new SetVarBlock();
            SetVarBlock setvar2 = new SetVarBlock();

            setvar1.VarName = "VAR1";
            setvar1.ValueExp = cst2;
            setvar1.NextBlock = ifblk;

            ifblk.Condition = cst;
            ifblk.InnerBlock = setvar2;

            setvar2.VarName = "VAR1";
            setvar2.ValueExp = cst3;

            setvar1.Execute();

            Assert.AreEqual(vaexp.Value, 5);

            cst.SetValue(false);
            setvar1.Execute();

            Assert.AreEqual(vaexp.Value, 10);
        }

        [TestMethod]
        public void IfTest2()
        {
            VariableExpression vaexp = new VariableExpression();
            vaexp.Name = "VAR1";
            VariableExpression vaexp2 = new VariableExpression();
            vaexp2.Name = "VAR2";

            ConstExpression cst = new ConstExpression();
            cst.SetValue(true);

            ConstExpression cst2 = new ConstExpression();
            cst2.SetValue(10);

            ConstExpression cst3 = new ConstExpression();
            cst3.SetValue(5);

            ConstExpression cst4 = new ConstExpression();
            cst4.SetValue(7);

            IfBlock ifblk = new IfBlock();
            ElseBlock elseblk = new ElseBlock();
            SetVarBlock setvar1 = new SetVarBlock();
            SetVarBlock setvar2 = new SetVarBlock();
            SetVarBlock setvar3 = new SetVarBlock();

            ifblk.Condition = cst;
            ifblk.InnerBlock = setvar1;
            ifblk.NextBlock = elseblk;

            elseblk.InnerBlock = setvar2;
            elseblk.NextBlock = setvar3;

            setvar1.VarName = "VAR1";
            setvar1.ValueExp = cst2;

            setvar2.VarName = "VAR1";
            setvar2.ValueExp = cst3;

            setvar3.VarName = "VAR2";
            setvar3.ValueExp = cst4;

            ifblk.Execute();

            Assert.AreEqual(vaexp.Value, 10);
            Assert.AreEqual(vaexp2.Value, 7);

            cst.SetValue(false);
            ifblk.Execute();

            Assert.AreEqual(vaexp.Value, 5);
            Assert.AreEqual(vaexp2.Value, 7);
        }

        [TestMethod]
        public void WhileTest1()
        {
            BinaryExpression eq = new BinaryExpression();
            BinaryExpression sumadder = new BinaryExpression();
            BinaryExpression oneadder = new BinaryExpression();
            ConstExpression zero = new ConstExpression();
            ConstExpression one = new ConstExpression();
            ConstExpression six = new ConstExpression();
            VariableExpression vari = new VariableExpression();
            VariableExpression sum = new VariableExpression();

            zero.SetValue(0);
            one.SetValue(1);
            six.SetValue(6);

            vari.Name = "VAR";
            sum.Name = "SUM";

            sumadder.Operator = BinaryExpression.OperatorEnum.ADD;
            sumadder.LeftOperand = vari;
            sumadder.RightOperand = sum;

            oneadder.Operator = BinaryExpression.OperatorEnum.ADD;
            oneadder.LeftOperand = vari;
            oneadder.RightOperand = one;
            
            eq.Operator = BinaryExpression.OperatorEnum.SML;
            eq.LeftOperand = vari;
            eq.RightOperand = six;

            SetVarBlock initblk = new SetVarBlock();
            SetVarBlock initblk2 = new SetVarBlock();
            WhileBlock wblk = new WhileBlock();
            SetVarBlock addblk = new SetVarBlock();
            SetVarBlock sumaddblk = new SetVarBlock();


            initblk.VarName = "SUM";
            initblk.ValueExp = zero;

            initblk2.VarName = "VAR";
            initblk2.ValueExp = zero;

            wblk.Condition = eq;

            addblk.VarName = "VAR";
            addblk.ValueExp = oneadder;

            sumaddblk.VarName = "SUM";
            sumaddblk.ValueExp = sumadder;

            initblk.NextBlock = initblk2;
            initblk2.NextBlock = wblk;
            wblk.InnerBlock = addblk;
            addblk.NextBlock = sumaddblk;

            initblk.Execute();

            Assert.AreEqual(vari.Value, 6);
        }
    }
}
