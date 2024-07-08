using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsfeedAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NewsfeedDbContext>(
             dbContextOptionsBuilder =>
             {
                 var connection = "server=localhost;port=3306;database=newsfeed-test;user=root;password=123456";
                 dbContextOptionsBuilder.UseMySQL(connection, mySqlOptionsAction =>
                 {
                     mySqlOptionsAction.EnableRetryOnFailure(3);
                     mySqlOptionsAction.CommandTimeout(60);
                 });       
                 dbContextOptionsBuilder.EnableSensitiveDataLogging(true);
             }
     );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<NewsfeedDbContext>();
        dbContext.Database.Migrate();
    }
}
catch(Exception)
{

}


app.UseAuthorization();

app.MapControllers();

app.Run();
