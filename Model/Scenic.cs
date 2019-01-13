using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    ///<summary>
    ///景区表
    ///</summary>
    [Table("Scenic")]
    public class Scenic
    {     
        ///<summary>
        ///景区id
        ///</summary>
        [Key]
        public int ScenicId { get; set; }
        ///<summary>
        ///景区标题
        ///</summary>
        [Required]
        public string ScenicTitle { get; set; }
        ///<summary>
        ///景区地址
        ///</summary>
        [Required]
        public string City { get; set; }
        ///<summary>
        ///景区类型
        ///</summary>
        [Required]
        public string type { get; set; }
        ///<summary>
        ///景区描述
        ///</summary>
        [Required]
        public string ScenicContent { get; set; }
        ///<summary>
        ///景区点赞数
        ///</summary>
        [Required]
        public int ScenicVote { get; set; }
        ///<summary>
        ///旅行方式
        ///</summary>
        [Required]
        public string ScenicStyle { get; set; }
        ///<summary>
        ///景区价格
        ///</summary>
        [Required]
        public Decimal ScenicPrice { get; set; }
        ///<summary>
        ///景区天数
        ///</summary>
        [Required]
        public int Days { get; set; }
        ///<summary>
        ///景区封面图片
        ///</summary>
        [Required]
        public string ScenicCoverImg { get; set; }
        ///<summary>
        ///景区关键字
        ///</summary>
        [Required]
        public string ScenicKeyWord { get; set; }

        //[ForeignKey("ScenicDetail")]
        //public int ScenicDetailId { get; set; }

        //导航属性
        //public virtual Scenic Scenic1 { get; set; }
        public virtual ICollection<ScenicDetails> ScenicDetail { get; set; }
        public virtual ICollection<OrderDetails> OrderDetail { get; set; }
        public virtual ICollection<AdminScenic> AdminScenic { get; set; }
    }
}
