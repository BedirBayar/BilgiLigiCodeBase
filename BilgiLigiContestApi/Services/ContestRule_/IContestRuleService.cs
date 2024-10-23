﻿
using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.ContestRule_
{
    public interface IContestRuleService
    {
        Task<BaseResponse<List<ContestRuleDto>>>GetAll();
        Task<BaseResponse<List<ContestRuleDto>>>GetAllActive();
        Task<BaseResponse<List<ContestRuleDto>>>GetByContestType(int cTypeId);
        Task<BaseResponse<ContestRuleDto>>GetById(int id);
        Task<BaseResponse<int>>Add(ContestRuleDto rule);
        Task<BaseResponse<bool>>Update(ContestRuleDto rule);
        Task<BaseResponse<bool>>Archive(int id);
        Task<BaseResponse<bool>>ChangeStatus(int id);
    }
}
