using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class PropertySetter<TValue> : IPropertySetter
   {
      private readonly Action<TValue> _setter;
      private readonly Signature _setterSignature;

      public PropertySetter(Action<TValue> setter)
      {
         _setter = setter;
         _setterSignature = SignatureBuilderForStatic.BuildSetter(typeof(TValue));
      }

      void IPropertySetter.SetPropertyValue(object value, Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignature(signature, _setterSignature);

         _setter.DynamicInvokeWithFixProblemWithNullable(value);
      }
      
      string IMember.TypeName
      {
         get { return "PropertySetter"; }
      }
   }
}