namespace TaskApplicationWithCQRS.Infrastructure.Exceptions
{
    public class TaskItemNotFoundException : Exception
    {
        public TaskItemNotFoundException() : base("Task item not found") { }

        public TaskItemNotFoundException(string message) : base(message) { }

        public TaskItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
