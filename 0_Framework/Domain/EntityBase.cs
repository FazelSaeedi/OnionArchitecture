using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public interface IEntityBase
    {

    }
    public class EntityBase<T> : IEntityBase
    {
        
        public T Id { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public bool IsDeleted  { get; set; }
        public bool IsVisibled { get; set; }


        public EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
