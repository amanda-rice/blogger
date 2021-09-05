using System.ComponentModel.DataAnnotations;
using blogger.Models;

namespace blogger.Models
{

public class Blog
  {
  public int Id { get; set; }
  [Required]
  [MaxLength(20)]
  public string Title { get; set; }
  public string Body { get; set; }
  public string ImgUrl { get; set; }
 
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  private bool _published;
    internal bool PublishedWasSet { get; private set; }
     public bool Published
    {
      get
      {
        return _published;
      }
      set
      {
        _published = value;
        PublishedWasSet = true;
      }
    }
  }
}