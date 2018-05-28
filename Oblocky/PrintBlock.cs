using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class PrintBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public IObject Value { get; set; }

        public void Execute()
        {
            Console.WriteLine(Value);
            NextBlock?.Execute();
        }
    }
}
