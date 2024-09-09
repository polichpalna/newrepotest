using System;

namespace ClassLibrary1
{
    public class Class1

    {
        public Class1() { }
        public int a;
        public bool grade;
        public bool rade;
        
        public double pars(double val)
        {
            if (grade)
            {
                return val*(Math.PI/180.0);
            }
            else if(rade)
            {
                return val;
            }
            grade = false;
            rade = false;
            return 0;
        }


        public double res_z1(double z1)
        {
            double val = pars(z1);
            double z = 1-((Math.Pow(Math.Sin(2*val),2))/4)+Math.Cos(2*val);
            return z;
        }

        public double res_z2(double z2)
        {
            double val = pars(z2);
            double co1 = Math.Pow(Math.Cos(val),2);
            double z = co1+Math.Pow(co1,2);
            return z;
        }
    }
}
