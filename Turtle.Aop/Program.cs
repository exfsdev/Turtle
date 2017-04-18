using System;

namespace Turtle.Aop
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var service1 = ProxyFactory.CreateProxyInstance<TestService>(new ConsoleInterception()); // work
            service1.TestLogic();

            Console.WriteLine("----------------------------------------------");

            var service2 = new TestService(); // do not work
            service2.TestLogic();

            Console.ReadLine();
        }
    }

    [AopProxy]
    public class TestService : ServiceBase
    {
        public void TestLogic()
        {
            Console.WriteLine("Logic");
        }
    }
}