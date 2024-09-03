using IcecreamMAUI.Api.Utils;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddAuthenticationAndAuthorization(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(IcecreamMAUI.Shared.AssemblyReference));

builder.Services.AddApiServices();

var app = builder.Build();

#if DEBUG
ApiExtensions.MigrateDatabase(app.Services);
#endif

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();
