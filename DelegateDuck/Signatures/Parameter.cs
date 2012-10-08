using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.Implementation;
using JetBrains.Annotations;

namespace DelegateDuck.Signatures
{
   public struct Parameter
   {
      private readonly Type _type;
      private readonly bool _isRef;
      private readonly bool _isOut;

      public Parameter([NotNull] Type type, bool isRef = false, bool isOut = false)
      {
         if (isRef && isOut)
            throw new BadUseCaseException("Parameter can not be ref and out simultaneously.");

         _type = type;
         _isRef = isRef;
         _isOut = isOut;
      }

      public Type Type
      {
         get { return _type ?? typeof(void); } // todo tymczasowo tylko w przypadku dynamiczym nie wiem co robiæ
      }

      public bool IsRef
      {
         get { return _isRef; }
      }

      public bool IsOut
      {
         get { return _isOut; }
      }
   }
}
