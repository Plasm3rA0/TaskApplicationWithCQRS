namespace TaskApplicationWithCQRS.Domain
{
    public class TaskItem
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }


        public TaskItem()
        {
            
        }


        public TaskItem(TaskItemDto snapshop)
        {
            Id = snapshop.Id;
            Title = snapshop.Title;
            Description = snapshop.Description;
            IsCompleted = snapshop.IsCompleted;
        }
    }
}
