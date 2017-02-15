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
    /// <summary>
    /// Enables creation and retrieval of "groupable templates," where "groupable templates"
    /// are templates for creating "groupables," which are objects that can be grouped to form 
    /// a partition of a group.
    /// </summary>
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

        /// <summary>
        /// Gets groupable template its id.
        /// </summary>
        /// <param name="groupableTemplateId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
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

        /// <summary>
        /// Saves groupable template.
        /// </summary>
        /// <param name="groupableTemplate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
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

        /// <summary>
        /// Gets groupable template by the id of the group to which it is associated.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
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
