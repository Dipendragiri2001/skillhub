using System;

namespace SkillHub.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string AboutCourse { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public string Duration { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }

    }
}