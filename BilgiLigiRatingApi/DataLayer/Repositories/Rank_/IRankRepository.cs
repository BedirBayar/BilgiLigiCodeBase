﻿using BilgiLigiRatingApi.DataLayer.Entities;

namespace BilgiLigiRatingApi.DataLayer.Repositories.Rank_
{
    public interface IRankRepository
    {
        Task<List<Rank>> GetAll();
        Task<List<Rank>> GetAllActive();
        Task<List<Rank>> GetAllUser();
        Task<List<Rank>> GetAllTeam();
        Task<Rank> GetById(int id); 
        Task<Rank> GetByDegreeAndType(int degree, string type);
        Task<List<Rank>> GetByDegree(int degree);
        Task<int> Add(Rank rank);
        Task<bool> Update(Rank rank);
        
    }
}
