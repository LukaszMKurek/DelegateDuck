using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using DelegateDuck.Signatures;
using JetBrains.Annotations;

namespace DelegateDuck.Implementation
{
   public sealed class Interceptor : IInterceptor
   {
      private readonly MemberInvoker _memberInvoker;
      private readonly MemberContainer _memberContainer;

      public Interceptor([NotNull] MemberContainer memberContainer)
      {
         _memberContainer = memberContainer;
         _memberInvoker = new MemberInvoker(new SignatureComparerForStatic());
      }

      // IOnBehalfAware - for optymization

      public void Intercept(IInvocation invocation)
      {
         PropertyInfo property;
         if (IsGetter(invocation.Method, out property))
         {
            invocation.ReturnValue = CallGetter(property);
         }
         else if (IsSetter(invocation.Method, out property))
         {
            CallSetter(invocation, property);
         }
         else
         {
            invocation.ReturnValue = CallMethod(invocation);
         }
      }

      private object CallMethod(IInvocation invocation)
      {
         object result;
         Signature signature = SignatureBuilderForStatic.BuildMethod(invocation.Method);
         string methodName = invocation.Method.Name;
         if (_memberInvoker.TryInvokeMethod(_memberContainer, methodName, invocation.Arguments, out result, signature) == false)
            throw new MemberMissingException(string.Format("Method '{0}' not found.", methodName));

         return result;
      }

      private void CallSetter(IInvocation invocation, PropertyInfo property)
      {
         object value = invocation.Arguments[0];
         Signature setterSigniature = SignatureBuilderForStatic.BuildSetter(property.PropertyType);
         if (_memberInvoker.TrySetPropertyValue(_memberContainer, property.Name, value, setterSigniature) == false)
            throw new MemberMissingException(string.Format("Property setter '{0}' not found.", property.Name));
      }

      private object CallGetter(PropertyInfo property)
      {
         object result;
         Signature getterSigniature = SignatureBuilderForStatic.BuildGetter(property.PropertyType);
         if (_memberInvoker.TryGetPropertyValue(_memberContainer, property.Name, out result, getterSigniature) == false)
            throw new MemberMissingException(string.Format("Property getter '{0}' not found.", property.Name));

         return result;
      }

      private static bool IsGetter(MethodInfo method, out PropertyInfo property)
      {
         property = null;
         if (method.DeclaringType == null) //to jest niemo¿liwe dla metody
            return false; // because global methods can't be property

         property = method.DeclaringType.GetProperties().FirstOrDefault(p => p.GetGetMethod() == method);
         return property != null;
      }

      private static bool IsSetter(MethodInfo method, out PropertyInfo property)
      {
         property = null;
         if (method.DeclaringType == null) //to jest niemo¿liwe dla metody
            return false; // because global methods can't be property

         property = method.DeclaringType.GetProperties().FirstOrDefault(p => p.GetSetMethod() == method);
         return property != null;
      }
   }
}
