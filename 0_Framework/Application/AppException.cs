using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MH.DDD.Core.Types;

namespace _0_Framework.Application
{
    public class AppException : System.Exception
    {
        
        public ServiceResult serviceResult { get; private set; }
        public AppException(ServiceResult sr)
        {
            this.serviceResult = sr;
        }

    }
}