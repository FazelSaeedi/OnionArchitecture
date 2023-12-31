using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application.ZarinPal;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using MediatR;
using MH.DDD.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ServiceHost.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class TestController: BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;
        private  IArticleApplication articleApplication;
        private  IMediator _mediator;

        public TestController(ILogger<TestController> logger, IArticleApplication articleApplication, IMediator mediator) : base(logger)
        {
            this.articleApplication = articleApplication;
            _mediator = mediator;
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

            // throw new Exception("Wrong");
            // var T = articleApplication.Create(new CreateArticle(){  });
            throw ServiceResult.Create<string>("OK").ToException();
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();

        }

        [HttpGet("create3")]
        public async Task<ServiceResult<string>> GetAvengers3()
        {

            // throw new Exception("Wrong");
            var T = articleApplication.Test();
            // var pong = await _mediator.Send(new Ping { Message = "Ping" });
            throw ServiceResult.Create<string>("OK").ToException();
            // return ServiceResult.Empty.SetError("ok" , 400 ).To<string>();

        }

    }

}