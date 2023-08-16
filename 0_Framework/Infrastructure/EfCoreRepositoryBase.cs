using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace _0_Framework.Infrastructure
{
    public class EfCoreRepositoryBase<Tkey , T> : IRepository<Tkey , T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<IEntityBase> _dbSet;

        public EfCoreRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<IEntityBase>();
        }

        public DbSet<IEntityBase> GetAsQueryAble() =>  _dbSet ;

        //Get by Id return one T
        public T Get(Tkey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
 
    public interface IMongoDbContext
    {
        public IMongoCollection<IEntityBase> GetCollection<IEntityBase>();

    }

   public class MongoRepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly IMongoDbContext _context;

        public IMongoCollection<T> _mongoCollection ;

        public MongoRepositoryBase(IMongoDbContext context)
        {
            _context = context;
            _mongoCollection = context.GetCollection<T>();
        }

        public void Create(T entity)
        {
            _mongoCollection.InsertOne(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _mongoCollection.AsQueryable().Any(expression);
        }

        public T Get(Tkey id)
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            throw new NotImplementedException();
        }

        public DbSet<IEntityBase> GetAsQueryAble()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            
        }
    }
}
