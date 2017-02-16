using Microsoft.Practices.Unity;
using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Repositories;
using SuperGrouper.Controllers;
using FluentValidation;
using SuperGrouper.Models;
using System.Collections.Generic;
using SuperGrouper.Validators;

namespace SuperGrouper
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Controllers
            container.RegisterType<GroupsController>();
            container.RegisterType<GroupablesController>();
            container.RegisterType<GroupableTemplatesController>();

            // Validators
            container.RegisterType<IValidator<string>, ObjectIdValidator>();
            container.RegisterType<IValidator<Group>, GroupValidator>();
            container.RegisterType<IValidator<List<Member>>, MembersValidator>();
            container.RegisterType<IValidator<GroupableTemplate>, GroupableTemplateValidator>();

            // Repositories
            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<IGroupablesRepository, GroupablesRepository>();
            container.RegisterType<IGroupableTemplatesRepository, GroupableTemplatesRepository>();
        }
    }
}