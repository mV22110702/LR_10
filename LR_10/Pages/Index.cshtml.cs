using LR_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LR_10.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public RegistrationForm? RegistrationForm { get; set; }
        ILogger<IndexModel> Logger { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            Logger = logger;
        }

        public void OnGet() { }
        
        public ActionResult OnPost() {
            Logger.LogInformation(JsonSerializer.Serialize(RegistrationForm));
            if (!ModelState.IsValid)
            {
                Logger.LogInformation(JsonSerializer.Serialize(ModelState));
                return Page();
            }
            TempData["registrationForm"] = JsonSerializer.Serialize<RegistrationForm>(RegistrationForm);
            return RedirectToPage("/RegistrationSuccess");
        }
    }

    public enum ProductEnum
    {
        [Display(Name = "Not chosen")]
        None,
        JavaScript,
        [Display(Name = "C#")]
        CSharp,
        Java,
        Python,
        Basics
    }
}
