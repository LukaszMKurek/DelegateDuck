using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet.CommonUsage
{
   [TestFixture]
   public sealed class PropertyAccesorsCaseWhereSetterFirstThenGetterTests : PropertySetTestBase // parametryczny zrobiæ
   {
      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         object val = 0f;

         return Duck.New(Prop: As.PropertySet((T t) => val = t).Get(() => (T)val));
      }
      // ReSharper enable RedundantArgumentName

      protected override int SetAndGetResult(IA t, int value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override Aa SetAndGetResult(IBa t, Aa value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override Ba SetAndGetResult(IBb t, Ba value)
      {
         t.Prop = value;
         return t.Prop;
      }

      protected override int? SetAndGetResult(IC t, int? value)
      {
         t.Prop = value;
         return t.Prop;
      }
   }
}