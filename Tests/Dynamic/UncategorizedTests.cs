using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.Dynamic
{
   [TestFixture]
   public sealed class UncategorizedTests
   {
      [Test]
      public void T01()
      {
         var obj = Duck.New(
            Property: As.PropertyValue(new Func<int, int>(i => i * 5)));

         int result = obj.Property(5);

         Assert.That(result, Is.EqualTo(25));
      }

      [Test]
      public void T02()
      {
         var obj = Duck.New(
            Property: As.PropertyValue(new Func<int, int>(i => i * 5)));

         Func<int, int> func = obj.Property;

         Assert.That(func(5), Is.EqualTo(25));
      }

      private delegate int Sig(ref string p1, out int p2, short p3, decimal p4); 

      [Test]
      public void T03()
      {
         var obj = Duck.New(
            Func: As.Method(new Sig((ref string p1, out int p2, short p3, decimal p4) =>
            {
               p1 = "10"; p2 = 20; return 30; 
            })));

         string a1 = "0";
         int a2;
         short a3 = 8;

         int result = obj.Func(ref a1, out a2, a3, 9m);

         Assert.That(result, Is.EqualTo(30));
         Assert.That(a1, Is.EqualTo("10"));
         Assert.That(a2, Is.EqualTo(20));
      }

      private delegate int Sig1(ref int? p1, out int p2, short p3, decimal p4);

      [Test]
      public void T04()
      {
         var obj = Duck.New(
            Func: As.Method(new Sig1((ref int? p1, out int p2, short p3, decimal p4) =>
            {
               p1 = 10; p2 = 20; return 30;
            })));

         int? a1 = 0;
         int a2;
         short a3 = 8;

         int result = obj.Func(ref a1, out a2, a3, 9m);

         Assert.That(result, Is.EqualTo(30));
         Assert.That(a1, Is.EqualTo(10));
         Assert.That(a2, Is.EqualTo(20));
      }

      [Test]
      public void T05()
      {
         var obj = Duck.New(
            Func: As.Method(new Sig1((ref int? p1, out int p2, short p3, decimal p4) =>
            {
               p1 = 10; p2 = 20; return 30;
            })));

         int? a1 = null;
         int a2;
         short a3 = 8;

         int result = obj.Func(ref a1, out a2, a3, 9m);

         Assert.That(result, Is.EqualTo(30));
         Assert.That(a1, Is.EqualTo(10));
         Assert.That(a2, Is.EqualTo(20));
      }

      /*[Test]
      public void T03()
      {
         var obj = Duck.New(
            Func: As.Method((int i) => i * 5));

         Func<int, int> func = obj.Func; // todo can't do this

         Assert.That(func(5), Is.EqualTo(25));
      }

      [Test]
      public void T04()
      {
         var obj = Duck.New(
            Func: As.Method((int i) => i * 5));

         var func = new Func<int, int>(obj.Func); // todo can't do this

         Assert.That(func(5), Is.EqualTo(25));
      }*/
   }
}
