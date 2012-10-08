using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet.CommonUsage
{
   [TestFixture]
   public sealed class UnrestrictedPropertyTests : PropertySetTestBase
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(Prop: value);
      }
      // ReSharper enable RedundantArgumentName

      protected override int SetAndGetResult(IA t, int value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override Aa SetAndGetResult(IBa t, Aa value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override Ba SetAndGetResult(IBb t, Ba value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override int? SetAndGetResult(IC t, int? value)
      {
         t.Prop = value;
         return t.Prop;
      }

      [Test]
      public override void T02()
      {
         Assert.Throws<CanNotRecognizeTypeException>(() => { IBa _ = MockValue((Aa)null); });
      }

      [Test]
      public override void T03()
      {
         Assert.Throws<CanNotRecognizeTypeException>(() => { IBa _ = MockValue((Ba)null); });
      }

      [Test]
      public override void T05()
      {
         Assert.Throws<CanNotRecognizeTypeException>(() => { IC _ = MockValue((int?)null); });
      }

      [Test]
      public override void T06()
      {
         int? value = null;
         IC t = MockValue((int?)1); // trap: ((int?)1 -> object) == int; ((int?)null -> object) == null

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = SetAndGetResult(t, value); });
      }
   }
}