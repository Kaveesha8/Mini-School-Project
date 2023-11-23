using Application;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Application.Interfaces;

/*var serviceProvider=new ServiceCollection()
    .AddDbContext<AppDbContext>(Options=>Options.UseSqlServer(ConnectionString))
    .AddScoped<IStudentRepository,StudentRepository>()
    .AddScoped<ISubjectRepository,SubjectRepository()
    .AddScoped<IStudentSubjectRepository, StudentSubjectRepository>()
    .BuildServiceProvider();*/

//Add services to the container
/*            object value = builder.Services.AddControllers();*/

//Config
/*            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ContentCreateDbContext>
                (options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("")));*/

HostApplicationBuilder builder = new HostApplicationBuilder();

builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

using IHost host = builder.Build();

await host.RunAsync();