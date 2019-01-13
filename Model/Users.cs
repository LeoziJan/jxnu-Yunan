using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    ///<summary>
    ///用户表
    ///</summary>
    [Table("Users")]
    public partial class Users
    {
        ///<summary>
        ///用户id
        ///</summary>
        [Key]
        public int UserId { get; set; }
        ///<summary>
        ///用户姓名
        ///</summary>
        [Required]
        public string UserName { get; set; }
        ///<summary>
        ///用户密码
        ///</summary>
        [Required]
        public string UserPassward { get; set; }
        ///<summary>
        ///用户电话
        ///</summary>
        [Required]
        public Int64 UserTel { get; set; }
        ///<summary>
        ///用户生日
        ///</summary>
        [Required]
        public DateTime Birthday { get; set; }
        ///<summary>
        ///用户住址
        ///</summary>
        [Required]
        public string UserAddress { get; set; }
        ///<summary>
        ///用户头像
        ///</summary>
        public string UserHeadimg { get; set; }
        ///<summary>
        ///用户座右铭
        ///</summary>
        public string Usermotto { get; set; }

        [Required]
        public string IdCard { get; set; }

        //导航属性
        public virtual ICollection<Talks> Talk { get; set; }
        public virtual ICollection<Orders> Order { get; set; }
        public virtual ICollection<OrderDetails> OrderDetail { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<NewsDetalis> NewsDet { get; set; }    
    }
}
