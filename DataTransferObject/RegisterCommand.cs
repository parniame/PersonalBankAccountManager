using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class RegisterCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام الزامی است")]
        //[Display(Name = "نام")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        //[Display(Name = "نام خانوادگی")]
        //public string LastName { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        //[Display(Name = "نام کاربری")]

        //public string Username { get; set; }

        //[Display(Name = "سال تولد")]
        //public DateOnly? DateOfBirth { get; set; }
        //[Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است ")]
        //[Display(Name = "کلمه عبور ")]
        //[StringLength(100, ErrorMessage = "کلمه عبور  باید حداقل 3 حرف باشد", MinimumLength = 3)]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        //[Required(ErrorMessage = "وارد کردن تکرار کلمه عبور الزامی است")]
        //[Display(Name = "تکرار کلمه عبور")]
        //[StringLength(100, ErrorMessage = "تکرار کلمه عبور باید حداقل 3 حرف باشد", MinimumLength = 3)]
        //[DataType(DataType.Password)]
        //[Compare("UserPassword", ErrorMessage = "کلمه عبور و تکرار کلمه عبور باید یکسان باشد")]
        //public string ConfirmPassword { get; set; }
    }
}
