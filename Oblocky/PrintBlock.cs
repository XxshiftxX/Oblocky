using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    public class PrintBlock : IBlock
    {
        public IBlock NextBlock { get; set; }
        public Action<string> Handler = Console.WriteLine;
        public List<Expression> Contents = new List<Expression>();

        public void Execute()
        {
            Handler(string.Join(string.Empty, Contents.Select(x => x.Value.ToString())));
            NextBlock?.Execute();
        }
    }
}