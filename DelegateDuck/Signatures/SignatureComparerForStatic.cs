using System.Linq;
using System.Collections.Generic;
using System;

namespace DelegateDuck.Signatures
{
   public sealed class SignatureComparerForStatic : ISignatureComparer
   {
      public bool SignatureIsMatching(Signature outer, Signature inner)
      {
         if (outer.ReturnType != inner.ReturnType)
            return false;

         return outer.Parameters.SequenceEqual(inner.Parameters);
      }

      public bool ReturnValueInSignatureIsMatching(Signature outer, Signature inner)
      {
         return outer.ReturnType == inner.ReturnType;
      }
   }
}