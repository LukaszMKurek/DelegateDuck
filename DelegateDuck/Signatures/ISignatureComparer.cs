using System.Linq;
using System.Collections.Generic;
using System;

namespace DelegateDuck.Signatures
{
   public interface ISignatureComparer
   {
      bool SignatureIsMatching(Signature outer, Signature inner);
      bool ReturnValueInSignatureIsMatching(Signature outer, Signature inner);
   }
}