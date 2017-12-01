using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountVM
    {
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage="Yêu cầu")]
        public string username { get; set; }


        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression("^[0-1]")]
        public string password { get; set; }
    }
}