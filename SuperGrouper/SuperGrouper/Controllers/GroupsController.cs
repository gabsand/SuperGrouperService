using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SuperGrouper.Repositories.Interfaces;
using MongoDB.Bson;
using FluentValidation;

namespace SuperGrouper.Controllers
{
    [RoutePrefix("api/v1")]
    public sealed class GroupsController : ApiController
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<string> _objectIdValidator;
        private readonly IValidator<Group> _groupValidator;
        private readonly IValidator<List<Member>> _membersValidator;

        public GroupsController(IGroupRepository groupRepository, 
            IValidator<string> objectIdValidator,
            IValidator<Group> groupValidator,
            IValidator<List<Member>> membersValidator)
        {
            if (groupRepository == null) throw new ArgumentNullException("groupRepository");
            if (objectIdValidator == null) throw new ArgumentNullException("objectIdValidator");
            if (groupValidator == null) throw new ArgumentNullException("groupValidator");
            if (membersValidator == null) throw new ArgumentNullException("membersValidator");

            _groupRepository = groupRepository;
            _objectIdValidator = objectIdValidator;
            _groupValidator = groupValidator;
            _membersValidator = membersValidator;
        }
        
        [HttpGet]
        [Route("groups")]
        public async Task<IHttpActionResult> GetGroup(string groupId)
        {
            if (!_objectIdValidator.Validate(groupId).IsValid)
            {
                return BadRequest("groupId must be a 24 digit hex string.");
            }
            var groupObjectId = ObjectId.Parse(groupId);

            var group = await _groupRepository.GetGroup(groupObjectId);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        [Route("groups")]
        public async Task<IHttpActionResult> SaveGroup([FromBody]Group group)
        {
            if (!_groupValidator.Validate(group).IsValid)
            {
                return BadRequest("group must have non-empty property 'Name'.");
            }

            var savedGroup = await _groupRepository.SaveGroup(group);

            if (savedGroup == null)
            {
                return InternalServerError();
            }

            return Ok(savedGroup);
        }

        //[HttpGet]
        //[Route("groups/{groupId}/groupablefamilies")]
        //public async Task<IHttpActionResult> GetGroupableFamilies(string groupId)
        //{
        //    var groupableFamilies = await _groupRepository.GetGroupableFamilies(ObjectId.Parse(groupId));

        //    return Ok(groupableFamilies);
        //}

        //[HttpPatch]
        //[Route("groups/{groupId}/groupablefamilies")]
        //public async Task<IHttpActionResult> AddGroupableFamily(string groupId, [FromBody]GroupableTemplate groupableTemplate)
        //{
        //    var addedGroupableFamily = await _groupRepository.AddGroupableFamily(ObjectId.Parse(groupId), groupableTemplate);

        //    return Ok(addedGroupableFamily);
        //}

        [HttpPatch]
        [Route("groups/{groupId}/members")]
        public async Task<IHttpActionResult> AddMembers(string groupId, [FromBody]List<Member> members)
        {
            if (!_objectIdValidator.Validate(groupId).IsValid)
            {
                return BadRequest("groupId must be a 24 digit hex string.");
            }
            if (!_membersValidator.Validate(members).IsValid)
            {
                return BadRequest("Must have at least one member and each member must have a valid Name.");
            }

            await _groupRepository.AddMembers(ObjectId.Parse(groupId), members);

            return Ok();
        }
    }
}
