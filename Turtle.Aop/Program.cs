using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var testService = ProxyFactory.CreateProxyInstance<TestService>(new ConsoleInterception());
            testService.TestLogic();
            Console.ReadLine();
        }
    }

    public class TestService : ServiceBase
    {
        public void TestLogic()
        {
            Console.WriteLine("Logic");
        }
    }
}