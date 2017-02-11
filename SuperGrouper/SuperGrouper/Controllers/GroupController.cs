using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SuperGrouper.Repositories;
using SuperGrouper.Repositories.Interfaces;

namespace SuperGrouper.Controllers
{
    public sealed class GroupController : ApiController
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            if (groupRepository == null)
            {
                throw new ArgumentNullException("groupRepository");
            }

            _groupRepository = groupRepository;
        }

        // GET: api/Group/5
        public async Task<IHttpActionResult> Get(Guid groupId)
        {
            var group = await _groupRepository.GetGroup(groupId);

            if (group != null)
            {
                return Ok(group);
            }

            return NotFound();
        }

        // POST: api/Group
        public async Task<IHttpActionResult> Post([FromBody]Group group)
        {
            var savedGroup = await _groupRepository.SaveGroup(group);

            if (savedGroup != null)
            {
                return Ok(savedGroup);
            }

            return InternalServerError();
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
