using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Castle.DynamicProxy;
using DelegateDuck.Signatures;

namespace DelegateDuck.Implementation
{
   public sealed class Duck : DynamicObject
   {
      private readonly MemberInvoker _memberInvoker = new MemberInvoker(new SignatureComparerForDynamic());
      private readonly MemberContainer _memberContainer = new MemberContainer();

      public override bool TryGetMember(GetMemberBinder binder, out object result)
      {
         var signature = SignatureBuilderForDynamic.BuildGetter(binder.ReturnType);

         return _memberInvoker.TryGetPropertyValue(_memberContainer, binder.Name, out result, signature);
      }

      public override bool TrySetMember(SetMemberBinder binder, object value)
      {
         var signature = SignatureBuilderForDynamic.BuildSetter(value);

         return _memberInvoker.TrySetPropertyValue(_memberContainer, binder.Name, value, signature);
      }

      public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
      {
         var signature = SignatureBuilderForDynamic.BuildMethod(binder.ReturnType, args);
         if (_memberContainer.ContainsFunction(binder.Name) == false)
         {
            result = null;
            return false;
         }

         return _memberInvoker.TryInvokeMethod(_memberContainer, binder.Name, args, out result, signature);
      }

      public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
      {
         int i = 0;
         foreach (string name in binder.CallInfo.ArgumentNames)
         {
            _memberContainer.AddMember(name, args[i]);

            i += 1;
         }

         result = this;
         return true;
      }

      public override bool TryConvert(ConvertBinder binder, out object result)
      {
         result = new ProxyGenerator().
            CreateInterfaceProxyWithoutTarget(binder.Type, new Interceptor(_memberContainer));
         return true;
      }

      public static dynamic New
      {
         get { return new Duck(); }
      }
   }
}
