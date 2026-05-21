using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo.Models
{
    public class Stat
    {
        public int TotalNoCount { get; set; }
        public int Goal { get; set; } = 100;

        public double ProgressPercent =>
        Goal == 0
            ? 0
            : (double)TotalNoCount / Goal * 100;
    }
}
