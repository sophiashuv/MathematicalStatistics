using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class HyperbolicFunction: Function
    {
        public HyperbolicFunction(List<double?> resHyp)
        {
            Res = resHyp;
            ab = CorrelationTable.CountAB(Res);
            funk = x => ab.Key / x + ab.Value;
        }

        public override string PrintEquolity()
        {
            return $"{CorrelationTable.str(Res[0])} * a + {CorrelationTable.str(Res[1])} * b = {CorrelationTable.str(Res[2])}\n" +
                   $"{CorrelationTable.str(Res[3])} * a + {CorrelationTable.str(Res[0])} * b = {CorrelationTable.str(Res[4])}";
        }

        public override string PrintFunction()
        {
            return $"y(x) = {CorrelationTable.str(ab.Key)} / x + {CorrelationTable.str(ab.Value)};";
        }
    }
}
