using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    public abstract class Function
    {
        public List<double?> Res { get; set; }
        public Func<double?, double?> funk;
        public KeyValuePair<double?, double?> ab;


        public abstract string PrintEquolity();
        public virtual string PrintCoefs() => $"a = {CorrelationTable.str(ab.Key)};  b = {CorrelationTable.str(ab.Value)};";
        public abstract string PrintFunction();
    }
}
