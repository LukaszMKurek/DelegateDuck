using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;

namespace DelegateDuck.Signatures
{
   public struct Signature
   {
      private readonly Type _returnType;
      private readonly ReadOnlyCollection<Parameter> _parameters;

      public Signature([NotNull] Type returnType, [NotNull] IEnumerable<Parameter> parameters = null)
      {
         _returnType = returnType;
         _parameters = (parameters == null ? new List<Parameter>() : parameters.ToList()).AsReadOnly();
      }

      public Type ReturnType
      {
         get { return _returnType ?? typeof(void); }
      }

      public ReadOnlyCollection<Parameter> Parameters
      {
         get { return _parameters ?? new List<Parameter>().AsReadOnly(); }
      }
   }
}
