using KOT.Models;
using KOT.Services.Injector;

var builder = WebApplication.CreateBuilder(args);

// Load model configuration for mongodb connection
builder.Services.Configure<KOTDatabaseSettings>(builder.Configuration.GetSection("KOTDataBase"));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject service dependencies
var serviceInjector = new ServiceInjector();
serviceInjector.InjectServices(builder.Services);

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
