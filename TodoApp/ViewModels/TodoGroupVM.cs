namespace TodoApp.ViewModels
{
    public class TodoGroupVM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int TotalCount { get; internal set; }
        public int CompletedCount { get; internal set; }
        public string Color { get; set; }
    }
}
