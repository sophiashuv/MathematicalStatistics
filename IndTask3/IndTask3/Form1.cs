using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IndTask3
{
    public partial class Form1 : Form
    {

        private CorrelationTable table;
        private HyperbolicFunction HypFunc;
        private ExponentialFunction ExpFunc;
        private RootFunction RootFunc;
        private ParabolicFunction ParabFunc;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cells = new List<string> { "", cell2.Text, cell3.Text, cell4.Text, cell5.Text, cell6.Text, cell7.Text, cell8.Text,
                                           cell9.Text, cell10.Text, cell11.Text, cell12.Text, cell13.Text, cell14.Text, cell15.Text, cell16.Text,
                                           cell17.Text, cell18.Text, cell19.Text, cell20.Text, cell21.Text, cell22.Text, cell23.Text, cell24.Text,
                                           cell25.Text, cell26.Text, cell27.Text, cell28.Text, cell29.Text, cell30.Text, cell31.Text, cell32.Text,
                                           cell33.Text, cell34.Text, cell35.Text, cell36.Text, cell37.Text, cell38.Text, cell39.Text, cell40.Text,
                                           cell41.Text, cell42.Text, cell43.Text, cell44.Text, cell45.Text, cell46.Text, cell47.Text, cell48.Text,
                                           cell49.Text, cell50.Text, cell51.Text, cell52.Text, cell53.Text, cell54.Text, cell55.Text, cell56.Text};


            table = new CorrelationTable(cells, tableLayoutPanel1.RowCount, tableLayoutPanel1.ColumnCount);
          
            var Xyi = table.CountXMean();
            var Yxi = table.CountYMean();
      
            var XyiCells = new List<Label> { xy1, xy2, xy3, xy4, xy5, xy6 };
            var YxiCells = new List<Label> { yx1, yx2, yx3, yx4, yx5, yx6, yx7 };

            for (int i = 0; i < XyiCells.Count; i++)
                XyiCells[i].Text = String.Format("{0:0.00}", Xyi[i]);

            for (int i = 0; i < YxiCells.Count; i++)
                YxiCells[i].Text = String.Format("{0:0.00}", Yxi[i]);

            chart1.Series["(X, Xy)"].Points.Clear();
            chart1.Series["Функція регресії"].Points.Clear();
            chart1.Series["Гіперболічна функція"].Enabled = false;
            chart1.Series["Гіперболічна функція"].Points.Clear();
            chart1.Series["Показникова функція"].Points.Clear();
            chart1.Series["Показникова функція"].Enabled = false;
            chart1.Series["Коренева функція"].Points.Clear();
            chart1.Series["Коренева функція"].Enabled = false;
            chart1.Series["Параболічна функція"].Points.Clear();
            chart1.Series["Параболічна функція"].Enabled = false;
            for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
            {
                chart1.Series["(X, Xy)"].Points.AddXY(table.Table[0, i], table.CountYMean()[i - 1]);
                chart1.Series["Функція регресії"].Points.AddXY(table.Table[0, i], table.CountYMean()[i - 1]);
            }
                
            HypFunc = new HyperbolicFunction(table.CountHyperbola());
            ExpFunc = new ExponentialFunction(table.CountExp());
            RootFunc = new RootFunction(table.CountSqrt());
            ParabFunc = new ParabolicFunction(table.CountParab());

            panel3.Visible = true;
            panel7.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                chart1.Series["(X, Xy)"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["(X, Xy)"].Points.AddXY(table.Table[0, i], table.CountYMean()[i - 1]);
            }
            else
            {
                chart1.Series["(X, Xy)"].Points.Clear();
                chart1.Series["(X, Xy)"].Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                chart1.Series["Функція регресії"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["Функція регресії"].Points.AddXY(table.Table[0, i], table.CountYMean()[i - 1]);
            }
            else
            {
                chart1.Series["Функція регресії"].Points.Clear();
                chart1.Series["Функція регресії"].Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                chart1.Series["Гіперболічна функція"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["Гіперболічна функція"].Points.AddXY(table.Table[0, i], HypFunc.funk(table.Table[0, i]));
            }
            else
            {
                chart1.Series["Гіперболічна функція"].Points.Clear();
                chart1.Series["Гіперболічна функція"].Enabled = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                chart1.Series["Показникова функція"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["Показникова функція"].Points.AddXY(table.Table[0, i], ExpFunc.funk(table.Table[0, i]));
            }
            else
            {
                chart1.Series["Показникова функція"].Points.Clear();
                chart1.Series["Показникова функція"].Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                chart1.Series["Коренева функція"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["Коренева функція"].Points.AddXY(table.Table[0, i], RootFunc.funk(table.Table[0, i]));
            }
            else
            {
                chart1.Series["Коренева функція"].Points.Clear();
                chart1.Series["Коренева функція"].Enabled = false;
            }

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                chart1.Series["Параболічна функція"].Enabled = true;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i++)
                    chart1.Series["Параболічна функція"].Points.AddXY(table.Table[0, i], ParabFunc.funk(table.Table[0, i]));
            }
            else
            {
                chart1.Series["Параболічна функція"].Points.Clear();
                chart1.Series["Параболічна функція"].Enabled = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            hyp.Text =  HypFunc.PrintCoefs();
            hyp.Text += "\n" + HypFunc.PrintFunction();
            
            HypEquolity.Text = HypFunc.PrintEquolity();
           
            var sygmaHyp = table.CountSigma(HypFunc.funk);
            var deltaHyp = table.CountDelta(HypFunc.funk);
          
            hyp2.Text = CorrelationTable.print_sigma(sygmaHyp);
            hyp2.Text += "\n" + CorrelationTable.print_delta(deltaHyp);
            panel5.Visible = true;
            checkBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpEquolity.Text = ExpFunc.PrintEquolity();
            exp.Text = ExpFunc.PrintCoefs();
            exp.Text += "\n" + ExpFunc.PrintFunction();
            var sygmaExp = table.CountSigma(ExpFunc.funk);
            var deltaExp = table.CountDelta(ExpFunc.funk);
            exp2.Text = CorrelationTable.print_sigma(sygmaExp);
            exp2.Text += "\n" + CorrelationTable.print_delta(deltaExp);
            panel6.Visible = true;
            checkBox4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqrtEquolity.Text = RootFunc.PrintEquolity();
            sqrt.Text = RootFunc.PrintCoefs();
            sqrt.Text += "\n" + RootFunc.PrintFunction();
            var sygmaSqrt = table.CountSigma(RootFunc.funk);
            var deltaSqrt = table.CountDelta(RootFunc.funk);
            sqrt2.Text = CorrelationTable.print_sigma(sygmaSqrt);
            sqrt2.Text += "\n" + CorrelationTable.print_delta(deltaSqrt);
            panel11.Visible = true;
            checkBox5.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ParabEquolity.Text = ParabFunc.PrintEquolity();
            parab.Text = ParabFunc.PrintCoefs();
            parab.Text += "\n" + ParabFunc.PrintFunction();
            var sygmaParab = table.CountSigma(ParabFunc.funk);
            var deltaParab = table.CountDelta(ParabFunc.funk);
            parab2.Text = CorrelationTable.print_sigma(sygmaParab);
            parab2.Text += "\n" + CorrelationTable.print_delta(deltaParab);
            panel12.Visible = true;
            checkBox6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel11.Visible = false;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            panel12.Visible = false;
        }
    }
}
