using System.Linq;
using System.Collections.Generic;
using System;

namespace DelegateDuck.Signatures
{
   public static class TypeExtensions
   {
      public static bool IsAssignableByNull(this Type @this)
      {
         if (@this.IsValueType && @this.IsNullable() == false)
            return false;

         return true;
      }

      public static bool IsNullable(this Type @this)
      {
         return Nullable.GetUnderlyingType(@this) != null;
      }

      public static bool IsNumericTypeAndCanBeConvertTo(this Type @this, Type type)
      {
         HashSet<Type> validSourceTypes;
         if (s_impliciteConvertingTypes.TryGetValue(type, out validSourceTypes) == false)
            return false;

         return validSourceTypes.Contains(@this);
      }

      private static readonly HashSet<Type> s_0 = new HashSet<Type>();
      private static readonly HashSet<Type> s_1 = new HashSet<Type>(s_0) { typeof(Byte), typeof(SByte) };
      private static readonly HashSet<Type> s_2 = new HashSet<Type>(s_1) { typeof(Char) };
      private static readonly HashSet<Type> s_3 = new HashSet<Type>(s_2) { typeof(Int16), typeof(UInt16) };
      private static readonly HashSet<Type> s_4 = new HashSet<Type>(s_3) { typeof(Int32), typeof(UInt32) };
      private static readonly HashSet<Type> s_5 = new HashSet<Type>(s_4) { typeof(Int64), typeof(UInt64) };
      private static readonly HashSet<Type> s_6 = new HashSet<Type>(s_5) { typeof(Double) };

      private static readonly Dictionary<Type, HashSet<Type>> s_impliciteConvertingTypes = new Dictionary<Type, HashSet<Type>>
      {
         { typeof(Byte), s_0 },
         { typeof(SByte), s_0 },
         { typeof(Char), s_0 },
         { typeof(Int16), s_1 },
         { typeof(UInt16), s_2 },
         { typeof(Int32), s_3 },
         { typeof(UInt32), s_3 },
         { typeof(Int64), s_4 },
         { typeof(UInt64), s_4 },
         { typeof(Decimal), s_5 },
         { typeof(Single), s_5 },
         { typeof(Double), s_6 },
      };
   }
}