using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegateDuck.Implementation
{
   [Serializable]
   public class BadUseCaseException : InvalidOperationException
   {
      public BadUseCaseException(string message)
         : base(message)
      {}
   }

   [Serializable]
   public sealed class CanNotRecognizeTypeException : BadUseCaseException
   {
      public CanNotRecognizeTypeException(string message)
         : base(message)
      {}
   }

   [Serializable]
   public sealed class ImproperMemberTypeException : BadUseCaseException
   {
      public ImproperMemberTypeException(string message)
         : base(message)
      {}
   }

   [Serializable]
   public sealed class MemberMissingException : BadUseCaseException
   {
      public MemberMissingException(string message)
         : base(message)
      { }
   }

   [Serializable]
   public sealed class SignatureDoNotMatchException : BadUseCaseException
   {
      public SignatureDoNotMatchException(string message)
         : base(message)
      { }
   }

   /*[Serializable]
   public sealed class ReturnTypeDoNotMatchException : BadUseCaseException
   {
      public ReturnTypeDoNotMatchException(string message)
         : base(message)
      { }
   }*/
}
