using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace DelegateDuck.Signatures
{
   public static class SignatureBuilderForStatic
   {
      public static Signature BuildGetter([NotNull] Type returnType)
      {
         return new Signature(returnType: returnType);
      }

      public static Signature BuildSetter([NotNull] Type valueType)
      {
         return new Signature(
            returnType: typeof(void),
            parameters: new List<Parameter>
            {
               new Parameter(type: valueType)
            });
      }

      public static Signature BuildMethod([NotNull] MethodInfo method)
      {
         IEnumerable<Parameter> parameters =
            from param in method.GetParameters()
            select new Parameter(
               type: param.ParameterType, // todo no nie wiem co bêdzie w dynamic
               isRef: param.ParameterType.IsByRef && param.IsOut == false,
               isOut: param.IsOut); // any gwarance that his flag will be corectly set

         var signature = new Signature(
            returnType: method.ReturnType,
            parameters: parameters);

         return signature;
      }
   }
}
