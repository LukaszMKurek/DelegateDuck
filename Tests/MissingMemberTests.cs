using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using NUnit.Framework;
using Tests.ForTest;

namespace Tests
{
   [TestFixture]
   public sealed class MissingMemberTests
   {
#pragma warning disable 168 // unused variable

      [Test]
      public void MissingProperty_T01()
      {
         IA t = Duck.New;

         Assert.Throws<MemberMissingException>(() => { int _ = t.Prop; });
      }

      [Test]
      public void MissingProperty_T02()
      {
         IA t = Duck.New;

         Assert.Throws<MemberMissingException>(() => { t.Prop = 1; });
      }

      [Test]
      public void MissingProperty_T03()
      {
         IA t = Duck.New(Prop1: 0);

         Assert.Throws<MemberMissingException>(() => { int _ = t.Prop; });
      }

      [Test]
      public void MissingFunction_T01()
      {
         IA t = Duck.New;

         Assert.Throws<MemberMissingException>(() => t.Fun());
      }

      [Test]
      public void MissingFunction_T02()
      {
         IA t = Duck.New(Fun1: 0);

         Assert.Throws<MemberMissingException>(() => t.Fun());
      }

#pragma warning restore 168 // unused variable
   }
}
