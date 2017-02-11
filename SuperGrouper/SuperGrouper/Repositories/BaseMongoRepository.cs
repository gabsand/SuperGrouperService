using System;
using MongoDB.Driver;

namespace SuperGrouper.Repositories
{
    public class BaseMongoRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public BaseMongoRepository()
        {
            if (_client == null)
            {
                _client = new MongoClient("mongodb://localhost");
            }

            _database = _client.GetDatabase("test");
        }
    }
}