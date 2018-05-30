﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblocky
{
    interface IBlock
    {
        IBlock NextBlock { get; set; }

        void Execute();
    }
}
