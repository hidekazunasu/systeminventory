using systeminventory_sample.Models.DbFirst;
using Microsoft.EntityFrameworkCore;
using systeminventory_sample.Models.DbFirst;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<inHouseDbContext>(options =>
{
    var path = builder.Configuration.GetConnectionString("inHouseDbConnection");
    options.UseSqlite(path);
});

builder.Services.AddControllers();
// Add services to the container.
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

app.UseStaticFiles();
app.UseRouting();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
app.UseEndpoints(x => x.MapControllers());


app.Run();
