using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Model.ViewModel
{
    public class UserAccountViewmodel
    {
        public int Uid { get; set; }
        public ULoginViewModel ulogin { get; set; }
        public URegisterViewModel uregister { get; set; }

    }

    public class ULoginViewModel
    {
        [Required(ErrorMessage = "不为空")]
        [StringLength(10, ErrorMessage = "昵称长度为0~10")]
        //[CheckName]                                            //验证是否同名用户存在 方案一：用户自定义特性（失败）
        public string UserName { get; set; }

        [Required(ErrorMessage = "不为空")]
        [DataType(DataType.Password)]
        public string UserPassward { get; set; }
    }

    public class URegisterViewModel
    {
        [Required(ErrorMessage = "用户名不为空")]
        [StringLength(10, ErrorMessage = "昵称长度为0~10")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不为空")]
        [DataType(DataType.Password)]
        public string UserPassward { get; set; }

        [Required(ErrorMessage ="确认密码不为空")]
        [Display(Name ="确认密码")]
        [DataType(DataType.Password)]
        [Compare("UserPassward", ErrorMessage ="两次密码不一致")]
        public string ConfirmPassward { get; set; }

        [Required(ErrorMessage = "电话不为空")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "电话格式不正确")]
        public Int64 UserTel { get; set; }

        [Required(ErrorMessage = "生日不为空")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "地址不为空")]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "身份证不为空")]
        public string IdCard { get; set; }
    }
}