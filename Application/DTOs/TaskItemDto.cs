namespace TaskApplicationWithCQRS.Domain
{
    public class TaskItemDto
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }


        public TaskItemDto()
        {
            
        }


        public TaskItemDto(TaskItem taskItem)
        {
            Id = taskItem.Id;
            Title = taskItem.Title;
            Description = taskItem.Description;
            IsCompleted = taskItem.IsCompleted;
        }
    }
}
