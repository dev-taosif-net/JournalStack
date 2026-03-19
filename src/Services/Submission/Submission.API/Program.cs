using Submission.API;
using Submission.API.Endpoints;
using Submission.Application;
using Submission.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Add

builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration)
    ;

#endregion

var app = builder.Build();

#region Use

app
    .UseSwagger()
    .UseSwaggerUI()
    .UseRouting();

app.MapAllEndpoints();

#endregion

app.Run();