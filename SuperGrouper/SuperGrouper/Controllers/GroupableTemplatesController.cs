using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FluentValidation;
using SuperGrouper.Models;
using SuperGrouper.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Web.Http.Results;
using MongoDB.Bson;

namespace SuperGrouper.Controllers
{
    [RoutePrefix("api/v1/groupableTemplates")]
    public class GroupableTemplatesController : ApiController
    {
        private readonly IGroupableTemplatesRepository _groupableTemplatesRepository;
        private readonly IValidator<string> _objectIdValidator;
        private readonly IValidator<GroupableTemplate> _groupValidator;

        public GroupableTemplatesController(IGroupableTemplatesRepository groupableTemplatesRepository,
            IValidator<string> objectIdValidator,
            IValidator<GroupableTemplate> groupableTemplateValidator)
        {
            if (groupableTemplatesRepository == null) throw new ArgumentNullException("groupableTemplatesRepository");
            if (objectIdValidator == null) throw new ArgumentNullException("objectIdValidator");
            if (groupableTemplateValidator == null) throw new ArgumentNullException("groupableTemplateValidator");

            _groupableTemplatesRepository = groupableTemplatesRepository;
            _objectIdValidator = objectIdValidator;
            _groupValidator = groupableTemplateValidator;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetGroupableTemplate(string groupableTemplateId)
        {
            if (!_objectIdValidator.Validate(groupableTemplateId).IsValid)
            {
                return BadRequest("groupableTemplateId must be a 24 digit hex string.");
            }

            var groupableTemplateObjectId = ObjectId.Parse(groupableTemplateId);

            var groupableTemplate = await _groupableTemplatesRepository.GetGroupableTemplate(groupableTemplateObjectId);

            if (groupableTemplate == null)
            {
                return NotFound();
            }

            return Ok(groupableTemplate);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveGroupableTemplate([FromBody]GroupableTemplate groupableTemplate)
        {
            if (!_groupValidator.Validate(groupableTemplate).IsValid)
            {
                return BadRequest("groupableTemplate must have non-empty property 'Name'.");
            }

            var savedGroup = await _groupableTemplatesRepository.SaveGroupableTemplate(groupableTemplate);

            if (savedGroup == null)
            {
                return InternalServerError();
            }

            return Ok(savedGroup);
        }

        [HttpGet]
        [Route("groupId={groupId}")]
        public async Task<IHttpActionResult> GetGroupableTemplatesByGroupId(string groupId)
        {
            if (!_objectIdValidator.Validate(groupId).IsValid)
            {
                return BadRequest("groupId must be a 24 digit hex string.");
            }

            var groupObjectId = ObjectId.Parse(groupId);

            var group = await _groupableTemplatesRepository.GetGroupableTemplatesByGroupId(groupObjectId);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }
    }
}
