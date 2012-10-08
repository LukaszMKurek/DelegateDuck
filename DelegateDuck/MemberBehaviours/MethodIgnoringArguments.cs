using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class MethodIgnoringArguments<TResult> : IMethod
   {
      private readonly Func<TResult> _delegate;
      private readonly Signature _signature;

      public MethodIgnoringArguments(Func<TResult> @delegate)
      {
         _delegate = @delegate;
         _signature = SignatureBuilderForStatic.BuildGetter(typeof(TResult));
      }

      object IMethod.InvokeMethod(object[] arguments, Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignatureReturnType(signature, _signature);

         return _delegate();
      }

      string IMember.TypeName
      {
         get { return "MethodIgnoringArguments"; }
      }
   }
}
