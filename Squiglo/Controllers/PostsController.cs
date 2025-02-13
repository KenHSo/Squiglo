using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Squiglo.Data;
using Squiglo.Models;

namespace Squiglo.Controllers;

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
    public IActionResult GetPosts()
    {
        var posts = _context.Posts.OrderByDescending(x => x.CreatedAt).ToList();
        return Ok(posts);
    }

    [HttpPost]
    public IActionResult CreatePosts([FromBody] Post post)
    {
        if (string.IsNullOrEmpty(post.Content) || post.Content.Length > 250)
            return BadRequest("Content is required and must be <= 250 characters.");
    
        post.CreatedAt = DateTime.Now;
        _context.Posts.Add(post);
        _context.SaveChanges();


        return CreatedAtAction(nameof(GetPosts), new {id = post.Id}, post);
    }

    


}
