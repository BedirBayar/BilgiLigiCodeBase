using AutoMapper;
using BilgiLigiContributionApi.DTOs;

namespace BilgiLigiContributionApi.Services
{
    public class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly AuthenticatedUserService _aus;
        public BaseService(IMapper mapper, AuthenticatedUserService aus) { 
            _mapper = mapper;
            _aus = aus;
        }

        protected ErrorResponse Get404(string? message="")
        {
            string defaultMessage = "Veri bulunamadı";
            return new ErrorResponse
            {
                Code = "404",
                Message = string.IsNullOrEmpty(message) ? defaultMessage : message,
            };
        }
        protected ErrorResponse Get400(string? message="")
        {
            string defaultMessage = "Geçersiz istek";
            return new ErrorResponse
            {
                Code = "400",
                Message = string.IsNullOrEmpty(message) ? defaultMessage : message,
            };
        }
        protected ErrorResponse Get500(string? message = "")
        {
            string defaultMessage = "İşlem gerçekleştirilirken bir hata oluştu";
            return new ErrorResponse
            {
                Code = "400",
                Message = string.IsNullOrEmpty(message) ? defaultMessage : message,
            };
        }
    }
}
