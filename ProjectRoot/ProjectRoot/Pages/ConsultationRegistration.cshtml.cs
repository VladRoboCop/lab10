using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class ConsultationRegistrationModel : PageModel
{
    [BindProperty]
    public string FullName { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public DateTime ConsultationDate { get; set; }

    [BindProperty]
    public string Product { get; set; }

    public string ErrorMessage { get; set; }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Please fill in all required fields.";
            return;
        }

        if (!IsValidEmail(Email))
        {
            ErrorMessage = "Invalid email format.";
            return;
        }

        if (ConsultationDate < DateTime.Today || ConsultationDate.DayOfWeek == DayOfWeek.Saturday || ConsultationDate.DayOfWeek == DayOfWeek.Sunday)
        {
            ErrorMessage = "Invalid consultation date.";
            return;
        }

        if (Product == "Basics" && ConsultationDate.DayOfWeek == DayOfWeek.Monday)
        {
            ErrorMessage = "Consultation on Basics cannot be scheduled on Mondays.";
            return;
        }
    }

    private bool IsValidEmail(string email)
    {
        return email.Contains("@");
    }
}
