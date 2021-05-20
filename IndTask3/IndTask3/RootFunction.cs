using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class RootFunction: Function
    {
        public RootFunction(List<double?> resSqrt) {
            Res = resSqrt;
            ab = CorrelationTable.CountAB(Res);
            funk = x => ab.Key * Math.Sqrt(Convert.ToDouble(x)) + ab.Value;
        }

        public override string PrintEquolity()
        {
            return $"{CorrelationTable.str(Res[0])} * a + {CorrelationTable.str(Res[1])} * b = {CorrelationTable.str(Res[2])}\n" +
                   $"{CorrelationTable.str(Res[3])} * a + {CorrelationTable.str(Res[0])} * b = {CorrelationTable.str(Res[4])}";
        }

        public override string PrintFunction()
        {
            return $"y(x) = {CorrelationTable.str(ab.Key)} * sqrt(x) + {CorrelationTable.str(ab.Value)};";
        }
    }
}
