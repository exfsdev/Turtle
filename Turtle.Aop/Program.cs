using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main()
        {
            DemoService.GetInstance().DemoMethod("Tome", 1, 2L);
            Console.ReadLine();
        }
    }
}