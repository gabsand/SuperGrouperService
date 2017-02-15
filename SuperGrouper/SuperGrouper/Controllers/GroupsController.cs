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
    [RoutePrefix("api/v1/groups")]
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

        [HttpPatch]
        [Route("{groupId}/members")]
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
