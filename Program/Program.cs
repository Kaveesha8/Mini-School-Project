using Application.Interfaces;
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

            using IHost host = builder.Build();

            host.RunAsync();

            // Resolve the repositories from the dependency injection container
            var studentRepository = host.Services.GetRequiredService<IStudentRepository>();
            // var subjectRepository = host.Services.GetRequiredService<ISubjectRepository>();



            // Create a list of students
            /*            var students = new List<Student>
                        {
                            new Student { Id = 1, Name = "Kaveesha", Age = 24, Date = new DateTime(2023, 11, 13), Address = "Jaela" },
                            new Student { Id = 2, Name = "Sanuja", Age = 25, Date = new DateTime(2023, 7, 15), Address = "Ambalangoda" }
                        };

                        // Add each student to the StudentRepository
                        foreach (var student in students)
                        {
                            studentRepository.AddStudent(student);
                        }*/

            var student = new Student { Id = 1, Name = "Kaveesha", Age = 24, Date = new DateTime(2023, 11, 13), Address = "Jaela", Subjects= new List<Subject>() };
            studentRepository.AddStudent(student);















            /* try
             {
                 using var context = new AppDbContext();

                 var students = new List<Student>
                 {
                     new Student { Id = 1, Name = "Kaveesha", Age = 24, Date = new DateTime(2023, 11, 13), Address = "Jaela" },

                     new Student { Id = 2, Name = "Sanuja", Age = 25, Date = new DateTime(2023, 7, 15), Address = "Ambalangoda" }
                 };

                 var subject = new Subject() { Id = 1, Name = "Maths", Students = students };

                 context.Subjects.Add(subject);

                 context.SaveChanges();

                 Console.WriteLine("Students and Subjects added");
                 Console.ReadKey();




             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error: {ex.Message}"); ;
             }*/



        }
    }
}
