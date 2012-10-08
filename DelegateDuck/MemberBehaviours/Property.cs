using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.Signatures;

namespace DelegateDuck.MemberBehaviours
{
   public sealed class Property : IPropertyGetter, IPropertySetter
   {
      private readonly IPropertyGetter _getter;
      private readonly IPropertySetter _setter;

      public Property(IPropertyGetter getter, IPropertySetter setter)
      {
         _getter = getter;
         _setter = setter;
      }

      object IPropertyGetter.GetPropertyValue(Signature signature, ISignatureComparer signatureComparer)
      {
         return _getter.GetPropertyValue(signature, signatureComparer);
      }

      void IPropertySetter.SetPropertyValue(object value, Signature signature, ISignatureComparer signatureComparer)
      {
         _setter.SetPropertyValue(value, signature, signatureComparer);
      }

      string IMember.TypeName
      {
         get { return "PropertyAccesors"; }
      }
   }
}
