using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.Dynamic.PropertySet.CommonUsage
{
   [TestFixture]
   public class PropertyValueTests : SetValueTestBase
   {
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Prop: As.PropertyValue(value));
      }

      protected override TRet SetAndGetResult<TRet, TSet>(dynamic t, TSet value)
      {
         t.Prop = value;
         return t.Prop;
      }
   }
}
