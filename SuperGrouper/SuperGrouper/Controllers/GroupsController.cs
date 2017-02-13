using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SuperGrouper.Repositories;
using SuperGrouper.Repositories.Interfaces;
using MongoDB.Bson;

namespace SuperGrouper.Controllers
{
    [RoutePrefix("api/v1")]
    public sealed class GroupsController : ApiController
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException("groupRepository");
            }

            _groupRepository = groupRepository;
        }
        
        [HttpGet]
        [Route("groups")]
        public async Task<IHttpActionResult> GetGroup(string groupId)
        {
            try
            {
                var groupObjectId = ObjectId.Parse(groupId);
                
                var group = await _groupRepository.GetGroup(groupObjectId);

                if (group != null)
                {
                    return Ok(group);
                }

                return NotFound();
            }
            catch
            {
                return BadRequest("groupId must be a 12 byte string");
            }
        }

        [HttpPost]
        [Route("groups")]
        public async Task<IHttpActionResult> SaveGroup([FromBody]Group group)
        {
            var savedGroup = await _groupRepository.SaveGroup(group);

            if (savedGroup != null)
            {
                return Ok(savedGroup);
            }

            return InternalServerError();
        }

        [HttpGet]
        [Route("groups/{groupId}/groupablefamilies")]
        public async Task<IHttpActionResult> GetGroupableFamilies(string groupId)
        {
            var groupableFamilies = await _groupRepository.GetGroupableFamilies(ObjectId.Parse(groupId));

            return Ok(groupableFamilies);
        }

        [HttpPatch]
        [Route("groups/{groupId}/groupablefamilies")]
        public async Task<IHttpActionResult> AddGroupableFamily(string groupId, [FromBody]GroupableTemplate groupableTemplate)
        {
            var addedGroupableFamily = await _groupRepository.AddGroupableFamily(ObjectId.Parse(groupId), groupableTemplate);

            return Ok(addedGroupableFamily);
        }

        [HttpPatch]
        [Route("groups/{groupId}/members")]
        public async Task<IHttpActionResult> AddMembers(string groupId, [FromBody]List<Member> members)
        {
            var addedMembers = await _groupRepository.AddMembers(ObjectId.Parse(groupId), members);

            return Ok(addedMembers);
        }
    }
}
