using WebApiApricode.Services.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureManagers();
builder.Services.ConfigureValidation();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureBackendSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiApricode v1"));

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
