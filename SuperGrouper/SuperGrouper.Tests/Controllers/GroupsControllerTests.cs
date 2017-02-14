using NUnit.Framework;
using Moq;
using SuperGrouper.Controllers;
using SuperGrouper.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using SuperGrouper.Models;
using System.Web.Http.Results;
using MongoDB.Bson;
using SuperGrouper.Controllers.Validators;
using SuperGrouper.Repositories;
using FluentValidation;
using System.Collections.Generic;

namespace SuperGrouper.Tests.Controllers
{
    [TestFixture]
    public class GroupsControllerTests
    {
        public GroupsController GetGroupsController(IGroupRepository groupRepository = null, 
            IValidator<string> objectIdValidator = null,
            IValidator<Group> groupValidator = null, 
            IValidator<List<Member>> membersValidator = null)
        {
            var mockGroupRepository = groupRepository ?? new Mock<IGroupRepository>().Object;
            var mockObjectIdValidator = objectIdValidator ?? new Mock<IValidator<string>>().Object;
            var mockGroupValidator = groupValidator ?? new Mock<IValidator<Group>>().Object;
            var mockMembersValidator = membersValidator ?? new Mock<IValidator<List<Member>>>().Object;

            return new GroupsController(mockGroupRepository, mockObjectIdValidator, mockGroupValidator, mockMembersValidator);
        }

        [Test]
        public void GetGroup_InvalidObjectId_ReturnsBadRequest()
        {
            var groupId = "invalidObjectId";
            var groupRepository = new Mock<IGroupRepository>();

            var sut = GetGroupsController(groupRepository.Object);

            var actionResult = sut.GetGroup(groupId).Result;
            var contentResult = actionResult as BadRequestErrorMessageResult;

            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void GetGroup_GroupRepositoryReturnsNull_ReturnsInternalServerError()
        {
            var groupId = ObjectId.GenerateNewId();
            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.GetGroup(It.IsAny<ObjectId>()))
                .Returns(Task.FromResult<Group>(null));

            var sut = GetGroupsController(groupRepository.Object);

            var actionResult = sut.GetGroup(groupId.ToString()).Result;
            var contentResult = actionResult as NotFoundResult;

            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void GetGroup_GroupRepositoryReturnsGroup_ReturnsOkWithCorrectGroup()
        {
            var groupId = ObjectId.GenerateNewId();
            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.GetGroup(It.IsAny<ObjectId>()))
                .Returns(Task.FromResult<Group>(new Group() {Id = groupId}));

            var sut = GetGroupsController(groupRepository.Object);

            var actionResult = sut.GetGroup(groupId.ToString()).Result;
            var contentResult = actionResult as OkNegotiatedContentResult<Group>;

            Assert.IsTrue(contentResult.Content.Id.Equals(groupId));
        }

        [Test]
        public void SaveGroup_GroupRepositoryReturnsNull_ReturnsInternalServerError()
        {
            var group = new Group()
            {
                Name = "Failure Group"
            };

            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.SaveGroup(It.IsAny<Group>()))
                .Returns(Task.FromResult<Group>(null));

            var sut = GetGroupsController(groupRepository.Object);

            var actionResult = sut.SaveGroup(group).Result;
            var contentResult = actionResult as InternalServerErrorResult;

            Assert.IsNotNull(contentResult);
        }

        [Test]
        public void SaveGroup_GroupRepositoryReturnsSavedGroup_ReturnsOkWithCorrectGroup()
        {
            var group = new Group()
            {
                Name = "Successful Group"
            };

            var groupRepository = new Mock<IGroupRepository>();
            groupRepository.Setup(x => x.SaveGroup(It.IsAny<Group>()))
                .Returns(Task.FromResult<Group>(group));

            var sut = GetGroupsController(groupRepository.Object);

            var actionResult = sut.SaveGroup(group).Result;
            var contentResult = actionResult as OkNegotiatedContentResult<Group>;

            Assert.IsTrue(contentResult.Content.Name.Equals(group.Name));
        }
    }
}
