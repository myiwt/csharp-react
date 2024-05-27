namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public int? TopicId { get; set; }

        // Navigation property is used to navigate within the model
        // i.e. you can go Comment.Topic.Company to get the company name from a commen
        public Topic? Topic { get; set; }
    }
}