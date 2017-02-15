using System;
using Microsoft.Practices.Unity;
using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Repositories;
using SuperGrouper.Controllers;
using FluentValidation;
using SuperGrouper.Controllers.Validators;
using SuperGrouper.Models;
using System.Collections.Generic;

namespace SuperGrouper
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Controllers
            container.RegisterType<GroupsController>();
            container.RegisterType<GroupablesController>();

            // Validators
            container.RegisterType<IValidator<string>, ObjectIdValidator>();
            container.RegisterType<IValidator<Group>, GroupValidator>();
            container.RegisterType<IValidator<List<Member>>, MembersValidator>();

            // Repositories
            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<IGroupablesRepository, GroupablesRepository>();
        }
    }
}