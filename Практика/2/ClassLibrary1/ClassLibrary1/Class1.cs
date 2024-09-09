using System;
using System.Linq.Expressions;

namespace ClassLibrary1
{
    public class Class1
    {
        public Class1() { }
        public int n;

        public double calculate(double x, double epsilon)
        {
            try
            {
                double term = x;
                double b = x;
                double result =0;
                double par = x * x / 2;
                n = 1;       
                while (Math.Abs(term) >epsilon* Math.Abs(result))
                {
                    b *= par* (2 * n - 1) / n;
                    term = b/(2*n+1); 
                    result += term;
                    n++; 
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }       
        }

        public double calculate_arcsin(double x, double epsilon)
        {
            double result = 0;
            result = Math.Asin(x) - x;

            return result ;
        }
    }
}
