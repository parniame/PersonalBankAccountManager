using PersonalBankAccountManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace PersonalBankAccountManager.Models
{
    public class LoginViewModel
    {
        [Display(Name = "UsernameProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        public string UserName { get; set; }

        [Display(Name = "PasswordProp", ResourceType = typeof(PresentationResources))]
        [Required(ErrorMessageResourceType = typeof(PresentationResources), ErrorMessageResourceName = "RequiredValidationMessage")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "اطلاعات ذخیره شود؟")]
        public bool RememberMe { get; set; }
    }
}
