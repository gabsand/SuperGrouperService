﻿using NUnit.Framework;
using SuperGrouper.Controllers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using MongoDB.Bson;

namespace SuperGrouper.Tests.Validators
{
    [TestFixture]
    public class ObjectIdValidatorTests
    {
        [Test]
        public void ObjectIdValidator_ValidString_ReturnsValidResult()
        {
            var invalidString = "not the best string";
            var validator = new ObjectIdValidator();
            var result = validator.Validate(invalidString);

            Assert.IsTrue(result.IsValid.Equals(false));
        }

        [Test]
        public void ObjectIdValidator_InvalidString_ReturnsInvalidResult()
        {
            var objectId = ObjectId.GenerateNewId().ToString();
            var validator = new ObjectIdValidator();
            var result = validator.Validate(objectId);

            Assert.IsTrue(result.IsValid.Equals(true));
        }
    }
}
