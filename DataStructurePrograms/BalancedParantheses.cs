using System;
namespace DataStructurePrograms
{
    public class BalancedParantheses<T>
    {
        StackOperation<T> stack = new StackOperation<T>();
        public void CheckParanthesis()
        {
            string Expression = "(5+6)*(7+8)";
            char[] expArray = Expression.ToCharArray();

            foreach (char i in expArray)
            {
                Console.WriteLine(i);
                if (i == '(')
                {
                    T x = (T)Convert.ChangeType(i, typeof(T));
                    stack.Push(x);
                    stack.Display();
                }
                else if (i == ')')
                {
                    stack.Pop();
                    stack.Display();
                }
            }
            if (stack.ElementsCountOfStack() > 0)
            {
                Console.WriteLine("Un Balanced Expression");
            }
            else
            {
                Console.WriteLine("Balanced Expression");
            }

        }
    }
}
