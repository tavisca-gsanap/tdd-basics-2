using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        char[] keys;
        bool number1turn = true;
        string number1 = "0";
        string number2 = "0";
        char @operator = '^';
        string digits = "0123456789.";
        string operators = "+-xX/";
        public string SendKeyPress(char key)
        {
            if (digits.Contains(key + ""))
            {
                if (number1turn)
                {
                    if (CheckValidity(number1, key)) number1 += key;
                    //Console.Write(number1);
                }
                else
                {
                    if (CheckValidity(number2, key)) number2 += key;
                    //Console.Write(number2);
                }
            }
            else if (operators.Contains(key + ""))
            {
                if (@operator == '^') @operator = key;
                //Console.Clear();
                if (number1turn)
                {
                    number1turn = false;
                }
                else
                {
                    number1 = Calculate(Double.Parse("0" + number1), Double.Parse("0"+number2), @operator);
                    number2 = "0";
                }
                if (@operator != '^') @operator = key;
                //Console.Write(number1);
            }
            else if (key == 'c' || key == 'C') 
            {
                //Console.Clear();
                number1 = "0";
                number2 = "0";
            }
            else if (key == 's' || key == 'S')
            {
                //Console.Clear();
                if (number1turn)
                {
                    number1 = (Double.Parse(number1) * -1) + "";
                    //Console.Write(number1);
                }
                else
                {
                    number2 = (Double.Parse(number2) * -1) + "";
                    //Console.Write(number2);
                }
            }
            else if (key == '=') 
            {
                if (@operator != '^' && operators.Contains(@operator+""))
                {
                    number1 = Calculate(Double.Parse(number1), Double.Parse(number2), @operator);
                }
                number2 = "0";
                //Console.Clear();
                //Console.Write(number1);
            }
            return number1;
        }

        private bool CheckValidity(string number, char key)
        {
            if (key == '.' && number.Contains(".")) return false;
            else if (key == '0' && number.Equals("0")) return false;
            else return true;
        }

        private string Calculate(double number1, double number2, char @operator)
        {
            string answer = "";
            switch (@operator)
            {
                case('+'):
                    answer = number1 + number2 + "";
                    break;
                case ('-'):
                    answer = number1 - number2 + "";
                    break;
                case ('x'):
                    answer = number1 * number2 + "";
                    break;
                case ('X'):
                    answer = number1 * number2 + "";
                    break;
                case ('/'):
                    double ans = number1 / number2;
                    if (ans == (1.0 / 0.0))
                    {
                        answer = "-E-";
                    }
                    else
                    {
                        answer = ans + "";
                    }
                    break;
                default:
                    break;
            }
            return answer;
        }
    }
}
