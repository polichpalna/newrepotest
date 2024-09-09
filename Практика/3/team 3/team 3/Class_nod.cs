

namespace team_3
{
    public class Class_nod : Class
    {
        public Class_nod(int num1, int num2) : base(num1, num2)
        {
        }

        public int calculate_nod()
        {
            int x = a;
            int y = b;
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }
    }
}
