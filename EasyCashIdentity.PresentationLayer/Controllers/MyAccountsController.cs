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
            return View(appUserEditDTO);
        }

        [HttpPost]
        public async Task< IActionResult> Index(AppUserEditDTO appUserEditDTO)
        {
            if (appUserEditDTO.Password == appUserEditDTO.ConfirmPassword)
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = appUserEditDTO.PhoneNumber;
                user.Surname = appUserEditDTO.Surname;
                user.City = appUserEditDTO.City;
                user.District = appUserEditDTO.District;
                user.PhoneNumber=appUserEditDTO.PhoneNumber;
                user.Surname=appUserEditDTO.Surname;
                user.Name = appUserEditDTO.Name;
                user.ImageUrl = "test";
                user.Email = appUserEditDTO.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDTO.Password);
                var result=await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }

    }
}
