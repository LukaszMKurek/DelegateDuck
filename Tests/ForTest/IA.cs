using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests.ForTest
{
   public interface IA
   {
      int Prop { get; set; }

      int Fun();
      int Fun(int i);
   }
}