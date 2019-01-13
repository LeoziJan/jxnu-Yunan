using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [MetadataType(typeof(UsersMetadata))]
    public partial class Users
    {
        private class UsersMetadata
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }

            [Required(ErrorMessage ="用户名不为空")]
            [StringLength(10,ErrorMessage ="昵称长度为0~10")]
            public string UserName { get; set; }

            [Required(ErrorMessage ="密码不为空")]
            [DataType(DataType.Password)]
            public string UserPassward { get; set; }

            [Required(ErrorMessage = "电话不为空")]
            [DataType(DataType.PhoneNumber,ErrorMessage ="电话格式不正确")]
            public Int64 UserTel { get; set; }

            [Required(ErrorMessage ="生日不为空")]           
            public DateTime Birthday { get; set; }

            [Required(ErrorMessage ="地址不为空")]          
            public string UserAddress { get; set; }
            
            [Required(ErrorMessage ="身份证不为空")]          
            public string IdCard { get; set; }
        }
    }
}
