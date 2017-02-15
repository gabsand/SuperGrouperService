using FluentValidation;
using SuperGrouper.Models;

namespace SuperGrouper.Validators
{
    public class GroupValidator: AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(group => group).NotNull();
            RuleFor(group => group.Name).NotEmpty();
        }
    }
}