using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Signatures;
using JetBrains.Annotations;

namespace DelegateDuck.Implementation
{
   public interface IMember
   {
      [NotNull]
      string TypeName { get; }
   }

   public interface IPropertyGetter : IMember
   {
      [CanBeNull]
      object GetPropertyValue(Signature signature, [NotNull] ISignatureComparer signatureComparer);
   }

   public interface IPropertySetter : IMember
   {
      void SetPropertyValue([CanBeNull]object value, Signature signature, [NotNull] ISignatureComparer signatureComparer);
   }

   public interface IMethod : IMember
   {
      [CanBeNull]
      object InvokeMethod([NotNull]object[] arguments, Signature signature, [NotNull] ISignatureComparer signatureComparer);
   }
}
