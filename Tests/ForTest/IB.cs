using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests.ForTest
{
   public class Aa
   {}

   public class Ba : Aa
   {}

   public interface IBa
   {
      Aa Prop { get; set; }

      Aa Fun();
      Aa Fun(Aa i);
   }

   public interface IBb
   {
      Ba Prop { get; set; }

      Ba Fun();
      Ba Fun(Ba i);
   }
}