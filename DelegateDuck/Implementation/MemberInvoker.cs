using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Signatures;
using JetBrains.Annotations;

namespace DelegateDuck.Implementation
{
   public sealed class MemberInvoker
   {
      private readonly ISignatureComparer _signatureComparer;

      public MemberInvoker([NotNull] ISignatureComparer signatureComparer)
      {
         _signatureComparer = signatureComparer;
      }

      public bool TrySetPropertyValue([NotNull] MemberContainer memberContainer, [NotNull] string memberName, object value, Signature signature)
      {
         return memberContainer.TryFindMember<IPropertySetter>(
            name: memberName,
            expectedMemberTypeName: "property setter",
            whenFind: propertySetter => propertySetter.SetPropertyValue(value, signature, _signatureComparer));
      }

      public bool TryGetPropertyValue([NotNull] MemberContainer memberContainer, [NotNull] string memberName, out object result, Signature signature)
      {
         object res = null;
         bool find = memberContainer.TryFindMember<IPropertyGetter>(
            name: memberName,
            expectedMemberTypeName: "property getter",
            whenFind: propertyGetter => { res = propertyGetter.GetPropertyValue(signature, _signatureComparer); });

         result = res;
         return find;
      }

      public bool TryInvokeMethod([NotNull] MemberContainer memberContainer, [NotNull] string memberName, [NotNull] object[] args, out object result, Signature signature)
      {
         object res = null;
         bool find = memberContainer.TryFindMember<IMethod>(
            name: memberName,
            expectedMemberTypeName: "method",
            whenFind: method => { res = method.InvokeMethod(args, signature, _signatureComparer); });

         result = res;
         return find;
      }
   }
}
