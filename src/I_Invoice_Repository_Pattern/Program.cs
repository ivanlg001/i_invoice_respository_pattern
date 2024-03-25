using I_Invoice_Repository_Pattern.DataAccess;
using I_Invoice_Repository_Pattern.Handlers;
using I_Invoice_Repository_Pattern.Repositories;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILiteDbContext, LiteDbContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDirectoryHandler, DirectoryHandler>();

var confBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

builder.Services.Configure<LiteDbOptions>(confBuilder.GetSection("LiteDbOptions"));


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
