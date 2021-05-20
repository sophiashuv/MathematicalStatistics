using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class ExponentialFunction: Function
    {
        public ExponentialFunction(List<double?> resExp)
        {
            Res = resExp;
            var aa = CorrelationTable.CountAB(Res);
            ab = new KeyValuePair<double?, double?>(Math.Pow(10, Convert.ToDouble(aa.Key)),
                Math.Pow(10, Convert.ToDouble(aa.Value)));
            funk = x => ab.Value * Math.Pow(Convert.ToDouble(ab.Key), Convert.ToDouble(x));
        }
        public override string PrintEquolity()
        {
            return $"{CorrelationTable.str(Res[0])} * lg(a) + {CorrelationTable.str(Res[1])} * lg(b) = {CorrelationTable.str(Res[2])}\n" +
                   $"{CorrelationTable.str(Res[3])} * lg(a) + {CorrelationTable.str(Res[0])} * lg(b) = {CorrelationTable.str(Res[4])}";
        }

        public override string PrintFunction()
        {
            return $"y(x) = {CorrelationTable.str(ab.Value)} * {CorrelationTable.str(ab.Key)} ^ x;";
        }

    }
}
