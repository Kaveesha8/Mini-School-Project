using System.Data.Entity;
using Application.Interfaces;
using Application.Services;
using Domain;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = new HostApplicationBuilder();

            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
            builder.Services.AddTransient<ISubjectService, SubjectService>();

            using IHost host = builder.Build();

            host.RunAsync();

            var studentService = host.Services.GetRequiredService<IStudentService>();
            var subjectService = host.Services.GetRequiredService<ISubjectService>();


            studentService.AssignSubject(new Student { Id = 4 }, new Subject { Id = 1 });


            


        }
    }
}
