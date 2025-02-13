using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Squiglo.Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
   
    [Required]
    [MaxLength(250)]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}
