using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _0_Framework.Application.ZarinPal
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger logger;

        private BaseController()
        {

        }

        public BaseController( ILogger logger )
        {
            this.logger = logger;
        }

    }
}