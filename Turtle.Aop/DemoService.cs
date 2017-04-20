using System;
using Turtle.Aop.Core;

namespace Turtle.Aop
{
    public class DemoService : ServiceBase
    {
        public static DemoService GetInstance()
        {
            return ProxyFactory.CreateProxyInstance<DemoService, DemoInterception>();
        }

        public int DemoMethod(string a, int b, long c)
        {
            Console.WriteLine("Hello world.");
            return 233;
        }
    }
}