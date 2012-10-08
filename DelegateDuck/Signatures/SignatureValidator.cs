using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using JetBrains.Annotations;

namespace DelegateDuck.Signatures
{
   public static class SignatureValidator
   {
      public static void ValidateSignature([NotNull] this ISignatureComparer signatureComparer, Signature expected, Signature actual)
      {
         if (signatureComparer.SignatureIsMatching(expected, actual) == false)
            throw new SignatureDoNotMatchException("Signature don't match. \r\n" + actual.PrintDifferences(expected));
      }

      public static void ValidateSignatureReturnType([NotNull] this ISignatureComparer signatureComparer, Signature expected, Signature actual)
      {
         if (signatureComparer.ReturnValueInSignatureIsMatching(expected, actual) == false)
            throw new SignatureDoNotMatchException("Signature return type don't match. \r\n" + actual.PrintDifferences(expected));
      }
   }
}
