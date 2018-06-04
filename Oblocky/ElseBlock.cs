using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class ElseBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public IBlock InnerBlock { get; set; }

        public void Execute()
        {
            InnerBlock?.Execute();
            NextBlock?.Execute();
        }
    }
}
