using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Signatures;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public sealed class DelegateExtensionsTests
   {
      [TestCase(typeof(int), (short)1, (short)1)]
      [TestCase(typeof(int), 2, 2)]
      [TestCase(typeof(int), 2f, 2f)]
      [TestCase(typeof(int), null, null)]
      [TestCase(typeof(int), "a", "a")]
      [TestCase(typeof(int?), (short)1, 1)]
      [TestCase(typeof(int?), 2, 2)]
      [TestCase(typeof(int?), 2f, 2f)]
      [TestCase(typeof(int?), null, null)]
      [TestCase(typeof(int?), "a", "a")]
      [TestCase(typeof(long?), 1, 1L)]
      public void a1(Type type, object value, object expected)
      {
         object result = DelegateExtensions.ConvertForNullableCompatibility(type, value);

         Assert.That(result, Is.EqualTo(expected));
         if (result != null)
            Assert.That(result.GetType(), Is.EqualTo(expected.GetType()));
      }

      [TestCase(typeof(int), (short)1, (short)1)]
      [TestCase(typeof(int), 2, 2)]
      [TestCase(typeof(int), 2f, 2f)]
      [TestCase(typeof(int), null, null)]
      [TestCase(typeof(int), "a", "a")]
      [TestCase(typeof(int?), (short)1, 1)]
      [TestCase(typeof(int?), 2, 2)]
      [TestCase(typeof(int?), 2f, 2f)]
      [TestCase(typeof(int?), null, null)]
      [TestCase(typeof(int?), "a", "a")]
      [TestCase(typeof(long?), 1, 1L)]
      public void a11(Type type, object value, object expected)
      {
         a1(type.MakeByRefType(), value, expected);
      }

      [Test]
      public void a2([Values(1, null, (short)2)] int value)
      {
         Func<int?, int?> a = i => i;

         var result = (int?)a.DynamicInvokeWithFixProblemWithNullable(value);

         Assert.That(result, Is.EqualTo(value));
      }
   }
}