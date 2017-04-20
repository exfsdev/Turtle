using System;

namespace Turtle.Aop.Core
{
    public class ProxyFactory
    {
        public static TRealType CreateProxyInstance<TRealType, TInterception>()
            where TRealType : new()
            where TInterception : IInterception, new()
        {
            var serverType = typeof(TRealType);
            var target = Activator.CreateInstance(serverType) as MarshalByRefObject;
            var aopRealProxy = new AopRealProxy<TInterception>(serverType, target, new TInterception());
            aopRealProxy.InterceptionDi(new TInterception());
            return (TRealType) aopRealProxy.GetTransparentProxy();
        }
    }
}