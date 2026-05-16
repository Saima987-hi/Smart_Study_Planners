// FILE: Smart_Study_Planner/Models/Models.cs
// REPLACE your entire Models.cs with this

namespace Smart_Study_Planner.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public int XpPoints { get; set; } = 0;
        public int StreakDays { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool DarkTheme { get; set; } = false;
        public bool SmartScheduler { get; set; } = true;
        public bool NearExamPriority { get; set; } = true;
        public bool NotifyStudyTime { get; set; } = true;
        public bool NotifyEmail { get; set; } = false;

        public List<StudyTask> Tasks { get; set; } = new();
        public List<Subject> Subjects { get; set; } = new();
        public List<Exam> Exams { get; set; } = new();
        public List<PomodoroSession> PomodoroSessions { get; set; } = new();
        public List<StudyLog> StudyLogs { get; set; } = new();
        // ✅ NEW: Notes aur Calendar
        public List<Note> Notes { get; set; } = new();
        public List<CalendarEvent> CalendarEvents { get; set; } = new();
    }

    public class StudyTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string Priority { get; set; } = "Low"; // High, Medium, Low
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User? User { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public int WeaknessPercent { get; set; } = 50;
        public User? User { get; set; }
        public List<ScheduleEntry> ScheduleEntries { get; set; } = new();
    }

    public class Exam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SubjectName { get; set; } = "";
        public string CourseName { get; set; } = "";
        public DateTime ExamDate { get; set; }
        public User? User { get; set; }
    }

    public class ScheduleEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? SubjectId { get; set; }
        public string Title { get; set; } = "";
        public string DayOfWeek { get; set; } = "";
        public string TimeSlot { get; set; } = "";
        public bool IsAiSuggested { get; set; } = false;
        public Subject? Subject { get; set; }
    }

    public class PomodoroSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DurationMinutes { get; set; } = 25;
        public DateTime StartedAt { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; } = false;
        public User? User { get; set; }
    }

    public class StudyLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double HoursStudied { get; set; }
        public User? User { get; set; }
    }

    // ✅ NEW MODEL: Notes
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string? SubjectName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User? User { get; set; }
    }

    // ✅ NEW MODEL: Calendar Events
    public class CalendarEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public DateTime EventDate { get; set; }
        public string EventType { get; set; } = "Study"; // Exam, Assignment, Study, Revision, Other
        public User? User { get; set; }
    }
}
