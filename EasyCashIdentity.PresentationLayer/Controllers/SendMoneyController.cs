using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DTOLayer.DTOS.CustomerAccountProcessDtOS;
using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            sendMoneyForCustomerAccountProcessDTO.SenderID = user.Id;
            sendMoneyForCustomerAccountProcessDTO.ProcessDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomerAccountProcessDTO.Process = "Havale";
            var receiverAccountNumber=context.CustomerAccounts

            //AppUser appUser=new AppUser()
            //{
                
            //};
            return View();
        }
    }
}
