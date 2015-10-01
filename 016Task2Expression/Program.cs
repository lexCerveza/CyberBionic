using System;
using System.Linq.Expressions;

namespace _016Task2Expression
{
    class Program
    {
        static void Main()
        {
            var x = Expression.Parameter(typeof (int), "x");

            var subBody = Expression.Subtract(x, Expression.Constant(3));
            var mulBody = Expression.Multiply(subBody, Expression.Constant(2));
            var addBody = Expression.Subtract(x, Expression.Constant(4));

            var expressionBody = Expression.Add(mulBody, addBody);

            var expression = Expression.Lambda<Func<int, int>>(expressionBody, x);

            Console.WriteLine(expression.Compile().Invoke(3));
            Console.Read();
        }
    }
}
