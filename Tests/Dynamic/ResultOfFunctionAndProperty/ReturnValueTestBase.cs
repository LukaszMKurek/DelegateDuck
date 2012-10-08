using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.Dynamic.ResultOfFunctionAndProperty
{
   [TestFixture]
   public abstract class ReturnValueTestBase
   {
      // ReSharper disable ExpressionIsAlwaysNull
      #pragma warning disable 168 // unused variable

      protected abstract dynamic MockValue<T>(T value);
      protected abstract TRet GetResult<TRet>(dynamic t);

      //------------------------------------------------------------------------------

      [Test, Category(C.SAME_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T01()
      {
         const int value = 77;
         dynamic t = MockValue(value);

         int result = GetResult<int>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T02()
      {
         const decimal value = 1m;
         dynamic t = MockValue(value);

         Assert.Throws<RuntimeBinderException>(() => { int _ = GetResult<int>(t); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T03()
      {
         const short value = 1;
         dynamic t = MockValue(value);

         int result = GetResult<int>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public virtual void T04()
      {
         const object value = null;
         dynamic t = MockValue(value);

         Assert.Throws<RuntimeBinderException>(() => { int _ = GetResult<int>(t); });
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T05()
      {
         var value = new Aa();
         dynamic t = MockValue(value);

         Aa result = GetResult<Aa>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T06()
      {
         var value = new Ba();
         dynamic t = MockValue(value);

         Ba result = GetResult<Ba>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T07()
      {
         var value = new Ba();
         dynamic t = MockValue(value);

         Aa result = GetResult<Aa>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T08()
      {
         var value = new Aa();
         dynamic t = MockValue(value);

         Assert.Throws<RuntimeBinderException>(() => { Ba _ = GetResult<Ba>(t); });
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public virtual void T09()
      {
         object value = null;
         dynamic t = MockValue(value);

         Ba result = GetResult<Ba>(t);
         Assert.That(result, Is.EqualTo(value));
      }
      
      [Test, Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T10()
      {
         int? value = 1;
         dynamic t = MockValue(value);

         int? result = GetResult<int?>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T11()
      {
         decimal? value = 1;
         dynamic t = MockValue(value);

         Assert.Throws<RuntimeBinderException>(() => { int? _ = GetResult<int?>(t); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public void T12()
      {
         short? value = 1;
         dynamic t = MockValue(value);

         int? result = GetResult<int?>(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T13()
      {
         object value = null;
         dynamic t = MockValue(value);

         int? result = GetResult<int?>(t);
         Assert.That(result, Is.EqualTo(value));
      }
      
      #pragma warning restore 168
      // ReSharper restore RedundantArgumentName
   }
}
