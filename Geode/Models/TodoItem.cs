namespace Geode.Models
{
    public class TodoItem
    {
        static int instanceNum = 0;
        public string Name { get; set; }
        public TodoItem()
        {
            this.Name = "To-do Item #" + (instanceNum++);
        }
    }
}
