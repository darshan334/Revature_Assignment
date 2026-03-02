var builder = WebApplication.CreateBuilder(args);

//Dependency root
builder.Services.AddControllers();


var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();

