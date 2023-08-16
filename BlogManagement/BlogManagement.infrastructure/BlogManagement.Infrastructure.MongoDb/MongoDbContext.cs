using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using BlogManagement.Domain.ArticleCategoryAgg;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BlogManagement.Infrastructure.MongoDb
{
    public class MongoDbContext : IMongoDbContext 
    {
        private readonly List<Func<Task>> _commandsAsync;
        private readonly List<Action> _commands;
        protected IMongoClient MongoClient { get; private set; }
        protected IMongoDatabase Database { get; private set; }
        public MongoDbContext(IMongoClient mongoClient, IMongoDatabase database)
        {
            MongoClient = mongoClient;
            Database = database;
            _commandsAsync = new List<Func<Task>>();
            _commands = new List<Action>();
            RegisterConventions();
        }

        private void RegisterConventions()
        {
            // BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            // BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));
            // ConventionRegistry.Register("Conventions", new MongoDbConventions(), x => true);

            BsonClassMap.RegisterClassMap<ArticleCategory>(cm =>
                {
                    cm.AutoMap();
                    cm.UnmapMember(m => m.Articles);
            });
        }

        private class MongoDbConventions : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
        
        public IMongoCollection<IEntityBase> GetCollection<IEntityBase>()
        {
            return this.Database.GetCollection<IEntityBase>(typeof(IEntityBase).Name);
        }

    }
}