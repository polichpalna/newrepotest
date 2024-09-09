using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_3
{
    public class Class_nok : Class_nod
    {
        public Class_nok (int x, int y):base(x, y)
        {

        }
        public int calculate_nok()
        {
            int gcd = calculate_nod();
            return (a * b) / gcd;
        }
    }
}
