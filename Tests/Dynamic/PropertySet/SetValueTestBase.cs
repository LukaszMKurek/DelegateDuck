using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.Dynamic.PropertySet
{
   [TestFixture]
   public abstract class SetValueTestBase
   {
      // ReSharper disable ExpressionIsAlwaysNull
      #pragma warning disable 168 // unused variable

      protected abstract dynamic MockValue<T>(T value);
      protected abstract TRet SetAndGetResult<TRet, TSet>(dynamic t, TSet value);

      //------------------------------------------------------------------------------

      [Test, Category(C.SAME_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T01()
      {
         const int initial = 0;
         const int value = 1;
         dynamic t = MockValue(initial);

         int result = SetAndGetResult<int, int>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T02()
      {
         const int initial = 0;
         const decimal value = 1m;
         dynamic t = MockValue(initial);

         Assert.Throws<SignatureDoNotMatchException>(() => { int _ = SetAndGetResult<int, decimal>(t, value); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T03()
      {
         const int initial = 1;
         const short value = 1;
         dynamic t = MockValue(initial);

         int result = SetAndGetResult<int, short>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T04()
      {
         const int initial = 1;
         const object value = null;
         dynamic t = MockValue(initial);

         Assert.Throws<SignatureDoNotMatchException>(() => { int _ = SetAndGetResult<int, object>(t, value); });
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T05()
      {
         var initial = new Aa();
         var value = new Aa();
         dynamic t = MockValue(initial);

         Aa result = SetAndGetResult<Aa, Aa>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T06()
      {
         var initial = new Ba();
         var value = new Ba();
         dynamic t = MockValue(initial);

         Ba result = SetAndGetResult<Ba, Ba>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T07()
      {
         var initial = new Aa();
         var value = new Ba();
         dynamic t = MockValue(initial);

         Aa result = SetAndGetResult<Aa, Ba>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T08()
      {
         var initial = new Ba();
         var value = new Aa();
         dynamic t = MockValue(initial);

         Assert.Throws<SignatureDoNotMatchException>(() => { Ba _ = SetAndGetResult<Ba, Aa>(t, value); });
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public virtual void T09()
      {
         object initial = null;
         Ba value = null;
         dynamic t = MockValue(initial);

         object result = SetAndGetResult<object, Ba>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }
      
      [Test, Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T10()
      {
         int? initial = 1;
         int? value = 1;
         dynamic t = MockValue(initial);

         int? result = SetAndGetResult<int?, int?>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T11()
      {
         int? initial = 1;
         decimal? value = 1;
         dynamic t = MockValue(initial);

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = SetAndGetResult<int?, decimal?>(t, value); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T12()
      {
         int? initial = 1;
         short? value = 1;
         dynamic t = MockValue(initial);

         int? result = SetAndGetResult<int?, short?>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T13()
      {
         int? initial = 1;
         short? value = null;
         dynamic t = MockValue(initial);

         int? result = SetAndGetResult<int?, short?>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T14()
      {
         object initial = null;
         int? value = 1;
         dynamic t = MockValue(initial);

         object result = SetAndGetResult<object, int?>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T15()
      {
         object initial = null;
         int? value = null;
         dynamic t = MockValue(initial);

         object result = SetAndGetResult<object, int?>(t, value);
         Assert.That(result, Is.EqualTo(value));
      }
      
      #pragma warning restore 168
      // ReSharper restore RedundantArgumentName
   }
}
