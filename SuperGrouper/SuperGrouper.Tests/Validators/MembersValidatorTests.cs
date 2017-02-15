using System.Collections.Generic;
using NUnit.Framework;
using SuperGrouper.Validators;
using SuperGrouper.Models;

namespace SuperGrouper.Tests.Validators
{
    [TestFixture]
    public class MembersValidatorTests
    {
        [Test]
        public void MembersValidator_NoMembers_ReturnsInvalidResult()
        {
            var noMembers = new List<Member>();
            var validator = new MembersValidator();
            var result = validator.Validate(noMembers);

            Assert.IsTrue(result.IsValid.Equals(false));
        }

        [Test]
        public void MembersValidator_OneMember_ReturnsValidResult()
        {
            var validMemberList = new List<Member> {new Member {Name = "Billy Joel"}};
            var validator = new MembersValidator();
            var result = validator.Validate(validMemberList);

            Assert.IsTrue(result.IsValid.Equals(true));
        }
    }
}
