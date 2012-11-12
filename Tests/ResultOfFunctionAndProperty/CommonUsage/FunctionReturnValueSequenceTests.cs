using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.ResultOfFunctionAndProperty.CommonUsage
{
   [TestFixture]
   public sealed class FunctionReturnValueSequenceTests : ReturnValueTestBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Fun: As.MethodResultSequence(value, default(T)));
      }
      // ReSharper restore RedundantArgumentName

      protected override int GetResult(IA t)
      {
         return t.Fun();
      }

      protected override Aa GetResult(IBa t)
      {
         return t.Fun();
      }

      protected override Ba GetResult(IBb t)
      {
         return t.Fun();
      }

      protected override int? GetResult(IC t)
      {
         return t.Fun();
      }
   }
}