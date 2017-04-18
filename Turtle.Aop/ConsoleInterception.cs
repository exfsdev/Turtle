using System;

namespace Turtle.Aop
{
    public class ConsoleInterception : IInterception
    {
        /// Before invoke the real instance to do something.
        public virtual void PreInvoke()
        {
            Console.WriteLine("Aop.ConsoleInterception.PreInvoke");
        }

        /// End invoke the real instance to do something.
        public virtual void AfterInvoke()
        {
            Console.WriteLine("Aop.ConsoleInterception.AfterInvoke");
        }

        /// Handling the exception which occurs when the method is invoked.
        public void ExceptionHandle()
        {
            Console.WriteLine("Aop.ConsoleInterception.ExceptionHandle");
        }
    }
}