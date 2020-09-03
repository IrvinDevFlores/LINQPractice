using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class UniversityDataSource
    {
       public  List<Course> courses;
       public   List<Student> students;
        public List<Student> GetStudents()
        {
            return students = new List<Student> {
               new Student {IdCourse = "1BTC", Name = "Josue", LastName = "Aleman", Id = 111,
               Scores = new List<int> { 90, 92, 81,60} },
               new Student {IdCourse = "2BTC", Name = "Vinicio", LastName = "Watters", Id = 112,
               Scores = new List<int> { 88, 84, 94,40} },
               new Student {IdCourse = "2BTC", Name = "Carlos", LastName = "Perez", Id = 113,
               Scores = new List<int> { 17, 94, 65,91} },
               new Student {IdCourse = "1BTC", Name = "Jose", LastName = "Garcia", Id = 114,
               Scores = new List<int> { 97, 89, 85,68} },
               new Student {IdCourse = "3BTC", Name = "Ana", LastName = "Garcia", Id = 115,
               Scores = new List<int> { 93, 98, 92,68} },
               new Student {IdCourse = "1BTC", Name = "Franco", LastName = "Medina", Id = 116,
               Scores = new List<int> { 99, 100, 99,90} },
               new Student {IdCourse = "2BTC", Name = "Alexis", LastName = "Rubio", Id = 117,
               Scores = new List<int> { 88, 90, 76,67} },
               new Student {IdCourse = "2BTC", Name = "David", LastName = "Garcia", Id = 118,
               Scores = new List<int> { 45, 89, 82,19} },
               new Student {IdCourse = "1BTC", Name = "Hugo", LastName = "Lopez", Id = 119,
               Scores = new List<int> { 45, 90, 69,85} },
               new Student {IdCourse = "3BTC", Name = "Alonso", LastName = "Garcia", Id = 120,
               Scores = new List<int> { 97, 84, 100,78} },
               new Student {IdCourse = "1BTC", Name = "Marco", LastName = "Lopez", Id = 121,
               Scores = new List<int> { 99, 85, 94,91} },
               new Student {IdCourse = "3BTC", Name = "Tulio", LastName = "Meza", Id = 122,
               Scores = new List<int> { 64, 96, 92,80} }
            };
        }
        public List<Course> GetCourses()
        {
            return courses = new List<Course>
            {
               new Course {IdCourse = "1BTC" , CourseName = "Primero Computacion" },
               new Course {IdCourse = "2BTC", CourseName = "Segundo Computacion" },
               new Course {IdCourse = "3BTC", CourseName = "Tercero Computacion" },
               new Course {IdCourse = "4BTC", CourseName = "Cuarto Computacion" }
            };

        }
    }
}
