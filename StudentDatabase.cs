using EventSourcingTut.Events;

namespace EventSourcingTut
{
    public class StudentDatabase
    {
        private readonly Dictionary<Guid, SortedList<DateTime, Event>> _studentEvents = 
            new ();
            private readonly Dictionary<Guid, Student> _students = new ();

        public void Append(Event @event)
        {
            var stream = _studentEvents.GetValueOrDefault(@event.StreamId, null);
            if(stream is null)
            {
                _studentEvents[@event.StreamId] = new SortedList<DateTime, Event>();
            }
            @event.CreatedAtUtc = DateTime.UtcNow;
            _studentEvents[@event.StreamId].Add(@event.CreatedAtUtc, @event);

            _students[@event.StreamId] = GetStudent(@event.StreamId);
        }

        public Student GetStudent(Guid userId)
        {
            if(!_studentEvents.ContainsKey(userId))
            {
                return null;
            }
            var student = new Student();
            var studentEvent = _studentEvents[userId];
            foreach (var studentItem in studentEvent)
            {
                student.Apply(studentItem.Value);
            }
            return student;
        }

        public Student? GetStudentView(Guid studentId)
        {
            return _students!.GetValueOrDefault(studentId, null);
        }
    }
}