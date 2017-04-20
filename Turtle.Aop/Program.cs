using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var testService = AService.GetProxyInstance();
            testService.HelloTest("Tome", 1, 2L);
            Console.ReadLine();
        }
    }

    public class AService : ServiceBase
    {
        public static AService GetProxyInstance()
        {
            return ProxyFactory.CreateProxyInstance<AService>(new ConsoleInterception());
        }

        public int HelloTest(string a, int b, long c)
        {
            Console.WriteLine("Hello world.");
            return 233;
        }
    }

    [AopProxy]
    public class BService : ServiceBase
    {
        public static BService GetProxyInstance()
        {
            return ProxyFactory.CreateProxyInstance<BService>(new ConsoleInterception());
        }

        public int HelloTest(string a, int b, long c)
        {
            Console.WriteLine("Hello world.");
            return 233;
        }
    }
}