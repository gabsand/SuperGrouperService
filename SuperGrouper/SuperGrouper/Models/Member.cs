using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperGrouper.Models
{
    public class Member
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}