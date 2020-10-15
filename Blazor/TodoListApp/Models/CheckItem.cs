namespace TodoListApp.Models
{
    public class CheckItem
    {
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public string CheckedClass
        {
            get
            {
                return IsChecked ? "fa-check-circle-o" : "fa-circle-thin";
            }
        }
    }
}