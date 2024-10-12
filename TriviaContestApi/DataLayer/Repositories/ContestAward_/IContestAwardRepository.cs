﻿using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.ContestAward_
{
    public interface IContestAwardRepository
    {
        Task<List<ContestAward>> GetAll();
        Task<ContestAward> GetById(int id);
        Task<ContestAward> GetByName(string name);
        Task<bool> Update(ContestAward award);
        Task<int> Add(ContestAward award);
    }
}
