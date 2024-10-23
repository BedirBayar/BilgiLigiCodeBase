﻿using BilgiLigiRatingApi.DataLayer.Entities;

namespace BilgiLigiRatingApi.DataLayer.Repositories.Award_
{
    public interface IAwardRepository
    {
        Task<List<Award>> GetAll();
        Task<List<Award>> GetAllActive();
        Task<List<Award>> GetByIdList(List<int> ids);
        Task<Award> GetById(int id);
        Task<Award> GetByNameAndType(string name,string type);
        Task<int> Add(Award award);
        Task<bool> Update(Award award);
    }
}
