using EasyCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Macs;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		//public IActionResult Index(int id)/******16.derste int id sildik confirmmail.viewmodel de de int Id y string Mail yaptık
		public IActionResult Index()
		{
			var value = TempData["Mail"];
			ViewBag.v = value;

			//ViewBag.v=value + "aaa"; buna .com aaa olduktan sonra gerek kalmadı
			//confirmMailViewmodel.Mail=value.ToString();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
			//var value = "kblttm7777@hotmail.com"; //TempData["Mail"];*******16.derste açıklama satırı yaptık
            //var user=await _userManager.FindByEmailAsync(value.ToString());
            var user=await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);            
			if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
			{
				user.EmailConfirmed= true;
				await _userManager.UpdateAsync(user);
				//return RedirectToAction("Index","MyProfile");///18.derste bunu degiştirdik
				return RedirectToAction("Index","Login");
				//email confirmed kısmı update edilip ture 'ye dönecek
			}

			return View();

		}
	}
}

//Kullaıcı adı -şifre eşleşmesi-email confirmed olmalı
