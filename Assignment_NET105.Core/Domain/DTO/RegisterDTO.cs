using Assignment_NET105.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105.Core.Domain.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Tên không được để trống !")]
        public string PersonName { get; set; }


        [Required(ErrorMessage = "Email không được để trống !")]
        [EmailAddress(ErrorMessage = "Email phải hợp lệ")]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email đã được sử dụng !")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone không được để trống !")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số điện thoại chỉ bao gồm chữ số !")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Mật khẩu không được để trống !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Nhập lại mật khẩu không được để trống !")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp nhau !")]
        public string ConfirmPassword { get; set; }

        public UserTypeOptions UserType { get; set; } = UserTypeOptions.User;
    }
}
