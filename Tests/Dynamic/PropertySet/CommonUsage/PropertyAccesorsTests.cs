using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.Dynamic.PropertySet.CommonUsage
{
   [TestFixture]
   public class PropertyAccesorsTests : SetValueTestBase
   {
      protected override dynamic MockValue<T>(T value)
      {
         T temp = default(T);
         return Duck.New(
            Prop: As.PropertyGet(() => temp).Set(setterValue => temp = setterValue));
      }

      protected override TRet SetAndGetResult<TRet, TSet>(dynamic t, TSet value)
      {
         t.Prop = value;
         return t.Prop;
      }
   }
}