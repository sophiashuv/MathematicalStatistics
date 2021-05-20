using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class ParabolicFunction: Function
    {

        KeyValuePair<double?, KeyValuePair<double?, double?>> abc;

        public ParabolicFunction(List<double?> resParab)
        {
            Res = resParab;
            CountABC();
            funk = x => abc.Key * Math.Pow(Convert.ToDouble(x), 2) + abc.Value.Key * x + abc.Value.Value;
        }
        public override string PrintEquolity()
        {
            return $"{CorrelationTable.str(Res[0])} * a + {CorrelationTable.str(Res[1])} * b + c * {CorrelationTable.str(Res[2])}  = {CorrelationTable.str(Res[3])}\n" +
                   $"{CorrelationTable.str(Res[1])} * a + {CorrelationTable.str(Res[2])} * b + c * {CorrelationTable.str(Res[4])}  = {CorrelationTable.str(Res[5])}\n" +
                   $"{CorrelationTable.str(Res[2])} * a + {CorrelationTable.str(Res[4])} * b + c * {CorrelationTable.str(Res[6])}  = {CorrelationTable.str(Res[7])}\n";
        }

        public override string PrintFunction()
        {
            Console.WriteLine(abc.Key);
            Console.WriteLine(abc.Value.Key);
            Console.WriteLine(abc.Value.Value);
            return $"y(x) = {CorrelationTable.str(abc.Key)} * x ^ 2 + {CorrelationTable.str(abc.Value.Key)} * x +  {CorrelationTable.str(abc.Value.Value)};";
        }

        public override string PrintCoefs() => $"a = {CorrelationTable.str(abc.Key)};  b = {CorrelationTable.str(abc.Value.Key)};  c = {CorrelationTable.str(abc.Value.Value)};";

        public void CountABC()
        {
           
            
            double[,] matrix = new double[,] { { Convert.ToDouble(Res[0]), Convert.ToDouble(Res[1]), Convert.ToDouble(Res[2])},
                                                 { Convert.ToDouble(Res[1]), Convert.ToDouble(Res[2]), Convert.ToDouble(Res[4])},
                                                 { Convert.ToDouble(Res[2]), Convert.ToDouble(Res[4]), Convert.ToDouble(Res[6])}};

            double[] mas_b = new double[] { Convert.ToDouble(Res[3]), Convert.ToDouble(Res[5]), Convert.ToDouble(Res[7])};
           
            var res = Matrix_Gausa.Gause(ref matrix, ref mas_b);
            Console.WriteLine(res[0]);
            abc = new KeyValuePair<double?, KeyValuePair<double?, double?>>(res[0], new KeyValuePair<double?, double?>(res[1], res[2]));

        }
    }
}
