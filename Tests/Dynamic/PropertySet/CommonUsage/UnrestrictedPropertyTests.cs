using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using NUnit.Framework;

namespace Tests.Dynamic.PropertySet.CommonUsage
{
   [TestFixture]
   public class UnrestrictedPropertyTests : SetValueTestBase
   {
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(
            Prop: value);
      }

      protected override TRet SetAndGetResult<TRet, TSet>(dynamic t, TSet value)
      {
         t.Prop = value;
         return t.Prop;
      }

      [Test]
      public override void T09()
      {
         object initial = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => MockValue(initial));
      }

      [Test]
      public override void T13()
      {
         int? initial = 1; // int? -> object -> int
         short? value = null;
         dynamic t = MockValue(initial);

         Assert.Throws<SignatureDoNotMatchException>(() => SetAndGetResult<int?, short?>(t, value));
      }

      [Test]
      public override void T14()
      {
         int? initial = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => MockValue(initial));
      }

      [Test]
      public override void T15()
      {
         object initial = null;
         Assert.Throws<CanNotRecognizeTypeException>(() => MockValue(initial));
      }
   }
}