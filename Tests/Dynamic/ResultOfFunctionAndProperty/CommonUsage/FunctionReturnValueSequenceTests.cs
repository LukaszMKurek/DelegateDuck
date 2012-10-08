using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.Dynamic.ResultOfFunctionAndProperty.CommonUsage
{
   [TestFixture]
   public sealed class FunctionReturnValueSequenceTests : ReturnValueTestBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Fun: new[] { value, default(T) }.MethodResultSequence());
      }
      // ReSharper restore RedundantArgumentName

      protected override TRet GetResult<TRet>(dynamic t)
      {
         return t.Fun();
      }
   }
}