using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDuck.Signatures
{
   public static class SignatureDifferencesPrinter
   {
      public static string PrintDifferences(this Signature expected, Signature actual)
      {
         return string.Format("Expected: {0}\r\nBut was: {1}", Render(expected), Render(actual));
      }

      private static string Render(Signature signature)
      {
         IEnumerable<string> parameters = signature.Parameters.Select(
            param =>
            {
               string prefix = param.IsRef ? "ref " : (param.IsOut ? "out " : "");
               Type type = param.Type.IsByRef ? param.Type.GetElementType() : param.Type;
               return prefix + GetTypeName(type);
            });

         return string.Format("{0} ({1})", signature.ReturnType.Name, string.Join(", ", parameters));
      }

      private static string GetTypeName(Type type)
      {
         return type.IsNullable() ? Nullable.GetUnderlyingType(type).Name + "?" : type.Name;
      }
   }
}
