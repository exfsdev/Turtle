using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main()
        {
            var testService = DemoService.GetProxyInstance();
            testService.DemoMethod("Tome", 1, 2L);
            Console.ReadLine();
        }
    }
}