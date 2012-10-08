using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using DelegateDuck.Signatures;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public sealed class AsMethodCaseWithFuncTests
   {
      [Test]
      public void AsMethod_Func0()
      {
         const int value = -1;
         Test(
            As.Method(
               () => value),
            new object[] { },
            value);
      }

      [Test]
      public void AsMethod_Func1()
      {
         Test(
            As.Method(
               (int i1) =>
                  i1),
            new object[] { 1 },
            1);
      }

      [Test]
      public void AsMethod_Func2()
      {
         Test(
            As.Method(
               (int i1, int i2)
                  => i1 + i2),
            new object[] { 1, 2 },
            3);
      }

      [Test]
      public void AsMethod_Func3()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3)
                  => i1 + i2 + i3),
            new object[] { 1, 2, 3 },
            6);
      }

      [Test]
      public void AsMethod_Func4()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4)
                  => i1 + i2 + i3 + i4),
            new object[] { 1, 2, 3, 4 },
            10);
      }

      [Test]
      public void AsMethod_Func5()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5)
                  => i1 + i2 + i3 + i4 + i5),
            new object[] { 1, 2, 3, 4, 5 },
            15);
      }

      [Test]
      public void AsMethod_Func6()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6)
                  => i1 + i2 + i3 + i4 + i5 + i6),
            new object[] { 1, 2, 3, 4, 5, 6 },
            21);
      }

      [Test]
      public void AsMethod_Func7()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7),
            new object[] { 1, 2, 3, 4, 5, 6, 7 },
            28);
      }

      [Test]
      public void AsMethod_Func8()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8 },
            36);
      }

      [Test]
      public void AsMethod_Func9()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            45);
      }

      [Test]
      public void AsMethod_Func10()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            55);
      }

      [Test]
      public void AsMethod_Func11()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
            66);
      }

      [Test]
      public void AsMethod_Func12()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            78);
      }

      [Test]
      public void AsMethod_Func13()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            91);
      }

      [Test]
      public void AsMethod_Func14()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            105);
      }
      
      [Test]
      public void AsMethod_Func15()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int i15)
                  => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14 + i15),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
            120);
      }

      [Test]
      public void AsMethod_Func16()
      {
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int i15, int i16)
               => i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14 + i15 + i16),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            136);
      }

      private static void Test(IMethod method, object[] argumentValues, int value)
      {
         var signature = new Signature(returnType: typeof(Int32),
            parameters: argumentValues.Select(
               arg =>
               new Parameter(type: arg.GetType())
               ).ToList());

         object result = method.InvokeMethod(argumentValues, signature, new SignatureComparerForStatic());

         Assert.That(result, Is.EqualTo(value));
      }
   }
}
