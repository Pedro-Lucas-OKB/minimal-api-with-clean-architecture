using CleanArchitecture.API.Endpoints.Users;
using CleanArchitecture.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddServices()
    .Services.ConfigureCorsPolicy();
    
var app = builder.Build();
app.RegisterEndpoints();
app.UseCongigurations();

app.Run();

