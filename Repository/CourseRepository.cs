using Microsoft.EntityFrameworkCore;
using SkillHub.Data;
using SkillHub.GenericRepository;
using SkillHub.Models;

namespace SkillHub.Repository
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context)
            : base(context)
            {

            }
    }

   
}

   