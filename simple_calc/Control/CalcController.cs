using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using simple_calc.Model;

namespace simple_calc.Control
{
    //Этот класс должен парсить итоговую строку, которая передаётся в конструктор, выделить два операнда и один опрератор (или один операнд в случае корня).
    //После этого для вычисления результата будут вызываться методы из композированного объекта калькулятора.
    //В конце строка выражения дополняется результатом вычислений и возвращается в TextBox в необходимом формате.
    public class CalcController 
    {
        Calc calc;
        Expression expr;
        string expression;
        public void SetExpression(string expression)
        {
            this.expression = expression;
        }

        public CalcController()
        {
            calc = new Calc();
            expr = new Expression();
        }
        public CalcController(string expression) : base()
        { 
            this.expression = expression;
        }

        public double Solve (string expression)
        {
            try
            {
                expr.Parse(expression);
                switch (expr.Operator[0])
                {
                    case '+':
                        return calc.Add(expr.OperandB, expr.OperandA);
                    case '-':
                        return calc.Substract(expr.OperandA, expr.OperandB);
                    case '*':
                        return calc.Mult(expr.OperandA, expr.OperandB);
                    case '/':
                        return calc.Divide(expr.OperandA, expr.OperandB);
                    case '√':
                        return calc.SqRoot(expr.OperandB);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return 0;
        }
    }
}
