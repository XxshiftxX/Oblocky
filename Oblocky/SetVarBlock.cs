using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class SetVarBlock : IBlock
    {
        public string VarName { get; set; }
        public Expression ValueExp { get; set; }
        public IBlock NextBlock { get; set; }

        public void Execute()
        {
            VariableManager.Inst[VarName] = ValueExp.Value;
            NextBlock?.Execute();
        }
    }
}
