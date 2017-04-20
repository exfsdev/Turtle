﻿using System;
using System.Runtime.Remoting.Messaging;

namespace Turtle.Aop.Core
{
    public interface IInterception
    {
        void PreInvoke(IMethodCallMessage methodCallMessage);

        void AfterInvoke(IMethodReturnMessage methodReturnMessage);

        void ExceptionHandle(Exception exception);
    }
}