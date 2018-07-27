using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class WhileBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public IBlock InnerBlock { get; set; }

        public Expression Condition { get; set; }

        public void Execute()
        {
            while((bool)Condition.Value)
            {
                InnerBlock?.Execute();
            }
            NextBlock?.Execute();
        }
    }
}
