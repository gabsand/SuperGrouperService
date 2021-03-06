﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace SuperGrouper.Models
{
    public class Group
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Member> Members { get; set; }
    }
}