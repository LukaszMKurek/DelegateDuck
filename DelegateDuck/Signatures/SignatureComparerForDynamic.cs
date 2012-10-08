using System.Linq;
using System.Collections.Generic;
using System;

namespace DelegateDuck.Signatures
{
   public sealed class SignatureComparerForDynamic : ISignatureComparer
   {
      public bool SignatureIsMatching(Signature outer, Signature inner) // todo parametru domyœlne trzeba uwzlêdniæ
      {
         if (ReturnTypeIsMatching(outer.ReturnType, inner.ReturnType) == false)
            return false;

         if (outer.Parameters.Count != inner.Parameters.Count)
            return false;

         for (int i = 0; i < inner.Parameters.Count; i++)
         {
            var outerParameter = outer.Parameters[i];
            var innerParameter = inner.Parameters[i];

            if (ParameterIsAssignable(outerParameter.Type, innerParameter.Type) == false)
               return false;
         }

         return true;
      }

      private static bool ParameterIsAssignable(Type outerType, Type innerType)
      {
         if (outerType == typeof(void))
            return innerType.IsAssignableByNull();

         Type assignedType = innerType.IsByRef ? innerType.GetElementType() : innerType;

         if (assignedType.IsAssignableFrom(outerType))
            return true;

         assignedType = assignedType.IsNullable() ? assignedType.GetGenericArguments()[0] : assignedType;

         if (outerType.IsNumericTypeAndCanBeConvertTo(assignedType))
            return true;

         return false;
      }

      public bool ReturnValueInSignatureIsMatching(Signature outer, Signature inner)
      {
         return ReturnTypeIsMatching(outer.ReturnType, inner.ReturnType);
      }

      private static bool ReturnTypeIsMatching(Type returnType, Type type)
      {
         return returnType.IsAssignableFrom(type); //todo always true, object isAssignable with everythink
      }
   }
}