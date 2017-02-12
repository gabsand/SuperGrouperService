using System;
using Microsoft.Practices.Unity;
using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Repositories;
using SuperGrouper.Controllers;

namespace SuperGrouper
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // Controllers
            container.RegisterType<GroupsController>();
            container.RegisterType<GroupablesController>();

            // Repositories
            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<IGroupablesRepository, GroupablesRepository>();
        }
    }
}