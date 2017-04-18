using System;

namespace Turtle.Aop
{
    public class ProxyFactory
    {
        public static T CreateProxyInstance<T>(IInterception interception) where T : new()
        {
            var serverType = typeof(T);
            var target = Activator.CreateInstance(serverType) as MarshalByRefObject;
            var aopRealProxy = new AopRealProxy(serverType, target);
            aopRealProxy.InterceptionDi(interception);

            return (T) aopRealProxy.GetTransparentProxy();
        }
    }
}