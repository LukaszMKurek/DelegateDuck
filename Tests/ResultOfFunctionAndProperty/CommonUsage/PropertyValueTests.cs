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
   public sealed class PropertyValueTests : ReturnValueTestBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Prop: As.PropertyValue(value));
      }
      // ReSharper restore RedundantArgumentName

      protected override int GetResult(IA t)
      {
         return t.Prop;
      }

      protected override Aa GetResult(IBa t)
      {
         return t.Prop;
      }

      protected override Ba GetResult(IBb t)
      {
         return t.Prop;
      }

      protected override int? GetResult(IC t)
      {
         return t.Prop;
      }
   }
}