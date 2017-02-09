using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SuperGrouper.Controllers
{
    public class GroupController : ApiController
    {
        // GET: api/Group
        public IEnumerable<Group> Get()
        {
            return new List<Group>();
        }

        // GET: api/Group/5
        public Group Get(Guid id)
        {
            return new Group();
        }

        // POST: api/Group
        public void Post([FromBody]Group group)
        {
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
