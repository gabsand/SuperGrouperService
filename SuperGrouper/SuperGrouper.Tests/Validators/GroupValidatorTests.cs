using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperGrouper.Models;
using SuperGrouper.Controllers.Validators;
using FluentValidation.TestHelper;

namespace SuperGrouper.Tests.Validators
{
    [TestFixture]
    public class GroupValidatorTests
    {
        [Test]
        public void GroupValidator_GroupWithName_ReturnsValidResult()
        {
            var validator = new GroupValidator();
            validator.ShouldNotHaveValidationErrorFor(group => group.Name, "I am a name");
        }

        [Test]
        public void GroupValidator_GroupWithNoName_ReturnsInvalidResult()
        {
            var validator = new GroupValidator();
            validator.ShouldHaveValidationErrorFor(group => group.Name, (string)null);
        }
    }
}
