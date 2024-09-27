﻿using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.LeaderBoard_
{
    public interface ILeaderBoardRepository
    {
        Task<List<LeaderBoard>> GetAll();
        Task<List<LeaderBoard>> GetAllIncomplete();
        Task<LeaderBoard> GetById(int id);
        Task<int> Add(LeaderBoard board);
        Task<bool> Update(LeaderBoard board);

    }
}
