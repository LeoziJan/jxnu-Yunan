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
    /// 攻略评论表
    /// </summary>
    [Table("Talks")]
    public class Talks
    {
        [Key]
        public int TalkId { get; set; }

        [ForeignKey("News")]
        public int NewsId { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }

        /// <summary>
        /// 评论发表时间
        /// </summary>
        [Required]
        public DateTime TPostTime { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [Required]
        public string TalkContent { get; set; }

        //导航属性
        public virtual News News { get; set; }
        public virtual Users user { get; set; }
    }
}
