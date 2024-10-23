﻿using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionDifficulty_
{
    public interface IQuestionDifficultyRepository
    {
        Task<List<QuestionDifficulty>> GetAll();
        Task<List<QuestionDifficulty>> GetByQuestion(int questionId);
        Task<List<QuestionDifficulty>> GetByUser(int userId);
        Task<QuestionDifficulty> GetById(int id);
        Task<QuestionDifficulty> GetByUserAndQuestion(int userId, int questionId);
        Task<int> Add(QuestionDifficulty qu);
        Task<bool> Update(QuestionDifficulty qu);
        Task<bool> Delete(QuestionDifficulty qu);
    }
}
