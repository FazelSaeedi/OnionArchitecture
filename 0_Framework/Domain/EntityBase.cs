using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _0_Framework.Domain
{
    
    public interface IEntityBase { object GetId(); }

 public abstract class EntityBase : IEntityBase
    {

        public bool IsDeleted { get; protected set; }
        public bool IsVisibled { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public DateTime ModifyAt { get; protected set; }
        
        public object _Id { get; protected set; }


        public object GetId()
        {
            return _Id;
        }

    }

     public abstract class EntityBase<TKey> : EntityBase where TKey : IEquatable<TKey>
    {
        protected Guid _identifiableId;
        protected object Actual => this;
        protected TKey _id;
        
        public virtual TKey Id
        {
            get { return (TKey)base._Id; }
            protected set
            {
                base._Id = _id = value;
                string gu ;
                if (value is string _idString)
                {
                    if (!this.IsValid(_idString))
                        _identifiableId = Guid.Empty;
                    else
                        _identifiableId = Guid.Parse(_idString);
                }
            }
        }


        public bool IsValid(string _id) => Guid.TryParse(_id + string.Empty, out var guid);
    }
}
