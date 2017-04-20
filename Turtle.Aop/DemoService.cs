using System;
using Turtle.Framework.Aop;

namespace Turtle.Aop
{
    public class DemoService : ProxyObject
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