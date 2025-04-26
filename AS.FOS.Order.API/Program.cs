using AS.FOS.Order.API.Extensions;
using AS.FOS.Order.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

app.ApplicationBuilder();

app.MapControllers();

app.Run();
