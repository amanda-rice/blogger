using System.ComponentModel.DataAnnotations;
using blogger.Models;

namespace blogger.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    [Required]
    [MaxLength(240)]
    public string Body { get; set; }
    [Required]
    public int Blog { get; set; }
    public Profile Creator { get; set; }
  }
}