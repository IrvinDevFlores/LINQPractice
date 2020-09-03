using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public  class MethodsRepository 
    {
        public UniversityDataSource dataContext;  
        public  delegate void methodControler();

        public  Dictionary<int, methodControler> addedRepositoryMethods;

        public MethodsRepository()
        {
            dataContext = new UniversityDataSource();
            addedRepositoryMethods = new Dictionary<int, methodControler>();
            AddMethodsToRepository();
        }

        public void AddMethodsToRepository() {
            addedRepositoryMethods.Add(1, GetStudentsWithScoreAboveNinety);
            addedRepositoryMethods.Add(2, GetStudentsWithScoreAboveNinetyAndUnderEighty);
            addedRepositoryMethods.Add(3, GetStudentsLastNameAscending);
            addedRepositoryMethods.Add(4, GetStudentsLasNameDescending);
            addedRepositoryMethods.Add(5, GroupStudentsByLasNameKey);
            addedRepositoryMethods.Add(6, SumAllStudentsScores);
            addedRepositoryMethods.Add(7, CalulateAverageOfAllStudents);
            addedRepositoryMethods.Add(8, FilterByLastName);
            addedRepositoryMethods.Add(9, ShowStudentsWithGlobalScoreAboveSumOfAllClassAverage);
            addedRepositoryMethods.Add(10, GenerateScoreListOfStudents);
            addedRepositoryMethods.Add(11, GenerateStudentsListWithTheirCourseInformation);
            addedRepositoryMethods.Add(12, GroupStudentsByKeyCourse);
        }

        public  void GetStudentsWithScoreAboveNinety()
        {
            IEnumerable<Student> scoresAboveNinety = from student in dataContext.GetStudents()
                                                          where student.Scores.First() > 90
                                                          select student;

            foreach (Student student in scoresAboveNinety)
            {
                Console.WriteLine($"Alumno:{student.Name} , Nota: {student.Scores.First()} \n");
            }

            Console.WriteLine("\n \n");
        }

        public void GetStudentsWithScoreAboveNinetyAndUnderEighty()
        {
            var scoresAboveNinetyAndUnderEighty = dataContext.GetStudents()
                .Where(student => student.Scores.First() > 90 && student.Scores.Last() < 80).ToList();

            foreach (var student in scoresAboveNinetyAndUnderEighty)
            {
                Console.WriteLine($"Alumno:{student.Name} , Nota: {student.Scores[0]} \n");
            }
            Console.WriteLine("\n \n");
        }

        public void GetStudentsLastNameAscending()
        {
            var orderLasNameAscending = from LastName in dataContext.GetStudents()
                                             orderby LastName.LastName ascending
                                             select LastName;

            foreach (var student in orderLasNameAscending)
            {

                Console.WriteLine($"Alumno:{student.LastName} \n");

            }

            Console.WriteLine("\n \n");
        }

        public void GetStudentsLasNameDescending()
        {
            var orderLastNameDescending = from LastName in dataContext.GetStudents()
                                              orderby LastName.LastName descending
                                              select LastName;
            foreach (var student in orderLastNameDescending)
            {

                Console.WriteLine($"Alumno:{student.LastName}\n");
            }

            Console.WriteLine("\n \n");
        }

        public void GroupStudentsByLasNameKey()
        {
            var groupByLastNameKey =
            from student in dataContext.GetStudents()
            group student by student.LastName[0] into firstLetterGroup
            orderby firstLetterGroup.Key
            select firstLetterGroup;

            foreach (var keyStudentsGroup in groupByLastNameKey)
            {

                Console.WriteLine($"Inicial: {keyStudentsGroup.Key}");
                foreach (var groupedStudent in keyStudentsGroup)
                    Console.WriteLine($"{groupedStudent.Name} \n ---------------");

            }

        }

        public void SumAllStudentsScores()
        {
            var sumAllScores =
                from student in dataContext.GetStudents()
                select student.Scores.Sum();

            foreach (var student in sumAllScores)
                Console.WriteLine($"{student}");

        }

        public void CalulateAverageOfAllStudents()
        {
            var averageCalculated = dataContext.GetStudents().Select( student => student.Scores.Sum()).Average();

            double average = averageCalculated;
            Console.WriteLine($"Promedio: {average}");
   
        }

        public void FilterByLastName()
        {
            string name = "Lopez";
            var filterExplicitLastName =
                from student in dataContext.GetStudents()
                where student.LastName.Equals(name)
                select student;

            foreach (var student in filterExplicitLastName)
            {
                Console.WriteLine($" {student.Name}");
                foreach (var puntuacion in student.Scores)
                {
                    Console.WriteLine($" {puntuacion}");
                }
            }

        }

        public void ShowStudentsWithGlobalScoreAboveSumOfAllClassAverage()
        {
            var scoresSumed =
                from student in dataContext.GetStudents()
                select student.Scores.Sum();

            double generalAverage = scoresSumed.Average();

            var addAverageToStudent =
                from student in dataContext.GetStudents()
                select new
                {
                    Id = student.Id,
                    Average = student.Scores.Sum()
                };

            var studentWithAverageAboveGeneralAverage =
                from student in addAverageToStudent
                orderby student.Average descending
                where student.Average > generalAverage
                select new
                {
                    Id = student.Id,
                    Nota = student.Average
                };

            Console.WriteLine($"Promedio general de la clase es:{generalAverage} ");
            foreach (var student in studentWithAverageAboveGeneralAverage)
                Console.WriteLine($"student Id: {student.Id} , Nota: {student.Nota}");
        }

        public void GenerateScoreListOfStudents()
        {
            IEnumerable<Scores> myScores =
                from student in dataContext.GetStudents()
                select new Scores
                {
                    FinalScore = student.Scores.Sum(),
                    StudentName = student.Name
                };

            foreach (var score in myScores)
            {
                Console.WriteLine($"student: {score.StudentName} , Nota: {score.FinalScore}");
            }
        }

        public void GenerateStudentsListWithTheirCourseInformation()
        {
            var studentsInACourse =
                from student in dataContext.GetStudents()
                join course in dataContext.GetCourses() on student.IdCourse equals course.IdCourse
                select new
                {
                    Id = student.Id,
                    Name = student.Name,
                    LastName = student.LastName,
                    Average = student.Scores.Average(),
                    IdCourse = student.IdCourse,
                    CourseName = course.CourseName
                };

            foreach (var student in studentsInACourse)
                Console.WriteLine($"Id: {student.Id} \n Name: {student.Name} \n LastName: {student.LastName} \n" +
                    $"Promedio notas: {student.Average} \n Curso: {student.IdCourse} - {student.CourseName} \n --------------------");
        }
 
        public void GroupStudentsByKeyCourse()
        {
            var enrolled =
                from course in dataContext.GetCourses()
                join student in dataContext.GetStudents() on course.IdCourse equals student.IdCourse
                select student;

            var groupCourses =
                from grupo in enrolled
                group grupo by grupo.IdCourse;

            foreach (var course in groupCourses)
            {
                Console.WriteLine($"{course.Key}  ");
                foreach (Student alum in course)
                {
                    Console.WriteLine($"{alum.Name}");
                }
                Console.WriteLine($"\n");
            }

        }
    }
}
