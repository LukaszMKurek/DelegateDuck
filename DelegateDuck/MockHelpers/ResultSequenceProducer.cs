using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.Implementation;

namespace DelegateDuck.MockHelpers
{
   // mutable
   public sealed class ResultSequenceProducer<TResult>
   {
      private readonly Stack<TResult> _resultSequence;

      public ResultSequenceProducer(IEnumerable<TResult> resultSequence)
      {
         _resultSequence = new Stack<TResult>(resultSequence.Reverse());
      }

      public TResult GetNextResult()
      {
         lock (_resultSequence)
         {
            if (_resultSequence.Count == 0)
               throw new BadUseCaseException("No more elements to return.");

            return _resultSequence.Pop();
         }
      }
   }
}