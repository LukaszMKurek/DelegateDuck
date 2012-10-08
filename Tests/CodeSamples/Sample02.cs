using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;

namespace Tests.CodeSamples
{
   [TestFixture]
   public sealed class Sample02
   {
      [Test]
      public void T01()
      {
         dynamic sample = Duck.New(
            SampleMethod: As.Method(
               (int p) => p*5
               ));

         Assert.That(sample.SampleMethod(7), Is.EqualTo(7*5));
      }

      [Test]
      public void T02()
      {
         dynamic sample = Duck.New(
            SampleProperty: 55);

         Assert.That(sample.SampleProperty, Is.EqualTo(55));
      }

      [Test]
      public void T03()
      {
         dynamic sample = Duck.New(
            SampleProperty: 55);

         sample.SampleProperty = 77;

         Assert.That(sample.SampleProperty, Is.EqualTo(77));
      }
   }
}