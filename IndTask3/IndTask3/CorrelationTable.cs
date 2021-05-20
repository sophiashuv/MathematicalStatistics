using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndTask3
{
    class CorrelationTable
    {
        private double?[,] _table;

        public int Row{set; get;}
        public int Col { set; get; }

        public static Func<double?, string> str = x => String.Format("{0:0.00}", x);

        public double?[,] Table
        {
            get => _table;
            set => _table = value;
        }

        public CorrelationTable(List<string> cells, int row, int col)
        {
            Row = row;
            Col = col;
            Table = new double?[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    var cell = cells[Col * i + j];
                    if (cell == "" || cell == null) Table[i, j] = null;
                    else Table[i, j] = Convert.ToDouble(cell);
                }
            }
        }

        public List<double?> CountXMean()
        {
            List<double?> Xyi = new List<double?>();
            for (int i = 1; i < Row; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Col; j++)
                {
                    if (Table[i, j] != null)
                    {
                        n += Table[i, j];
                        sum += Table[i, j] * Table[0, j];
                    }
                }
                Xyi.Add(sum / n);
            }
            return Xyi;
        }

        public List<double?> CountYMean()
        {
            List<double?> Yxi = new List<double?>();
            for (int i = 1; i < Col; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        n += Table[j, i];
                        sum += Table[j, i] * Table[j, 0];
                    }
                }
                Yxi.Add(sum / n);
            }
            return Yxi;
        }

        public List<double?> CountHyperbola()
        {
            var resHyp = new List<double?> { 0.0, 0.0, 0.0, 0.0, 0.0 };
            for (int i = 1; i < Col; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        n += Table[j, i];
                        sum += Table[j, i] * Table[j, 0];
                    }
                }

                resHyp[0] += n / Table[0, i];
                resHyp[1] += n;
                resHyp[2] += sum;
                resHyp[3] += n / Math.Pow(Convert.ToDouble(Table[0, i]), 2);
                resHyp[4] += (sum) / Table[0, i];
            }
            return resHyp;
        }

        public List<double?> CountExp()
        {
            var resExp = new List<double?> { 0.0, 0.0, 0.0, 0.0, 0.0 };
            for (int i = 1; i < Col; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        n += Table[j, i];
                        sum += Table[j, i] * Table[j, 0];
                    }
                }

                resExp[0] += n * Table[0, i];
                resExp[1] += n;
                resExp[2] += n * Math.Log10(Convert.ToDouble(sum / n));
                resExp[3] += n * Math.Pow(Convert.ToDouble(Table[0, i]), 2);
                resExp[4] += n * Math.Log10(Convert.ToDouble(sum / n)) * Table[0, i];
            }
            return resExp;
        }
        public List<double?> CountSqrt()
        {
            var resSqrt = new List<double?> { 0.0, 0.0, 0.0, 0.0, 0.0 };
            for (int i = 1; i < Col; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        n += Table[j, i];
                        sum += Table[j, i] * Table[j, 0];
                    }
                }

                resSqrt[0] += n * Math.Sqrt(Convert.ToDouble(Table[0, i]));
                resSqrt[1] += n;
                resSqrt[2] += sum;
                resSqrt[3] += n * Table[0, i];
                resSqrt[4] += sum * Math.Sqrt(Convert.ToDouble(Table[0, i]));
            }
            return resSqrt;
        }

        public List<double?> CountParab()
        {
            var resParab = new List<double?> { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
            for (int i = 1; i < Col; i++)
            {
                double? n = 0;
                double? sum = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        n += Table[j, i];
                        sum += Table[j, i] * Table[j, 0];
                    }
                }

                resParab[0] += n * Math.Pow(Convert.ToDouble(Table[0, i]), 4);
                resParab[1] += n * Math.Pow(Convert.ToDouble(Table[0, i]), 3);
                resParab[2] += n * Math.Pow(Convert.ToDouble(Table[0, i]), 2);
                resParab[3] += Math.Pow(Convert.ToDouble(Table[0, i]), 2) * sum;
                resParab[4] += n * Table[0, i];
                resParab[5] += Table[0, i] * sum;
                resParab[6] += n;
                resParab[7] += sum;

            }
            return resParab;
        }
        public static KeyValuePair<double?, double?> CountAB(List<double?> res)
        {
            var b = (res[4] * res[0] - res[3] * res[2]) / (res[0] * res[0] - res[3] * res[1]);
            var a = (res[2] - b * res[1]) / res[0];
            return new KeyValuePair<double?, double?>(a, b);
        }

        public double? CountSigma(Func<double?, double?>func)
        {
            double? res = 0.0;
            double? n = 0;
            for (int i = 1; i < Row; i++)
            {
                for (int j = 1; j < Col; j++)
                {
                    if (Table[i, j] != null)
                    {
                        res += Table[i, j] * Math.Pow(Convert.ToDouble(Table[i, 0] - func(Table[0, j])), 2);
                        n += Table[i, j];
                    }
                }
            }
            return res / n;
        }

        public double? CountDelta(Func<double?, double?> func)
        {
            double? res = 0.0;
            double? n = 0;
            for (int i = 1; i < Col; i++)
            {
                double? yxi = 0.0;
                n = 0;
                for (int j = 1; j < Row; j++)
                {
                    if (Table[j, i] != null)
                    {
                        yxi += Table[j, i] * Table[j, 0];
                        n += Table[j, i];
                    }
                }
                res += Math.Pow(Math.Abs(Convert.ToDouble(yxi/n - func(Table[0, i]))), 2) * n;
            }
            return res;
        }

        public static string print_sigma(double? sigma) => $"Sigma = {String.Format("{0:0.00}", sigma)};";
        public static string print_delta(double? delta) => $"Delts ^ 2 = {String.Format("{0:0.00}", delta)};";
    }
}
