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
               (int p) => 5
               ));

         Assert.That(sample.SampleMethod(-1), Is.EqualTo(5));
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
   }
}