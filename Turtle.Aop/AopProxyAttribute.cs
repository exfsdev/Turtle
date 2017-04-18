using System;
using System.Runtime.Remoting.Proxies;

namespace Turtle.Aop
{
    /// Description of AopProxyAttribute.
    [AttributeUsage(AttributeTargets.Class)]
    public class AopProxyAttribute : ProxyAttribute
    {
        private IInterception _interception;

        public AopProxyAttribute()
        {
            _interception = new ConsoleInterception();
        }

        public Type Interception
        {
            get => _interception.GetType();
            set
            {
                var interception = Activator.CreateInstance(value) as IInterception;
                _interception = interception;
            }
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