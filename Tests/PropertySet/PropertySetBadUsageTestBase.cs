using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet
{
   // wszystkie teesty przechodz¹ bo kompilator w czasie kompilacji gwarantuje poprawnoœæ. Realizuje tak¿e int16 > int32
   [TestFixture]
   public abstract class PropertySetTestBadUsageBase
   {
      // ReSharper disable ExpressionIsAlwaysNull
#pragma warning disable 168 // unused variable

      protected abstract dynamic MockValue<T>(T value);
      protected abstract void TrySet(IA t, int value);
      protected abstract void TrySet(IBa t, Aa value);
      protected abstract void TrySet(IBb t, Ba value);
      protected abstract void TrySet(IC t, int? value);

      //------------------------------------------------------------------------------

      [Test, Category(C.SAME_TYPE), Category(C.VALUE_TYPE), Category(C.CAN_NOT)]
      public void T01()
      {
         const int value = 77;
         IA t = MockValue(0);

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

      [Test, Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T02()
      {
         var value = new Aa();
         IBa t = MockValue((Aa)null);

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

      [Test, Category(C.CONVERT_TO_LOWER_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T03()
      {
         var value = new Ba();
         IBa t = MockValue((Ba)null);

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.REFERENCE_TYPE), Category(C.CAN_NOT)]
      public void T04()
      {
         Ba value = null;
         IBb t = MockValue(new Ba());

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

      [Test, Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN_NOT)]
      public void T05()
      {
         int? value = 1;
         IC t = MockValue((int?)null);

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

      [Test, Category(C.INPUT_NULL), Category(C.SAME_TYPE), Category(C.NULLABLE_TYPE), Category(C.CAN_NOT)]
      public void T06()
      {
         int? value = null;
         IC t = MockValue((int?)1);

         Assert.Throws<ImproperMemberTypeException>(() => TrySet(t, value));
      }

#pragma warning restore 168
      // ReSharper restore RedundantArgumentName
   }
}
