using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel
{  
    public class UserEditviewModel
    {
        [Required(ErrorMessage = "用户名不为空")]
        [StringLength(10, ErrorMessage = "昵称长度为0~10")]
        public string UserName { get; set; }      

        [Required(ErrorMessage = "电话不为空")]          
        public Int64 UserTel { get; set; }

        [Required(ErrorMessage = "生日不为空")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "地址不为空")]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "身份证不为空")]
        public string IdCard { get; set; }      
        public string UserHeadimg { get; set; }

        [Required(ErrorMessage ="描述一下自己呗")]
        public string UserMotto { get; set; }
    }

}

   
