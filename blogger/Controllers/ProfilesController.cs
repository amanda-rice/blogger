using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blogger.Models;
using blogger.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogger.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProfilesController : ControllerBase
    {
      private readonly ProfilesService _profilesService;
      private readonly CommentsService _commentsService;
      private readonly BlogsService _blogsService;

      public ProfilesController(ProfilesService profilesService, CommentsService commentsService, BlogsService blogsService)
      {
          _profilesService = profilesService;
          _commentsService = commentsService;
          _blogsService = blogsService;
      }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _profilesService.Get(id);
        return Ok(profile);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/{blogs}")]
     public ActionResult<List<Blog>> GetBlogsByProfileId(string id)
     {
      try
      {
        List<Blog> blogs = _blogsService.GetBlogsByProfileId(id);
        return Ok(blogs);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}/comments")]
     public ActionResult<List<Comment>> GetCommentsByProfileId(string id)
     {
      try
      {
        List<Comment> comments = _commentsService.GetCommentsByProfileId(id);
        return Ok(comments);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    }


}