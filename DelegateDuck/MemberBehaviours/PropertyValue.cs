using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class PropertyValue : IPropertyGetter, IPropertySetter
   {
      private object _value;
      private readonly Signature _getterSignature;
      private readonly Signature _setterSignature;

      public PropertyValue(object value, Type resultType)
      {
         _value = value;
         _getterSignature = SignatureBuilderForStatic.BuildGetter(resultType);
         _setterSignature = SignatureBuilderForStatic.BuildSetter(resultType);
      }

      object IPropertyGetter.GetPropertyValue(Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignature(signature, _getterSignature);

         return _value;
      }

      void IPropertySetter.SetPropertyValue(object value, Signature signature, ISignatureComparer signatureComparer)
      {
         signatureComparer.ValidateSignature(signature, _setterSignature);
         _value = value;
      }

      string IMember.TypeName
      {
         get { return "PropertyValue"; }
      }
   }
}
