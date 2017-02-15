using FluentValidation;
using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperGrouper.Validators
{
    public class MembersValidator: AbstractValidator<List<Member>>
    {
        public MembersValidator()
        {
            RuleFor(members => members.Count).GreaterThan(0);
            //RuleFor(members => members).SetCollectionValidator(new MemberValidator());
        }
    }
}