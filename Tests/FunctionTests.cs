using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using DelegateDuck.Signatures;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests
{
   [TestFixture]
   public sealed class FunctionTests
   {
      [Test]
      public void T01()
      {
         IA t = Duck.New(
            Fun: new Func<int>(() => 55));

         Assert.Throws<ImproperMemberTypeException>(() => t.Fun());
      }

      [Test]
      public void T02()
      {
         IA t = Duck.New(
            Fun: new Func<int>(() => 55));

         Assert.Throws<ImproperMemberTypeException>(() => t.Fun(0));
      }

      [Test]
      public void T03()
      {
         IA t = Duck.New(
            Fun: new object());

         Assert.Throws<ImproperMemberTypeException>(() => t.Fun());
      }

      [Test]
      public void T04()
      {
         Assert.Throws<CanNotRecognizeTypeException>(() => { IA _ = Duck.New(Fun: null); });
      }

      public delegate int Del1(int a, ref short b, out long c, string d);

      public interface IDel1
      {
         int Fun1(int a, ref short b, out long c, string d);
      }

      [Test]
      public void T05()
      {
         var del = new Del1((int a, ref short b, out long c, string d) =>
         {
            Assert.That(b, Is.EqualTo(-1));
            Assert.That(d, Is.Null);
            b = 1;
            c = 2;
            return 3;
         });
         IDel1 t = Duck.New(
            Fun1: As.Method(del));

         short ba = -1;
         long ca;
         var res = t.Fun1(0, ref ba, out ca, null);

         Assert.That(res, Is.EqualTo(3));
         Assert.That(ba, Is.EqualTo(1));
         Assert.That(ca, Is.EqualTo(2));
      }

      [Test]
      public void T06()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int?).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(decimal),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(int?).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int?)),
               new Parameter(type: typeof(DateTime?))
            });

         string result = SignatureDifferencesPrinter.PrintDifferences(s1, s2);

         Assert.That(
            result, Is.EqualTo(
               @"Expected: Int32 (ref String, out Int32?, Int16, Decimal)" + "\r\n" +
               @"But was: Decimal (out String, ref Int32?, Int32?, DateTime?)"));
      }

      [Test]
      public void T07()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.True);
      }

      [Test]
      public void T08()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(short),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.False);
      }

      [Test]
      public void T09()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string)),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.False);
      }

      [Test]
      public void T11()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int)),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.False);
      }

      [Test]
      public void T12()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(int)),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.False);
      }

      [Test]
      public void T13()
      {
         var s1 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });
         var s2 = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(decimal))
            });

         bool matching = new SignatureComparerForStatic().SignatureIsMatching(s1, s2);

         Assert.That(matching, Is.False);
      }

      private delegate int Sig(ref string p1, out int p2, short p3, decimal p4); 

      [Test]
      public void T14()
      {
         var signature = new Sig((ref string p1, out int p2, short p3, decimal p4) => { p2 = 1; return 0; });

         var expectedSigniature = new Signature(
            returnType: typeof(int),
            parameters: new[]
            {
               new Parameter(type: typeof(string).MakeByRefType(), isRef: true),
               new Parameter(type: typeof(int).MakeByRefType(), isOut: true),
               new Parameter(type: typeof(short)),
               new Parameter(type: typeof(decimal))
            });

         Signature buildSignature = SignatureBuilderForStatic.BuildMethod(signature.Method);

         bool areEqual = new SignatureComparerForStatic().SignatureIsMatching(expectedSigniature, buildSignature);
         Assert.That(areEqual);
      }
   }
}
