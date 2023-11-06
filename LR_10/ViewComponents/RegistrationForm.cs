using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace LR_10.ViewComponents
{
    public class RegistrationForm : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {

            return View();
        }
    }
}
