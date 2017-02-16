using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using MongoDB.Bson;

namespace SuperGrouper.Validators
{
    public class ObjectIdValidator: AbstractValidator<string>
    {
        public ObjectIdValidator()
        {
            RuleFor(id => id).Must(BeAValidObjectId);
        }

        private bool BeAValidObjectId(string id)
        {
            ObjectId objectId;
            var isValid = ObjectId.TryParse(id, out objectId);

            return isValid;
        }
    }
}