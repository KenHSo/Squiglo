using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Squiglo.API.Data;
using Squiglo.API.Mappers;
using Squiglo.Shared.Models;

namespace Squiglo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PostDTO>> GetPosts()
    {
        return Ok(_context.Posts
            .OrderByDescending(post => post.CreatedAt)
            .Select(PostMapper.ToDTO)
            .ToList());
    }

    [HttpPost]
    public IActionResult CreatePosts([FromBody] PostDTO postDTO)
    {
        if (string.IsNullOrEmpty(postDTO.Content) || postDTO.Content.Length > 250)
            return BadRequest("Content is required and must be <= 250 characters.");


        var post = PostMapper.ToModel(postDTO);

        _context.Posts.Add(post);
        _context.SaveChanges();


        return CreatedAtAction(nameof(GetPosts), new { id = postDTO.Id }, PostMapper.ToDTO(post));
    }




}
