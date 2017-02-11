﻿using NUnit.Framework;
using Moq;
using SuperGrouper.Controllers;
using SuperGrouper.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using SuperGrouper.Models;
using System.Web.Http.Results;

namespace SuperGrouper.Tests.Controllers
{
    [TestFixture]
    public class GroupControllerTests
    {
        [Test]
        public void GetGroup_GroupRepositoryReturnsNull_ReturnsInternalServerError()
        {
            var groupId = new Guid();
            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.GetGroup(It.IsAny<Guid>()))
                .Returns(Task.FromResult<Group>(null));

            var sut = new GroupController(groupRepository.Object);

            var actionResult = sut.Get(groupId).Result;
            var contentResult = actionResult as NotFoundResult;

            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void GetGroup_GroupRepositoryReturnsGroup_ReturnsOkWithCorrectGroup()
        {
            var groupId = Guid.NewGuid();
            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.GetGroup(It.IsAny<Guid>()))
                .Returns(Task.FromResult<Group>(new Group() {Id = groupId}));

            var sut = new GroupController(groupRepository.Object);

            var actionResult = sut.Get(groupId).Result;
            var contentResult = actionResult as OkNegotiatedContentResult<Group>;

            Assert.IsTrue(contentResult.Content.Id.Equals(groupId));
        }

        [Test]
        public void PostGroup_GroupRepositoryReturnsNull_ReturnsInternalServerError()
        {
            var group = new Group()
            {
                Name = "Failure Group"
            };

            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.SaveGroup(It.IsAny<Group>()))
                .Returns(Task.FromResult<Group>(null));

            var sut = new GroupController(groupRepository.Object);

            var actionResult = sut.Post(group).Result;
            var contentResult = actionResult as InternalServerErrorResult;

            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void PostGroup_GroupRepositoryReturnsSavedGroup_ReturnsOkWithCorrectGroup()
        {
            var group = new Group()
            {
                Name = "Successful Group"
            };

            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.SaveGroup(It.IsAny<Group>()))
                .Returns(Task.FromResult<Group>(group));

            var sut = new GroupController(groupRepository.Object);

            var actionResult = sut.Post(group).Result;
            var contentResult = actionResult as OkNegotiatedContentResult<Group>;

            Assert.IsTrue(contentResult.Content.Name.Equals(group.Name));
        }
    }
}
