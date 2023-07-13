using EasyCashIdentity.DTOLayer.DTOS.AppUserDTos;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{

    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO appUserEditDTO= new AppUserEditDTO();
            appUserEditDTO.Name =value.Name;
            appUserEditDTO.Surname =value.Surname;
            appUserEditDTO.PhoneNumber=value.PhoneNumber;
            appUserEditDTO.Email=value.Email;
            appUserEditDTO.City=value.City;
            appUserEditDTO.District=value.District;
            appUserEditDTO.ImageUrl=value.ImageUrl;
            return View();
        }
        //[HttpPost]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
