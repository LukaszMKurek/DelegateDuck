using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class PropertyGetter<TValue> : IPropertyGetter
   {
      private readonly Func<TValue> _getter;
      private readonly Signature _getterSignature;

      public PropertyGetter(Func<TValue> getter)
      {
         _getter = getter;
         _getterSignature = SignatureBuilderForStatic.BuildGetter(typeof(TValue));
      }

      object IPropertyGetter.GetPropertyValue(Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignature(signature, _getterSignature);

         return _getter();
      }
      
      string IMember.TypeName
      {
         get { return "PropertyGetter"; }
      }
   }
}