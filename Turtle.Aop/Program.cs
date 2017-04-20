using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main()
        {
            var testService = DemoService.GetInstance();
            testService.DemoMethod("Tome", 1, 2L);
            Console.ReadLine();
        }
    }
}