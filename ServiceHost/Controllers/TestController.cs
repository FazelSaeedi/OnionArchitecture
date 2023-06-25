using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using MH.DDD.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ServiceHost.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class TestController: ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;
        private  IArticleApplication articleApplication;

        public TestController(ILogger<TestController> logger, IArticleApplication articleApplication)
        {
            _logger = logger;
            this.articleApplication = articleApplication;
        }

        [HttpGet("create")]
        public ServiceResult<string> GetAvengers()
        {
            // var T = articleApplication.Create(new CreateArticle(){  });
            return ServiceResult.Create<string>("OK");
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();

        }

        [HttpGet("create2")]
        public ServiceResult<string> GetAvengers2()
        {

            throw new Exception("Wrong");
            // var T = articleApplication.Create(new CreateArticle(){  });
            // return ServiceResult.Create<string>("OK");
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();

        }

    }
}