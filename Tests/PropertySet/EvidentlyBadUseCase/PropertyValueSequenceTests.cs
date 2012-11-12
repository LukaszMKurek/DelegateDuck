using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet.EvidentlyBadUseCase
{
   [TestFixture]
   public sealed class PropertyValueSequenceTests : PropertySetTestBadUsageBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Prop: As.PropertyValueSequence(value, default(T)));
      }
      // ReSharper enable RedundantArgumentName

      protected override void TrySet(IA t, int value)
      {
         t.Prop = value;
      }

      protected override void TrySet(IBa t, Aa value)
      {
         t.Prop = value;
      }

      protected override void TrySet(IBb t, Ba value)
      {
         t.Prop = value;
      }

      protected override void TrySet(IC t, int? value)
      {
         t.Prop = value;
      }
   }
}