using MongoDB.Bson;
using SuperGrouper.Models;
using SuperGrouper.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

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

                var group = await _groupablesRepository.GetGroupable(groupableObjectId);

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
        public async Task<IHttpActionResult> SaveGroupable([FromBody]Groupable groupable)
        {
            var savedGroupable = await _groupablesRepository.SaveGroupable(groupable);

            if (savedGroupable != null)
            {
                return Ok(savedGroupable);
            }

            return InternalServerError();
        }
    }
}