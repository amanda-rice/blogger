

using System;
using System.Collections.Generic;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;
    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }
    internal List<Comment> Get()
    {
      return _repo.Get();
    }

    internal Comment Get(int id)
    {
      Comment comment = _repo.Get(id);
      if(comment ==null)
      {
        throw new Exception("Invalid ID");
      }
      return comment;
    }

    internal Comment Create(Comment newComment)
    {
      return _repo.Create(newComment);
    }

    internal void Delete(int commentId, string userId)
    {
      Comment commentToDelete = Get(commentId);
      if (commentToDelete.CreatorId != userId)
      {
        throw new Exception("You do NOT have permission to delete this comment");
      }
      _repo.Delete(commentId);
    }

    internal Comment Edit(Comment updatedComment)
    {
      Comment original = Get(updatedComment.Id);
      updatedComment.Body = updatedComment.Body != null ? updatedComment.Body : original.Body;
      return _repo.Update(updatedComment);
    }

    internal List<Comment> GetCommentsByBlogId(int id)
    {
      List<Comment> comments = _repo.GetCommentsByBlogId(id);
      if(comments ==null)
      {
        throw new Exception("Invalid ID");
      }
      return comments;
    }

    internal List<Comment> GetCommentsByProfileId(string id)
    {
      List<Comment> comments = _repo.GetCommentsByProfileId(id);
      if(comments ==null)
      {
        throw new Exception("Invalid ID");
      }
      return comments;
    }

    internal List<Comment> GetCommentsByAccountId(Account userInfo)
    {
      List<Comment> comments = _repo.GetCommentsByProfileId(userInfo.Id);
      if(comments ==null)
      {
        throw new Exception("Invalid ID");
      }
      return comments;
    }
  }
}