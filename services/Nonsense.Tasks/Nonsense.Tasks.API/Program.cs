using Nonsense.Common;
using Nonsense.Data;
using Nonsense.Tasks.API.Settings;
using Nonsense.Tasks.BusinessLogic;
using Nonsense.Tasks.BusinessLogic.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// custom services
builder.Configuration.AddDotEnvFile();
builder.Services.AddAppSettings<AppSettings>(builder.Configuration);
builder.Services.AddDataContext<INonsenseDataContext, NonsenseDataContext, AppSettings>(appSettings => appSettings.Database.ConnectionString);
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<CreateNonsenseTaskCommand>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(configure => configure.MapControllers());

app.Run();
