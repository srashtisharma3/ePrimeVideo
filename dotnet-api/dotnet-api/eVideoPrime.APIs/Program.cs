using eVideoPrime.APIs.Helpers;
using eVideoPrime.Models;
using eVideoPrime.Services.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//logging
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//added service dependencies
ConfigureDependencies.AddServices(builder.Services, builder.Configuration);
builder.Services.AddScoped<IFileHelper, FileHelper>();
builder.Services.Configure<RazorPayConfig>(builder.Configuration.GetSection("RazorPayConfig"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRouting();

app.MapControllers();
app.UseCors();
app.Run();
