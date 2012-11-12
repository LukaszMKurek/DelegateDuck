using System;
using System.Collections.Generic;
using System.Linq;
using DelegateDuck.MemberBehaviours;
using JetBrains.Annotations;

namespace DelegateDuck.MockHelpers
{
   public static class As
   {
      public static Method Method(Delegate @delegate)
      {
         return new Method(@delegate);
      }

      #region MehodRestOverload
      public static Method Method(Action @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1>(Action<T1> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2>(Action<T1, T2> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3>(Action<T1, T2, T3> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4>(Action<T1, T2, T3, T4> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
         Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
         Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
         Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
         Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
         Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<TResult>(Func<TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, TResult>(Func<T1, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, TResult>(Func<T1, T2, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> @delegate)
      {
         return new Method(@delegate);
      }

      public static Method Method<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
         Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> @delegate)
      {
         return new Method(@delegate);
      }
      #endregion MehodRestOvverload

      public static PropertyValue PropertyValue<TResult>(/*this */TResult value) // upewniæ siê ¿e property wbêdzie read/write
      {
         return new PropertyValue(value, typeof(TResult));
      }

      public static MethodIgnoringArguments<TResult> MethodResult<TResult>(/*this */TResult result)
      {
         return new MethodIgnoringArguments<TResult>(() => result);
      }

      public static MethodIgnoringArguments<TResult> MethodResultSequence<TResult>(/*this */IEnumerable<TResult> resultSequence)
      {
         var resultSequenceProducer = new ResultSequenceProducer<TResult>(resultSequence);

         return new MethodIgnoringArguments<TResult>(resultSequenceProducer.GetNextResult);
      }

      public static MethodIgnoringArguments<TResult> MethodResultSequence<TResult>(params TResult[] resultSequence)
      {
         return MethodResultSequence((IEnumerable<TResult>)resultSequence);
      }

      /*public static MethodResultSequence<TResult> MethodResultSequence<TResult>(this IEnumerable resultSequence)
      {
         return new MethodResultSequence<TResult>(resultSequence.Cast<TResult>());
      }*/

      public static PropertyGetter<TResult> PropertyValueSequence<TResult>(/*this */IEnumerable<TResult> resultSequence)
      {
         var resultSequenceProducer = new ResultSequenceProducer<TResult>(resultSequence);

         return new PropertyGetter<TResult>(resultSequenceProducer.GetNextResult);
      }

      public static PropertyGetter<TResult> PropertyValueSequence<TResult>(params TResult[] resultSequence)
      {
         return PropertyValueSequence((IEnumerable<TResult>)resultSequence);
      }

      /*public static PropertyValueSequence<TResult> PropertyValueSequence<TResult>(this IEnumerable resultSequence)
      {
         return new PropertyValueSequence<TResult>(resultSequence.Cast<TResult>());
      }*/

      // .AsMethodResultSequenceCyclic() 

      [NotNull]
      public static PropertyGetter<T> PropertyGet<T>([NotNull]Func<T> getter)
      {
         return new PropertyGetter<T>(getter);
      }

      [NotNull]
      public static PropertySetter<T> Setter<T>([NotNull]Action<T> setter)
      {
         return new PropertySetter<T>(setter);
      }

      [NotNull]
      public static Property Set<T>([NotNull]this PropertyGetter<T> getter, [NotNull]Action<T> setter)
      {
         var set = Setter(setter);
         return new Property(getter, set);
      }

      [NotNull]
      public static Property Getter<T>([NotNull]this PropertySetter<T> setter, [NotNull]Func<T> getter)
      {
         var get = PropertyGet(getter);
         return new Property(get, setter);
      }
   }
}
