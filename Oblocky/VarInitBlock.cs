using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    class VarInitBlock : IBlock
    {
        public IBlock NextBlock { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
