using Squiglo.Shared.Models;
using Squiglo.API.Models;

namespace Squiglo.API.Mappers;

public static class PostMapper
{
    public static PostDTO ToDTO(Post post)
    {
        return new PostDTO
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt
        };
    }

    public static Post ToModel(PostDTO postDTO)
    {
        return new Post
        {
            Content = postDTO.Content,
            CreatedAt = DateTime.UtcNow
        };
    }
}

