namespace Turtle.Aop
{
    public interface IInterception
    {
        /// Pre the method invoke.
        void PreInvoke();

        /// Post the method invoke.
        void AfterInvoke();

        /// Handling the exception which occurs when the method is invoked.
        void ExceptionHandle();
    }
}