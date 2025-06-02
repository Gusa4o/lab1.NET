using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science.Common
{
    public class CourseService
    {
        private List<Course> _course = new List<Course>();

        public void Create(Course course) => _course.Add(course);
        public List<Course> ReadAll() => _course;
        public void Update(int index, Course updatedMovie)
        {
            if (index >= 0 && index < _course.Count)
                _course[index] = updatedMovie;
        }
        public void Delete(int index)
        {
            if (index >= 0 && index < _course.Count)
                _course.RemoveAt(index);
        }
    }
}