using System;
using System.Linq;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using DelegateDuck.Signatures;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public sealed class AsMethodCaseWithActionTests
   {
      [Test]
      public void AsMethod_Action0()
      {
         int value = 0;
         Test(
            As.Method(
               () =>
               { value = -1; }),
            new object[] { });

         Assert.That(value, Is.EqualTo(-1));
      }

      [Test]
      public void AsMethod_Action1()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1) =>
                  { value = i1; }),
            new object[] { 1 });

         Assert.That(value, Is.EqualTo(1));
      }

      [Test]
      public void AsMethod_Action2()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2) => 
                  { value = i1 + i2; }),
            new object[] { 1, 2 });

         Assert.That(value, Is.EqualTo(3));
      }

      [Test]
      public void AsMethod_Action3()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3) =>
                  { value = i1 + i2 + i3; }),
            new object[] { 1, 2, 3 });

         Assert.That(value, Is.EqualTo(6));
      }

      [Test]
      public void AsMethod_Action4()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4) =>
                  { value = i1 + i2 + i3 + i4; }),
            new object[] { 1, 2, 3, 4 });

         Assert.That(value, Is.EqualTo(10));
      }

      [Test]
      public void AsMethod_Action5()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5) =>
                  { value = i1 + i2 + i3 + i4 + i5; }),
            new object[] { 1, 2, 3, 4, 5 });

         Assert.That(value, Is.EqualTo(15));
      }

      [Test]
      public void AsMethod_Action6()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6; }),
            new object[] { 1, 2, 3, 4, 5, 6 });

         Assert.That(value, Is.EqualTo(21));
      }

      [Test]
      public void AsMethod_Action7()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7 });

         Assert.That(value, Is.EqualTo(28));
      }

      [Test]
      public void AsMethod_Action8()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });

         Assert.That(value, Is.EqualTo(36));
      }

      [Test]
      public void AsMethod_Action9()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

         Assert.That(value, Is.EqualTo(45));
      }

      [Test]
      public void AsMethod_Action10()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

         Assert.That(value, Is.EqualTo(55));
      }

      [Test]
      public void AsMethod_Action11()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });

         Assert.That(value, Is.EqualTo(66));
      }

      [Test]
      public void AsMethod_Action12()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

         Assert.That(value, Is.EqualTo(78));
      }

      [Test]
      public void AsMethod_Action13()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });

         Assert.That(value, Is.EqualTo(91));
      }

      [Test]
      public void AsMethod_Action14()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });

         Assert.That(value, Is.EqualTo(105));
      }
      
      [Test]
      public void AsMethod_Action15()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int i15) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14 + i15; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });

         Assert.That(value, Is.EqualTo(120));
      }

      [Test]
      public void AsMethod_Action16()
      {
         int value = 0;
         Test(
            As.Method(
               (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int i15, int i16) =>
                  { value = i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8 + i9 + i10 + i11 + i12 + i13 + i14 + i15 + i16; }),
            new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

         Assert.That(value, Is.EqualTo(136));
      }

      private static void Test(IMethod method, object[] argumentValues)
      {
         var signature = new Signature(returnType: typeof(void),
            parameters: argumentValues.Select(
               arg =>
               new Parameter(type: arg.GetType())
               ).ToList());

         object result = method.InvokeMethod(argumentValues, signature, new SignatureComparerForStatic());

         Assert.That(result, Is.EqualTo(null));
      }
   }
}