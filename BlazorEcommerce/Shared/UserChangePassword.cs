using System.ComponentModel.DataAnnotations;

namespace BlazorEcommerce.Shared;

public class UserChangePassword
{
    [StringLength(100, MinimumLength = 6)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The passwords do not match")]
    [Required]
    public string ConfirmPassword { get; set; } = string.Empty;
}