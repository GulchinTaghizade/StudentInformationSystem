using System;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIS.Core.Entities;
using SIS.Core.Entities.Identity;
using SIS.DataAccess.Configurations;

namespace SIS.DataAccess.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Faculty> Faculties { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<RoomCourse> RoomCourse { get; set; } = null!;
        public DbSet<GroupCourse> GroupCourses { get; set; } = null!;
        public DbSet<CourseSpeciality> CourseSpecialities { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public DbSet<TeacherCourse> TeacherCourses { get; set; } = null!;
        public DbSet<TeacherStudent> TeacherStudents { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseCofiguration).Assembly);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

