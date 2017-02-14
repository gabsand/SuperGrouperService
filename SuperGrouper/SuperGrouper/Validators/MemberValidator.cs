using FluentValidation;
using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperGrouper.Controllers.Validators
{
    public class MemberValidator: AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(member => member.Name).NotEmpty();
        }
    }
}