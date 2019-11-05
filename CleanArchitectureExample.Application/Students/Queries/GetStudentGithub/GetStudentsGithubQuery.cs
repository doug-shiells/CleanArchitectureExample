using System.Collections.Generic;
using CleanArchitectureExample.Application.CQRS;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentGithub
{
    public class GetStudentsGithubQuery : IQuery<List<StudentGithubDto>>
    {
        public int CourseId { get; }

        public GetStudentsGithubQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
