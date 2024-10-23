using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/wishlist")]
    [ApiController]
    public class WishlistController : ControllerBase
    {

        public class WishListItem
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int UserId { get; set; }
            public decimal AddingPrice { get; set; }
            public DateTime AddingDate { get; set; }
        }
        
        public class AddProductRequest
        {
            public int ProductId { get; set; }
            public int UserId { get; set; }
            public decimal AddingPrice { get; set; }
        }
        public class CheckRequest
        {
            public int ProductId { get; set; }
            public int UserId { get; set; }
        }
        public class _BaseResponse<T>
        {
            public bool Success { get; set; }
            public T Data { get; set; }
        }
        private List<WishListItem> wishlist = new List<WishListItem>
        {
            new WishListItem { Id = 1, ProductId = 1, UserId = 4 , AddingDate=DateTime.Now.AddDays(-3), AddingPrice=29.99M },
            new WishListItem { Id = 2, ProductId = 23, UserId = 4,  AddingDate=DateTime.Now.AddDays(-4), AddingPrice=69.90M },
            new WishListItem { Id = 9, ProductId = 25, UserId = 4 , AddingDate=DateTime.Now.AddDays(-5), AddingPrice=148.99M },
            new WishListItem { Id = 17, ProductId = 17, UserId = 4 , AddingDate=DateTime.Now.AddDays(-6), AddingPrice=148.99M }
        };
        [HttpGet("getuserswishlistitems")]
        public IActionResult Get(int userId) {
           var response= new _BaseResponse<List<WishListItem>> { Data=wishlist, Success=true} ;
            return Ok( wishlist );
        }
        [HttpPost("checkproductinwishlist")]
        public IActionResult Check(CheckRequest request)
        {
            var response = new _BaseResponse<bool> { Data = true, Success = true };
            return Ok(response);
        }
        [HttpPost("addproducttowishlist")]
        public IActionResult Add(AddProductRequest request) {
            var response = new _BaseResponse<int> { Data=39, Success=true} ;
            return Ok(response);
        }  
        [HttpGet("removeproductfromwishlist")]
        public IActionResult Remove(int wishlistItemId) {
            var response = new _BaseResponse<bool> { Data=true, Success=true} ;
            return Ok(response);
        }  
        [HttpGet("clearuserswishlist")]
        public IActionResult Clear(int userId) {
            var response = new _BaseResponse<bool> { Data=true, Success=true} ;
            return Ok(response);
        }            
    }
}
