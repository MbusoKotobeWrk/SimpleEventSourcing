namespace EventSourcingTut.Events.StudentEvents
{
    public class StudentEnrolled : Event
    {
        public required Guid StudentId { get; init; }
        public required String CourseName { get; init;}
        public override Guid StreamId => StudentId;
    }
}