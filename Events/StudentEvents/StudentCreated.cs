
namespace EventSourcingTut.Events.StudentEvents
{
    public class StudentCreated : Event
    {
        public required Guid StudentId { get; init; }
        public required String FullName { get; init; }
        public required String Email { get; init; } 
        public required DateTime DateOfBirth { get; init; }
        public override Guid StreamId => StudentId;
    }
}