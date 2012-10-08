using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DelegateDuck.Signatures
{
   public static class DelegateExtensions
   {
      public static object DynamicInvokeWithFixProblemWithNullable(this Delegate @delegate, params object[] arguments)
      {
         ParameterInfo[] parameterInfos = @delegate.Method.GetParameters();
         object[] fixedArguments = arguments.Select(
            (arg, i) => ConvertForNullableCompatibility(parameterInfos[i].ParameterType, arg)
            ).ToArray();

         object returnValue = @delegate.DynamicInvoke(fixedArguments);

         for (int i = 0; i < arguments.Length; i++)
            arguments[i] = fixedArguments[i]; // for ref/out arguments working

         return returnValue;
      }

      public static object ConvertForNullableCompatibility(Type type, object value)
      {
         if (value is IConvertible == false)
            return value;

         if (type.IsByRef)
            type = type.GetElementType(); // todo

         Type u = Nullable.GetUnderlyingType(type);
         if (u == null || u == value.GetType())
            return value;

         if (value.GetType().IsNumericTypeAndCanBeConvertTo(u) == false)
            return value;

         return Convert.ChangeType(value, u);
      }
   }
}
