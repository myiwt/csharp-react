using api.Dtos.Comment;

namespace api.Dtos.Topic
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<CommentDto> Comments { get; set; }
    }
}