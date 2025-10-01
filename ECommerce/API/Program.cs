using API.Filters;
using API.Middlewares;
using Infrastructure.Building_Configuration;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
	options.Filters.Add<ValidationFilter>();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddingContext(builder.Configuration);

builder.Services.AutoMapperConfiguration();

builder.Services.DependencyService();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

await ApplingMigrationAndSeeding.MigrateAndSeedAsync(app.Services);

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
