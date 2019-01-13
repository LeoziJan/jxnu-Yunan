using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    /// <summary>
    /// 订单详细表
    /// </summary>
    [Table("OrderDetails")]
    public partial class OrderDetails
    {
        ///<summary>
        ///景点详细id
        ///</summary>
        [Key]
        public int OrderDetailId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Scenic")]
        [Required]
        public int ScenicId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        /// <summary>
        /// 出行时间
        /// </summary>
        [Required]
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 旅游结束时间
        /// </summary>
        [Required]
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// 接送地址
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// 景区价格
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 出行方式
        /// </summary>
        [Required]
        public string Transport { get; set; }       
       
        //导航属性
        public virtual Scenic Scenic { get; set; }
        public virtual Users User { get; set; }
        public virtual Orders Order { get; set; }

    }
}
