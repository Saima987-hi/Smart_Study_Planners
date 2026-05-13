namespace Smart_Study_Planner.Models;
using global::SmartStudyPlanner.Models;
using Microsoft.EntityFrameworkCore;
using SmartStudyPlanner.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SmartStudyPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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