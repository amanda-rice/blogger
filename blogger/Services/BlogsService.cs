

using System;
using System.Collections.Generic;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;
    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }
    internal List<Blog> Get()
    {
      return _repo.Get();
    }

    internal Blog Get(int id)
    {
      Blog blog = _repo.Get(id);
      if(blog ==null)
      {
        throw new Exception("Invalid ID");
      }
      return blog;
    }

    internal Blog Create(Blog newBlog)
    {
      return _repo.Create(newBlog);
    }

    internal void Delete(int blogId, string userId)
    {
      Blog blogToDelete = Get(blogId);
      if (blogToDelete.CreatorId != userId)
      {
        throw new Exception("You do NOT have permission to delete this blog");
      }
      _repo.Delete(blogId);
    }

    internal Blog Edit(Blog updatedBlog)
    {
      // Find the original before edits
      Blog original = Get(updatedBlog.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedBlog.Title = updatedBlog.Title != null ? updatedBlog.Title : original.Title;
      updatedBlog.Body = updatedBlog.Body != null ? updatedBlog.Body : original.Body;
      updatedBlog.ImgUrl = updatedBlog.ImgUrl != null ? updatedBlog.ImgUrl : original.ImgUrl;
      updatedBlog.Published = updatedBlog.PublishedWasSet ? updatedBlog.Published : original.Published;
      return _repo.Update(updatedBlog);
    }

    internal List<Blog> GetBlogsByAccountId(Account userInfo)
    {
       List<Blog> blogs = _repo.GetBlogsByProfileId(userInfo.Id);
      if(blogs ==null)
      {
        throw new Exception("Invalid ID");
      }
      return blogs;
    }

    internal List<Blog> GetBlogsByProfileId(string id)
    {
      List<Blog> blogs = _repo.GetBlogsByProfileId(id);
      if(blogs ==null)
      {
        throw new Exception("Invalid ID");
      }
      return blogs;
    }
  }
}