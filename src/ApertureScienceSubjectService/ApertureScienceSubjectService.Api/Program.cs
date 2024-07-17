using ApertureScienceSubjectService.Api.Cosmos;
using ApertureScienceSubjectService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(CreateConfiguration());
builder.Services.AddScoped<IActivationCodeService, ActivationCodeService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped(typeof(ICosmosRepository<>), typeof(CosmosRepository<>));
builder.Services.AddScoped(typeof(ICosmosAdapter<>), typeof(CosmosAdapter<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IConfiguration CreateConfiguration() =>
    new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();