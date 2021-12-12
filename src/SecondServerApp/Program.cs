var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Map("/second", mappedApp =>
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        mappedApp.UseSwagger();
        mappedApp.UseSwaggerUI();
    }

    mappedApp.UseRouting();
    mappedApp.UseAuthorization();
    
    mappedApp.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});


app.Run();


