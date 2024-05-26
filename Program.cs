using EventSourcingTut;
using EventSourcingTut.Events.StudentEvents;

var studentDatabase = new StudentDatabase();

//Create a new student, keep the event.
var studentId = Guid.NewGuid();

var studentCreated = new StudentCreated
{
    StudentId = studentId,
    Email = "mbuso.kotobe@gmail.com",
    FullName = "Mbuso Kotobe",
    DateOfBirth = new DateTime(1992, 1, 1),
    CreatedAtUtc = DateTime.Now
};

studentDatabase.Append(studentCreated);

//Enroll the student to a course.

var studentEnrolled = new StudentEnrolled
{
    StudentId = studentId,
    CourseName = ".NET Senior Training",
    CreatedAtUtc = DateTime.Now
};

studentDatabase.Append(studentEnrolled);

//Update the student's email.

var studentUpdated = new StudentUpdated
{
    StudentId = studentId,
    FullName = "Mbuso Kotobe",
    Email = "mbusokotobedevsand@gmail.com",
    CreatedAtUtc = DateTime.Now,
};

studentDatabase.Append(studentUpdated);

Student student = studentDatabase.GetStudent(studentId);
Student studentFromView = studentDatabase.GetStudentView(studentId);
Console.ReadLine();