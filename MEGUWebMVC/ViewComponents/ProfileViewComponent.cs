using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MEGUWebMVC.Data.Entities.Identity;
using MEGUWebMVC.Models.Account;

namespace MEGUWebMVC.ViewComponents
{
    public class ProfileViewComponent(UserManager<UserEntity> userManager, IMapper mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity?.Name;
            var model = new ProfileViewModel();

            if (userName != null)
            {
                var user = userManager.FindByNameAsync(userName).Result;
                if (user != null)
                {
                    model = mapper.Map<ProfileViewModel>(user);
                }
            }

            return View(model);
        }
    }
}
