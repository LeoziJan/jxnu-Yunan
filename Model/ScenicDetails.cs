using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 景点表
    /// </summary>
    [Table("ScenicDetails")]
    public partial class ScenicDetails
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScenicDetailId { get; set; }

        [ForeignKey("Scenic")]
        [Required]
        public int ScenicId { get; set; }

        /// <summary>
        /// 景点名字
        /// </summary>
        [Required]
        public string ScenicName { get; set; }
       
        /// <summary>
        /// 景点图片
        /// </summary>
        [Required]
        public string ScenicImg { get; set; }

        //导航属性
        public virtual Scenic Scenic { get; set; }

    }
}
