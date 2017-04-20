using System;
using System.Runtime.Remoting.Proxies;

namespace Turtle.Aop
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AopProxyAttribute : ProxyAttribute
    {
        private readonly IInterception _interception;

        public AopProxyAttribute()
        {
            _interception = new ConsoleInterception();
        }

        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            var target = base.CreateInstance(serverType);
            var aopRealProxy = new AopRealProxy(serverType, target);
            aopRealProxy.InterceptionDi(_interception);
            return aopRealProxy.GetTransparentProxy() as MarshalByRefObject;
        }
    }
}