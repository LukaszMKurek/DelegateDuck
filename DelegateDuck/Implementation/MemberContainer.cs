using System.Linq;
using System.Collections.Generic;
using System;
using DelegateDuck.MemberBehaviours;
using JetBrains.Annotations;

namespace DelegateDuck.Implementation
{
   public sealed class MemberContainer
   {
      private readonly Dictionary<string, IMember> _dictionary = new Dictionary<string, IMember>();

      public void AddMember([NotNull] string memberName, [NotNull] object value)
      {
         if (value == null)
            throw new CanNotRecognizeTypeException("Naked value can't be null. Can't determine member return type.");

         if (_dictionary.ContainsKey(memberName))
            throw new BadUseCaseException(string.Format("Member {0} already exists.", memberName));

         IMember member = value as IMember ?? new PropertyValue(value, value.GetType());

         _dictionary.Add(memberName, member);
      }

      public bool TryFindMember<TMember>(
         [NotNull] string name,
         [NotNull] string expectedMemberTypeName,
         [NotNull] Action<TMember> whenFind) where TMember : class, IMember
      {
         IMember member;
         if (_dictionary.TryGetValue(name, out member) == false)
            return false;

         var searchedMember = member as TMember;
         if (searchedMember == null)
            throw new ImproperMemberTypeException(string.Format("Member {0} is not {1} but {2}.", name, expectedMemberTypeName, member.TypeName));

         whenFind(searchedMember);
         return true;
      }

      public bool ContainsFunction(string name)
      {
         IMember member;
         if (_dictionary.TryGetValue(name, out member) == false)
            return false;

         return member is IMethod;
      }
   }
}