using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class EnrollmentCourseGroup
    {
        public int? EnrollmentCourse { get; set; }

        public int StudentCount { get; set; }
    }
}