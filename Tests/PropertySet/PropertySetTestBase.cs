using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet
{
   [TestFixture]
   public abstract class PropertySetTestBase
   {
      // ReSharper disable ExpressionIsAlwaysNull
      #pragma warning disable 168 // unused variable

      protected abstract dynamic MockValue<T>(T value);
      protected abstract int SetAndGetResult(IA t, int value);
      protected abstract Aa SetAndGetResult(IBa t, Aa value);
      protected abstract Ba SetAndGetResult(IBb t, Ba value);
      protected abstract int? SetAndGetResult(IC t, int? value);

      //------------------------------------------------------------------------------

      [Test, Category(C.SAME_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T01()
      {
         const int value = 77;
         IA t = MockValue(0);

         int result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }
      
      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public virtual void T02()
      {
         var value = new Aa();
         IBa t = MockValue((Aa)null);

         Aa result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public virtual void T03()
      {
         var value = new Ba();
         IBa t = MockValue((Ba)null);

         Assert.Throws<SignatureDoNotMatchException>(() => { Aa result = SetAndGetResult(t, value); });
      }
      
      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T04()
      {
         Ba value = null;
         IBb t = MockValue(new Ba());

         Ba result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }
      
      [Test, Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T05()
      {
         int? value = 1;
         IC t = MockValue((int?)null);

         int? result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T06()
      {
         int? value = null;
         IC t = MockValue((int?)1);

         int? result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }
      // todo zastanowić się czy wszystkie testy są zrobione
      /*[Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T12()
      {
         int? initial = 1;
         int? value = 1;
         IC t = MockValue(initial);

         int? result = SetAndGetResult(t, value);
         Assert.That(result, Is.EqualTo(value));
      }*/

      #pragma warning restore 168
      // ReSharper restore RedundantArgumentName
   }
}
