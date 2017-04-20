using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;

namespace Turtle.Aop
{
    public class AopRealProxy : RealProxy
    {
        private readonly MarshalByRefObject _target;
        private IInterception _interception;

        public AopRealProxy(Type targetType, MarshalByRefObject target)
            : base(targetType)
        {
            _target = target;
            _interception = new ConsoleInterception();
        }

        #region IProxyDI Members

        public void InterceptionDi(IInterception interception)
        {
            _interception = interception;
        }

        #endregion

        public override IMessage Invoke(IMessage msg)
        {
            IMethodReturnMessage methodReturnMessage = null;
            var methodCallMessage = msg as IMethodCallMessage; //Check whether the message is method call message.
            if (methodCallMessage != null)
            {
                var constructionCallMessage = methodCallMessage as IConstructionCallMessage;
                if (constructionCallMessage != null)
                {
                    var defaultProxy = RemotingServices.GetRealProxy(_target);
                    defaultProxy.InitializeServerObject(constructionCallMessage);
                    methodReturnMessage =
                        EnterpriseServicesHelper.CreateConstructionReturnMessage(constructionCallMessage,
                            (MarshalByRefObject) GetTransparentProxy());
                }
                else
                {
                    _interception.PreInvoke(methodCallMessage);
                    try
                    {
                        methodReturnMessage = RemotingServices.ExecuteMessage(_target, methodCallMessage);
                    }
                    catch
                    {
                        // ignored
                    }
                    if (methodReturnMessage?.Exception != null)
                        _interception.ExceptionHandle(methodReturnMessage.Exception);
                    else
                        _interception.AfterInvoke(methodReturnMessage);
                }
            }
            return methodReturnMessage;
        }
    }
}