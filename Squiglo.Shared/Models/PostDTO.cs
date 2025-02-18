namespace Squiglo.Shared.Models
{
    public class PostDTO
    {
        public long Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
