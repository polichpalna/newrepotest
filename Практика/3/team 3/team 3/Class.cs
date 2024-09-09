
namespace team_3
{
    public class Class
    {
        protected int a;
        protected int b;
        public Class()
        {

        }  
        public Class(int A, int B)
        { 
            a = A;
            b = B;
        }
        public Class(Class cl)
        {
            a = cl.a;
            b = cl.b;
        }

    }
}
