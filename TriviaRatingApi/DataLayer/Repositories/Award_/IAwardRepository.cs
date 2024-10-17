using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Award_
{
    public interface IAwardRepository
    {
        Task<List<Award>> GetAll();
        Task<List<Award>> GetByIdList(List<int> ids);
        Task<Award> GetById(int id);
        Task<int> Add(Award award);
        Task<bool> Update(Award award);
    }
}
