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
        public Action<string> Handler;
        public List<Expression> Content;

        public void Execute() => Handler(string.Join(string.Empty, Content.Select(x => x.Value.ToString())));
    }
}
