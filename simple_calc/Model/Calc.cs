using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simple_calc.Interfaces;

namespace simple_calc.Model
{
    internal class Calc: IBasicCalcOperation
    {
        public Calc() { }

        #region basic operations
        public double Add(double frst_num, double scnd_num)
        {
            return frst_num + scnd_num;
        }

        public double Substract(double frst_num, double scnd_num)
        {
            return frst_num - scnd_num;
        }

        public double Mult(double frst_num, double scnd_num)
        {
            return frst_num * scnd_num;
        }

        public double Divide(double frst_num, double scnd_num)
        {
            return frst_num / scnd_num;
        }

        public double SqRoot(double number)
        {
            return Math.Sqrt(number);
        }

        public double Percent(double number, double percent)
        {
            return number * percent / 100;
        }

        public double InverseNumber(double number)
        {
            return 1 / number;
        }
        #endregion
    }
}
