using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Application;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using BlogManagement.Application;
using BlogManagement.BlogManagement.infrastructure.BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.Configuration;
using BlogManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using ServiceHost;
using TaskManagement.Infrastructure.Configuration;
using TaskManagement.Infrastructure.EfCore;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((builder, configuration) => configuration
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
);

// Add services to the container.

builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("Base_ConnectionString");
BlogManagementBootstrapper.Configure(builder.Services, connectionString);
TaskManagementBootstrapper.Configure(builder.Services, connectionString);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        builder =>
        {
            // builder.WithOrigins("http://localhost:4200")
            builder
            .SetIsOriginAllowed(x => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});


builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies( 
    AppDomain.CurrentDomain.GetAssemblies()
 ));


builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
// builder.Services.AddTransient<IAuthHelper, AuthHelper>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapitest", Version = "v1" });
});



var app = builder.Build();



// T.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiExample v1" 
    ));
}


app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{

    var blogContext = serviceScope.ServiceProvider.GetService<BlogContext>();
    blogContext.Database.Migrate();
    

    var taskContext = serviceScope.ServiceProvider.GetService<TaskContext>();
    taskContext.Database.Migrate();
    
}

app.Run();



public partial class Program
{

    public static string Name = "Base_Service_Host" ; 


}