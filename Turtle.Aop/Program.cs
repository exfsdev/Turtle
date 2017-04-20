using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var testService = TestService.GetProxyInstance();
            testService.HelloTest("Tome", 1, 2L);
            Console.ReadLine();
        }
    }

    public class TestService : ServiceBase
    {
        public static TestService GetProxyInstance()
        {
            return ProxyFactory.CreateProxyInstance<TestService>(new ConsoleInterception());
        }

        public int HelloTest(string a, int b, long c)
        {
            Console.WriteLine("Hello world.");
            return 233;
        }
    }
}