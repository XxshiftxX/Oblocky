using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class IfBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public IBlock InnerBlock { get; set; }

        public bool Condition { get; set; }

        public void Execute()
        {
            var condition = Condition;
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
