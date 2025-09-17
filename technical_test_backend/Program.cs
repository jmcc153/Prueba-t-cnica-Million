using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IMongoClient>(s =>
{
    var uri = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
    return new MongoClient(uri);
});

builder.Services.AddSingleton(s =>
{
    var client = s.GetRequiredService<IMongoClient>();
    var databaseName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName");
    return client.GetDatabase(databaseName);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<technical_test.Core.Interfaces.IOwnerRepository, technical_test.Infrastructure.Repositories.OwnerRepository>();
builder.Services.AddScoped<technical_test.Core.Interfaces.IPropertyRepository, technical_test.Infrastructure.Repositories.PropertyRepository>();

builder.Services.AddScoped<technical_test.Application.Interfaces.IOwnerService, technical_test.Application.Services.OwnerService>();
builder.Services.AddScoped<technical_test.Application.Interfaces.IPropertyService, technical_test.Application.Services.PropertyService>();

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
