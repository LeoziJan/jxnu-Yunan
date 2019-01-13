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
    ///订单表
    ///</summary>
    [Table("Orders")]
    public class Orders
    {
        ///<summary>
        ///订单id
        ///</summary>
        [Key]
        public int OrderId { get; set; }    
        ///<summary>
        ///用户id
        ///</summary>
        [ForeignKey("user")]
        public int UserId { get; set; }
        ///<summary>
        ///订单生成时间
        ///</summary>
        [Required]
        public DateTime BuildTime { get; set; }
        ///<summary>
        ///订单总价
        ///</summary>
        [Required]
        public Decimal TotalPrice { get; set; }

        //导航属性
        public virtual Users user { get; set; }
        public virtual ICollection<OrderDetails> orderDetail { get; set; }
    }
}
