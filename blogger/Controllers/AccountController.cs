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
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly CommentsService _commentsService;
        private readonly BlogsService _blogsService;

        public AccountController(AccountService accountService, CommentsService commentsService, BlogsService blogsService)
        {
            _accountService = accountService;
            _commentsService = commentsService;
            _blogsService = blogsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    [HttpGet("blogs")]
     public async Task<ActionResult<List<Blog>>> GetBlogsByAccountId()
     {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Blog> blogs = _blogsService.GetBlogsByAccountId(userInfo);
        return Ok(blogs);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("comments")]
     public async Task<ActionResult<List<Comment>>> GetCommentsByAccountId()
     {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Comment> comments = _commentsService.GetCommentsByAccountId(userInfo);
        return Ok(comments);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPut]
     [Authorize]
    public async Task<ActionResult<Account>> Edit([FromBody] Account updatedAccount)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedAccount.Id = userInfo.Id;
        Account account = _accountService.Edit(updatedAccount);
        return Ok(account);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
}


}