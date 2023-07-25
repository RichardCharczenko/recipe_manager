using Microsoft.EntityFrameworkCore;
using recipeAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;

var CORSAllowedOrigins = "_CORSAllowedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSAllowedOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

// AWS Profile information
AWSOptions options = builder.Configuration.GetAWSOptions();

// AWS credential configuration
builder.Services.AddDefaultAWSOptions(options);


builder.Services.AddControllers();
builder.Services.AddDbContext<RecipeContext>(opt => opt.UseInMemoryDatabase("RecipeList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();