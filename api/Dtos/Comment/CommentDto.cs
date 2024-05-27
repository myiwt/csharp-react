namespace api.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public int? TopicId { get; set; }
    }
}