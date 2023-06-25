using System.Net;
using MH.DDD.Core.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ServiceHost
{
    public class ExceptionHandlingMiddleware
    {
         private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHostEnvironment env)
        {
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            bool expHappend = false;
            bool appErrorHappend = false;

            var srError = new ServiceResult()
            .SetError(
                "متاسفانه سرویس مورد نظر هم اکنون در دسترس نیست",
                 500);
            try
            {
                await _next(context);
            }
            catch (System.Exception exp)
            {
                _logger.LogCritical(exp, "refId {ReferenceId} happend in {AppName} application",
                    srError.ReferenceId,
                    Program.Name);
                srError.Error = new AppError
                {
                    Code = 500,
                    Message = "NotOk"
                };
                expHappend = true;
            }

            if (expHappend)
            {

                context.Response.ContentType = "application/json";
               
                if (env.IsProduction() && !appErrorHappend )
                    srError = srError
                    .SetError(
                        "متاسفانه سرویس مورد نظر هم اکنون در دسترس نیست",
                        500);

                var error = JsonConvert.SerializeObject(srError , settings);
                await context.Response.WriteAsync(error);
            }

            if (context.Response.StatusCode == (int)HttpStatusCode.MethodNotAllowed ||
            context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                context.Response.ContentType = "application/json";
                srError = srError
                .SetError(
                    "درخواست شما یافت نشد یا متد ارسالی شما اشتباه است",
                    405);


                var error = JsonConvert.SerializeObject(srError , settings);
                await context.Response.WriteAsync(error);
            }
        }
    }
}