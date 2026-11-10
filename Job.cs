using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MiniRadar
{
    public class Job
    {
        public required string Title { get; set; } = "";
        public required string Company { get; set; } = "";
        public required string Location { get; set; } = "";
        public int Score { get; set; }

    }
}
