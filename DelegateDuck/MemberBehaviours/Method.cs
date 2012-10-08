using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class Method : IMethod
   {
      private readonly Delegate _delegate;
      private readonly Signature _signature;

      public Method(Delegate @delegate)
      {
         _delegate = @delegate;
         _signature = SignatureBuilderForStatic.BuildMethod(@delegate.Method);
      }

      object IMethod.InvokeMethod(object[] argumentValues, Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignature(signature, _signature);

         return _delegate.DynamicInvokeWithFixProblemWithNullable(argumentValues);
      }

      string IMember.TypeName
      {
         get { return "Method"; }
      }
   }
   
   // todo overload zribæ na defaultBinder
}
