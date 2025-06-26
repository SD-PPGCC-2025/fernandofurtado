using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Amazon.S3;
using BXTecnologia.API.Client.AWS;
using BXTecnologia.API.Config;
using BXTecnologia.API.Config.Interfaces;
using BXTecnologia.API.Profiles;
using BXTecnologia.API.Repositories;
using BXTecnologia.API.Repositories.Interfaces;
using BXTecnologia.API.Services;
using BXTecnologia.API.Services.Interfaces;
using BXTecnologia.API.Services.Validators;
using BXTecnologia.API.Validation;
using FluentValidation;
using BXTecnologia.API.Models.Customer.DTO;

var builder = WebApplication.CreateBuilder(args);

var awsOptions = builder.Configuration.GetSection("AWS").Get<AwsConfig>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<AwsConfig>(builder.Configuration.GetSection("AWS"));
builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var credentials = new BasicAWSCredentials(awsOptions.AccessKey, awsOptions.SecretKey, awsOptions.AccountId);
    var config = new AmazonS3Config()
    {
        RegionEndpoint = RegionEndpoint.GetBySystemName(awsOptions.Region)
    };
    return new AmazonS3Client(credentials, config);
});
builder.Services.AddSingleton<IAmazonDynamoDB>(sp =>
{
    var credentials = new BasicAWSCredentials(awsOptions.AccessKey, awsOptions.SecretKey, awsOptions.AccountId);
    var config = new AmazonDynamoDBConfig
    {
        RegionEndpoint = RegionEndpoint.GetBySystemName(awsOptions.Region)
    };
    return new AmazonDynamoDBClient(credentials, config);
});
builder.Services.AddSingleton<ICustomerImageService, CustomerImageService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IEmailLayout, EmailLayout>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddAutoMapper(typeof(Profiles));

// Register validators
builder.Services.AddScoped<IValidator<CreateCustomerDTO>, CreateCustomerDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateCustomerDTOValidator>();
builder.Services.AddScoped<IValidator<IFormFile>, CustomerImageValidator>();
builder.Services
    .AddScoped<IValidator<(Guid id, string fileName, int width, int height)>, CustomerImageUpdateValidator>();
builder.Services.AddScoped<IValidator<(Guid id, string nameImage)>, CustomerImageGetValidator>();
builder.Services.AddScoped<IValidator<Guid>, CustomerImageDeleteValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.z
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistemas Distribuidos UFG API v1");
    // Set Swagger UI at the app's root
    c.RoutePrefix = string.Empty;
});

// Register exception handling middleware first in the pipeline
app.UseMiddleware<ExceptionMiddleware>();

// Only use HTTPS redirection when not in Docker
var isRunningInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
if (!isRunningInDocker)
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();