

using System;
using System.Collections.Generic;
using blogger.Models;
using blogger.Repositories;

namespace blogger.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal Profile Get(string id)
    {
      Profile profile = _repo.Get(id);
      if(profile ==null)
      {
        throw new Exception("Invalid ID");
      }
      return profile;
    }
  }
}