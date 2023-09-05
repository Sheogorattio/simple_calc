using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calc.Interfaces
{
    public interface IBasicCalcOperation
    {
        double Add(double frst_num, double scnd_num);
        double Substract(double frst_num, double scnd_num);
        double Mult(double frst_num, double scnd_num);
        double Divide(double frst_num, double scnd_num);
        double SqRoot(double number);
        double Percent(double number, double percent);
        double InverseNumber(double number);
    }
}
