using Ktt.ScopeTest.Business;
using Ktt.ScopeTest.Services;
using Ktt.ScopeTest.Services.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// init the LabelContext by the LabelContextProvider
builder.Services.AddScoped<LabelContextProvider>();
builder.Services.AddScoped(builder => builder.GetRequiredService<LabelContextProvider>().Context);

builder.Services.AddTransient<MyService>();
builder.Services.AddHostedService<MyBackgroundService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LabelValidationMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
