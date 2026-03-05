using Submission.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();  
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseAuthentication();
app.UseAuthorization();

app.MapAllEndpoints();

app.Run();
