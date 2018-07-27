using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class IfBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public IBlock InnerBlock { get; set; }

        public Expression Condition { get; set; }

        public void Execute()
        {
            var condition = (bool)Condition.Value;
            if(condition)
            {
                InnerBlock?.Execute();

                var next = NextBlock ?? null;
                
                while (next is ElseBlock || next is ElseIfBlock)
                    next = next?.NextBlock;

                next?.Execute();
            }
            else
            {
                NextBlock?.Execute();
            }
        }
    }
}
