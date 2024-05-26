using EventSourcingTut.Events;
using EventSourcingTut.Events.StudentEvents;

namespace EventSourcingTut
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public List<String> EnrolledCourses { get; set; } = new List<String>();
        public DateTime DateOfBirth { get; set;}

        public void Apply(StudentCreated studentCreated)
        {
            StudentId = studentCreated.StudentId;
            FullName = studentCreated.FullName;
            Email = studentCreated.Email;
            DateOfBirth = studentCreated.DateOfBirth;
        }

        private void Apply(StudentUpdated studentUpdated)
        {
            FullName = studentUpdated.FullName;
            Email = studentUpdated.Email;
        }

        private void Apply(StudentEnrolled studentEnrolled)
        {
            if(!EnrolledCourses.Contains(studentEnrolled.CourseName))
            {
                EnrolledCourses.Add(studentEnrolled.CourseName);
            }
        }

        private void Apply(StudentUnEnrolled studentUnEnrolled)
        {
            if(EnrolledCourses.Contains(studentUnEnrolled.CourseName))
            {
                EnrolledCourses.Remove(studentUnEnrolled.CourseName);
            }
        }

        public void Apply(Event studentEvent)
        {
            switch (studentEvent)
            {
                case StudentCreated studentCreated:
                    Apply(studentCreated);
                    break;
                
                case StudentUpdated studentUpdated:
                    Apply(studentUpdated);
                    break;
                
                case StudentEnrolled studentEnrolled:
                    Apply(studentEnrolled);
                    break;
                
                case StudentUnEnrolled studentUnEnrolled:
                    Apply(studentUnEnrolled);
                    break;
            }
        }
    }
}