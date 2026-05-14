namespace Smart_Study_Planner.Models;
using global::SmartStudyPlanner.Models;
using Microsoft.EntityFrameworkCore;
using SmartStudyPlanner.Data;
using SmartStudyPlanner.Models;

namespace SmartStudyPlanner.Service
{
    public class AuthService
    {
        private readonly AppDbContext _db;
        public User? CurrentUser { get; private set; }

        public event Action? OnAuthChanged;

        public AuthService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<(bool Success, string Message)> LoginAsync(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return (false, "Email not found.");
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return (false, "Incorrect password.");
            CurrentUser = user;
            OnAuthChanged?.Invoke();
            return (true, "Login successful.");
        }

        public async Task<(bool Success, string Message)> RegisterAsync(string name, string email, string password)
        {
            if (await _db.Users.AnyAsync(u => u.Email == email))
                return (false, "Email already registered.");
            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            // Seed sample data
            await SeedSampleDataAsync(user.Id);

            CurrentUser = user;
            OnAuthChanged?.Invoke();
            return (true, "Registration successful.");
        }

        public void Logout()
        {
            CurrentUser = null;
            OnAuthChanged?.Invoke();
        }

        public bool IsLoggedIn => CurrentUser != null;

        private async Task SeedSampleDataAsync(int userId)
        {
            // Seed subjects
            var subjects = new List<Subject>
            {
                new() { UserId = userId, Name = "Math", WeaknessPercent = 68 },
                new() { UserId = userId, Name = "Physics", WeaknessPercent = 70 },
                new() { UserId = userId, Name = "OOP", WeaknessPercent = 55 },
                new() { UserId = userId, Name = "Networking", WeaknessPercent = 45 }
            };
            _db.Subjects.AddRange(subjects);
            await _db.SaveChangesAsync();

            // Seed tasks
            var tasks = new List<StudyTask>
            {
                new() { UserId = userId, Title = "Linear algebra tasks", IsCompleted = true, Priority = "High" },
                new() { UserId = userId, Title = "Planning day checklist", IsCompleted = true, Priority = "Medium" },
                new() { UserId = userId, Title = "Calorer study ontlight", IsCompleted = false, Priority = "Low" },
                new() { UserId = userId, Title = "Scract predite tasklist", IsCompleted = false, Priority = "Low" }
            };
            _db.StudyTasks.AddRange(tasks);

            // Seed exams
            var exams = new List<Exam>
            {
                new() { UserId = userId, SubjectName = "OOP", CourseName = "Comper 2023", ExamDate = DateTime.Now.AddDays(2) },
                new() { UserId = userId, SubjectName = "Networking", CourseName = "Comper 2023", ExamDate = DateTime.Now.AddDays(7) }
            };
            _db.Exams.AddRange(exams);

            // Seed study logs
            var today = DateTime.Today;
            var logs = new List<StudyLog>
            {
                new() { UserId = userId, Date = today.AddDays(-6), HoursStudied = 5 },
                new() { UserId = userId, Date = today.AddDays(-5), HoursStudied = 7 },
                new() { UserId = userId, Date = today.AddDays(-4), HoursStudied = 9 },
                new() { UserId = userId, Date = today.AddDays(-3), HoursStudied = 6 },
                new() { UserId = userId, Date = today.AddDays(-2), HoursStudied = 8 },
                new() { UserId = userId, Date = today.AddDays(-1), HoursStudied = 7 },
                new() { UserId = userId, Date = today, HoursStudied = 4 }
            };
            _db.StudyLogs.AddRange(logs);

            await _db.SaveChangesAsync();
        }
    }
}
