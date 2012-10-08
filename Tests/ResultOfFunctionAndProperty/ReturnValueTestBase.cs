using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.ResultOfFunctionAndProperty
{
   [TestFixture]
   public abstract class ReturnValueTestBase
   {
      // ReSharper disable ExpressionIsAlwaysNull
      #pragma warning disable 168 // unused variable

      protected abstract dynamic MockValue<T>(T value);
      protected abstract int GetResult(IA t);
      protected abstract Aa GetResult(IBa t);
      protected abstract Ba GetResult(IBb t);
      protected abstract int? GetResult(IC t);

      //------------------------------------------------------------------------------

      [Test, Category(C.SAME_TYPE), Category(C.VALUE_TYPE), Category(C.CAN)]
      public void T01()
      {
         const int value = 77;
         IA t = MockValue(value);

         int result = GetResult(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T02()
      {
         const decimal value = 1m;
         IA t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int _ = GetResult(t); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T03()
      {
         const short value = 1;
         IA t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int _ = GetResult(t); });
      }

      [Test, Category(C.INPUT_NULL), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public virtual void T04()
      {
         const object value = null;
         IA t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int _ = GetResult(t); });
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T05()
      {
         var value = new Aa();
         IBa t = MockValue(value);

         Aa result = GetResult(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN)]
      public void T06()
      {
         var value = new Ba();
         IBb t = MockValue(value);

         Ba result = GetResult(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T07()
      {
         var value = new Ba();
         IBa t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { Aa _ = GetResult(t); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T08()
      {
         var value = new Aa();
         IBb t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { Ba _ = GetResult(t); });
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public virtual void T09()
      {
         object value = null;
         IBb t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { Ba _ = GetResult(t); });
      }
      
      [Test, Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN)]
      public virtual void T10()
      {
         int? value = 1;
         IC t = MockValue(value);

         int? result = GetResult(t);
         Assert.That(result, Is.EqualTo(value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN_NOT)]
      public void T11()
      {
         decimal? value = 1;
         IC t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = GetResult(t); });
      }

      [Test, Category(C.CONVERT_TO_HIGHER_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN_NOT)]
      public void T12()
      {
         short? value = 1;
         IC t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = GetResult(t); });
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN_NOT)]
      public virtual void T13()
      {
         object value = null;
         IC t = MockValue(value);

         Assert.Throws<SignatureDoNotMatchException>(() => { int? _ = GetResult(t); });
      }
      
      #pragma warning restore 168
      // ReSharper restore RedundantArgumentName
   }

   /*
    wiele testów okazało się nadmiarowych a kluczowe często zostały pominięta.
    tylko poświęcejąc czas na przyglądanie się kodu dla wąskiej grupy przypadków zauważyłem wiele prawidłowości
    gdybym poszedł drogą: najpierw wszystkie testy a potem ich dopieszczanie dołożyłbym sobie tyle roboty 
    że testy nigdy nie były by zrobione dobrze.
    
    Często logika jest nieubłagana i nia można robić żeczy które byśmy chcieli.
    */
}
