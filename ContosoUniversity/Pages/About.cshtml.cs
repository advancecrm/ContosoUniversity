using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.Data;

namespace ContosoUniversity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        //public IList<EnrollmentDateGroup> Student { get; set; }
        public IList<EnrollmentCourseGroup> Enrollment { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentCourseGroup> data =
                from enrollment in _context.Enrollment
                group enrollment by enrollment.CourseID into courseGroup
                select new EnrollmentCourseGroup()
                {
                    EnrollmentCourse = courseGroup.Key,
                    StudentCount = courseGroup.Count()

                    //from student in _context.Student
                    //group student by student.EnrollmentDate into dateGroup
                    //select new EnrollmentDateGroup()
                    //{
                    //    EnrollmentDate = dateGroup.Key,
                    //    StudentCount = dateGroup.Count()
                    //
                };

             //Student = await data.AsNoTracking().ToListAsync();
            Enrollment = await data.AsNoTracking().ToListAsync();
        }
    }
}