using LR_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LR_10.Pages
{
    public class RegistrationSuccessModel : PageModel
    {
        public RegistrationForm? RegistrationFormToShow { get; set; }
        public ActionResult OnGet()
        {
            if (TempData.TryGetValue("registrationForm", out object? registrationFormJson) && registrationFormJson != null)
            {
                try
                {
                    RegistrationFormToShow = (RegistrationForm)JsonSerializer.Deserialize<RegistrationForm>((string)registrationFormJson);
                    return Page();
                } catch(Exception ex)
                {
                    return RedirectToPage("/Index");
                }
            }
            return RedirectToPage("/Index");
        }
    }
}
