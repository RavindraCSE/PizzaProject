using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string EmailAddress { get; set; } = default!;

        [Required(ErrorMessage ="Password is required")]
        [MinLength(5,ErrorMessage ="Password should be off five characters")]
        [MaxLength(15,ErrorMessage ="Password can be 15 char. max")]
        public string Password { get; set; }= default!;
    }
}
