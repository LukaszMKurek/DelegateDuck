using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.ResultOfFunctionAndProperty.CommonUsage
{
   [TestFixture]
   public sealed class UnrestrictedPropertyTests : ReturnValueTestBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Prop: value);
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

      [Test]
      public override void T04()
      {
         const object value = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => { IA _ = MockValue(value); });
      }

      [Test]
      public override void T09()
      {
         const object value = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => { IBb _ = MockValue(value); });
      }

      [Test]
      public override void T10()
      {
         int? value = 1;
         IC t = MockValue(value); // trap: ((int?)1 -> object) == int; ((int?)null -> object) == null

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = GetResult(t); });
      }

      [Test]
      public override void T13()
      {
         const object value = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => { IC _ = MockValue(value); });
      }
   }
}
