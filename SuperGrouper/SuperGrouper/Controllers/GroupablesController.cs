using MongoDB.Bson;
using SuperGrouper.Models;
using SuperGrouper.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation;

namespace SuperGrouper.Controllers
{
    [RoutePrefix("api/v1/groupables")]
    public sealed class GroupablesController: ApiController
    {
        private readonly IGroupablesRepository _groupablesRepository;

        public GroupablesController(IGroupablesRepository groupablesRepository)
        {
            if (groupablesRepository == null)
            {
                throw new ArgumentNullException("groupablesRepository");
            }

            _groupablesRepository = groupablesRepository;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetGroupable(string groupableId)
        {
            try
            {
                var groupableObjectId = ObjectId.Parse(groupableId);

                var group = await _groupablesRepository.GetGroupableInstance(groupableObjectId);

                if (group != null)
                {
                    return Ok(group);
                }

                return NotFound();
            }
            catch
            {
                return BadRequest("groupableId must be a 12 byte string");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveGroupable([FromBody]GroupableInstance groupableInstance)
        {
            var savedGroupable = await _groupablesRepository.SaveGroupableInstance(groupableInstance);

            if (savedGroupable != null)
            {
                return Ok(savedGroupable);
            }

            return InternalServerError();
        }
    }
}