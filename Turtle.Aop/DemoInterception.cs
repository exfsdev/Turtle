using System;
using System.Runtime.Remoting.Messaging;
using Turtle.Aop.Core;

namespace Turtle.Aop
{
    public class DemoInterception : IInterception
    {
        // ReSharper disable once InconsistentNaming
        private const string _LINE = "-------------------------------------";

        public virtual void PreInvoke(IMethodCallMessage methodCallMessage)
        {
            Console.WriteLine(_LINE);
            Console.WriteLine("START METHOD : {0}", methodCallMessage.MethodName);
            Console.WriteLine(_LINE);
            for (var i = 0; i < methodCallMessage.Args.Length; i++)
                Console.WriteLine("ARG{0} - {1} : {2} : {3}",
                    i,
                    methodCallMessage.GetInArgName(i),
                    methodCallMessage.InArgs[i].GetType(),
                    methodCallMessage.InArgs[i]);
            Console.WriteLine();
            Console.WriteLine(_LINE);
        }

        public virtual void AfterInvoke(IMethodReturnMessage methodReturnMessage)
        {
            Console.WriteLine(_LINE);
            Console.WriteLine("METHOD END : {0}", methodReturnMessage.MethodName);
            Console.WriteLine(_LINE);
            Console.WriteLine("RETURN VALUE : {0}", methodReturnMessage.ReturnValue);
            Console.WriteLine();
            Console.WriteLine(_LINE);
        }

        public void ExceptionHandle(Exception exception)
        {
            Console.WriteLine("Aop.DemoInterception.ExceptionHandle");
        }
    }
}