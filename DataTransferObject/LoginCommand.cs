using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class LoginCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        //[Display(Name = "نام کاربری")]

        //public string Username { get; set; }
        //[Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است ")]
        //[Display(Name = "کلمه عبور ")]
        //[StringLength(100, ErrorMessage = "کلمه عبور  باید حداقل 3 حرف باشد", MinimumLength = 3)]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

    }
}
