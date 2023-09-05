using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using simple_calc.Interfaces;

namespace simple_calc.Model
{

    //Получает строку выражения. Выделяет операнды и оператор.
    internal class Expression : ISimpleExpressionParser
    {
        public double OperandA { get; set; }
        public double OperandB { get; set; }
        public string Operator { get; set; }
        public bool IsBinary { get; set; }
        char[] operations = new char[] { '+', '/', '*', '-', '√' };
        char[] unary_operator = new char[] { '√' };
        public Expression()
        {
            OperandA = 0;
            OperandB = 0;
            Operator = null;
            IsBinary = true;
        }
        public void ClearFields()
        {
            OperandA = 0;
            OperandB = 0;
            Operator = null;
        }
        #region private methods
        string GetOperation(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                for (int j = 0; j < operations.Length; j++)
                {
                    if (operations[j] == expression[i])
                    {
                        Operator = operations[j].ToString();
                        for (int k = 0; k < unary_operator.Length; k++)
                        {
                            if (unary_operator[k] == Operator[0]) IsBinary = false;
                        }
                        return Operator;
                    }
                }
            }
            return null;
        }

        double GetFrstNum (string expression)
        {
            StringBuilder sb = new StringBuilder();

            if(Operator == "√")
            {
                return GetScndNum (expression);
            }
            else
            {
                for(int i=0; i < expression.Length; i++)
                {
                    for(int j=0; j< operations.Length; j++)
                    {
                        if (expression[i] == operations[j])
                        {
                            OperandA = Convert.ToDouble(sb.ToString());
                            return OperandA;
                        }
                    }
                    sb.Append(expression[i].ToString());
                }
            }
            throw new Exception("Check Expressions.cs double GetFrstNum.");
        }


        double GetScndNum(string expression)
        {
            StringBuilder sb = new StringBuilder();
            int start_point = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                start_point++;
                if (expression[i] == Operator[0]) break;
            }

            for (int i = start_point; i < expression.Length; i++)
            {
                if (expression[i] == '\0') break;
                sb.Append(expression[i].ToString());
            }
            OperandB = Convert.ToDouble(sb.ToString());
            return OperandB;
        }
        #endregion
        public void Parse(string expression)
        {
            GetOperation(expression);
            GetFrstNum(expression);
            if (IsBinary == false) return;
            GetScndNum(expression);
        }
    }
}
