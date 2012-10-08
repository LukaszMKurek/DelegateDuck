using DelegateDuck.Implementation;
using DelegateDuck.MockHelpers;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests.PropertySet.CommonUsage
{
   [TestFixture]
   public sealed class PropertyAccesorsCaseWhereOnlySetterTests : PropertySetTestBase // parametryczny zrobiæ
   {
      private object _value;

      // ReSharper disable RedundantArgumentName
      protected override dynamic MockValue<T>(T value)
      {
         return Duck.New(Prop: As.PropertySet((T t) => _value = t)); // domkniêciem membera wyeliminowaæ
      }
      // ReSharper enable RedundantArgumentName

      protected override int SetAndGetResult(IA t, int value)
      {
         t.Prop = value;
         return (int)_value;
      }

      protected override Aa SetAndGetResult(IBa t, Aa value)
      {
         t.Prop = value;
         return (Aa)_value;
      }

      protected override Ba SetAndGetResult(IBb t, Ba value)
      {
         t.Prop = value;
         return (Ba)_value;
      }

      protected override int? SetAndGetResult(IC t, int? value)
      {
         t.Prop = value;
         return (int?)_value;
      }
   }
}