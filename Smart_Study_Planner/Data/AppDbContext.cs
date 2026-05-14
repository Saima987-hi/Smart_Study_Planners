using Microsoft.EntityFrameworkCore;
using Smart_Study_Planner.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Smart_Study_Planner.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<User> Users => Set<User>();
        public DbSet<StudyTask> StudyTasks => Set<StudyTask>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ScheduleEntry> ScheduleEntries => Set<ScheduleEntry>();
        public DbSet<PomodoroSession> PomodoroSessions => Set<PomodoroSession>();
        public DbSet<StudyLog> StudyLogs => Set<StudyLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
