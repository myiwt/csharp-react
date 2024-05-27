using System.ComponentModel.DataAnnotations.Schema;


namespace api.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Comment>Comments { get; set; } = new List<Comment>();
    }
}