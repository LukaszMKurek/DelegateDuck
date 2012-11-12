using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.CodeSamples
{
   public interface ISample
   {
      int SampleMethod(int p);
      int SampleProperty { get; set; }
   }

   [TestFixture]
   public sealed class Sample01
   {
      [Test]
      public void T01()
      {
         ISample sample = Duck.New(
            SampleMethod: As.Method(
               (int p) => p * 5
               ));

         Assert.That(sample.SampleMethod(7), Is.EqualTo(7 * 5));
      }

      [Test]
      public void T02()
      {
         ISample sample = Duck.New(
            SampleProperty: 55);

         Assert.That(sample.SampleProperty, Is.EqualTo(55));
      }

      [Test]
      public void T03()
      {
         ISample sample = Duck.New(
            SampleProperty: 55);

         sample.SampleProperty = 77;

         Assert.That(sample.SampleProperty, Is.EqualTo(77));
      }

      [Test]
      public void T04()
      {
         int temp = 55;
         ISample sample = Duck.New(
            SampleProperty: As.Setter((int i) => temp = i)
                              .Getter(() => temp));

         Assert.That(sample.SampleProperty, Is.EqualTo(55));

         sample.SampleProperty = 77;
         Assert.That(sample.SampleProperty, Is.EqualTo(77));
      }

      [Test]
      public void T05()
      {
         ISample sample = Duck.New(
            SampleProperty: As.PropertyValue(55),
            SampleMethod: As.MethodResult(33));

         Assert.That(sample.SampleProperty, Is.EqualTo(55));

         Assert.That(sample.SampleMethod(0), Is.EqualTo(33));
      }

      [Test]
      public void T06()
      {
         ISample sample = Duck.New(
            SampleProperty: As.PropertyValueSequence(55, 66),
            SampleMethod: As.MethodResultSequence(33, 22));

         Assert.That(sample.SampleProperty, Is.EqualTo(55));
         Assert.That(sample.SampleProperty, Is.EqualTo(66));

         Assert.That(sample.SampleMethod(0), Is.EqualTo(33));
         Assert.That(sample.SampleMethod(0), Is.EqualTo(22));
      }
   }
}