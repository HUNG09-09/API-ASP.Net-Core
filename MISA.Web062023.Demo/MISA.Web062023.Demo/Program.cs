using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MISA.Web062023.Demo.Application;
using MISA.Web062023.Demo.Application.Service;
using MISA.Web062023.Demo.Domain;
using MISA.Web062023.Demo.Infrastructure;
using MISA.Web062023.Demo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values.SelectMany(x => x.Errors);
        return new BadRequestObjectResult(new BaseException()
        {
            ErrorCode = 400,
            UserMessage = "Lỗi nhập từ người dùng",
            DevMessage = "Lỗi nhập từ người dùng",
            TraceId = "",
            MoreInfo = "",
            Error = errors
        }.ToString() ?? "");
    };
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(connectionString));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
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

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
