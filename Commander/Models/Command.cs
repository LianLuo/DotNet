namespace Commander.Models
{
    public class Command : BaseEntity
    {
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}