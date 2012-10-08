using System.Linq;
using System.Collections.Generic;
using System;

namespace DelegateDuck.Signatures
{
   public static class SignatureBuilderForDynamic
   {
      public static Signature BuildGetter(Type returnType)
      {
         return new Signature(returnType: returnType);
      }

      public static Signature BuildSetter(object value)
      {
         var parameter = BuildParameter(value);
         return new Signature(returnType: typeof(void), parameters: new[] { parameter });
      }

      public static Signature BuildMethod(Type returnType, IEnumerable<object> arguments)
      {
         return new Signature(returnType: returnType, parameters: BuildParameters(arguments));
      }

      private static Parameter BuildParameter(object argument)
      {
         var type = argument == null ? typeof(void) : argument.GetType();
         return new Parameter(type: type);
      }

      private static IEnumerable<Parameter> BuildParameters(IEnumerable<object> arguments)
      {
         return arguments.Select(BuildParameter);
      }
   }
}