
using BilgiLigiContestApi.DTOs;
namespace BilgiLigiContestApi.Services.Category_
{
    public interface ICategoryService
    {
        Task<BaseResponse<List<CategoryDto>>> GetAll();
        Task<BaseResponse<List<CategoryDto>>> GetAllActive();
        Task<BaseResponse<CategoryDto>> GetById(int id);
        Task<BaseResponse<CategoryDto>> GetByName(string name);
        Task<BaseResponse<int>> Add(CategoryDto cat);
        Task<BaseResponse<bool>>Update(CategoryDto cat);
        Task<BaseResponse<bool>>Archive(int id);
        Task<BaseResponse<bool>>ArchiveByName(string name);
        Task<BaseResponse<bool>> ChangeStatus(int id);
    }
}
