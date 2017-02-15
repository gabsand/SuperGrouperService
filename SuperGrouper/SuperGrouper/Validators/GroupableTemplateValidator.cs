using FluentValidation;
using SuperGrouper.Models;

namespace SuperGrouper.Validators
{
    public class GroupableTemplateValidator: AbstractValidator<GroupableTemplate>
    {
        public GroupableTemplateValidator()
        {
            RuleFor(groupableTemplate => groupableTemplate.Name).NotEmpty();
        }
    }
}