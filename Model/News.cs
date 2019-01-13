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
     /// 攻略表
     /// </summary>
     [Table("News")]
     public  class News
    {
        [Key]
        public int NewsId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        [Required]
        public DateTime PostTime { get; set; }

        /// <summary>
        /// 攻略标题
        /// </summary>
        [Required]
        public string NewsTitle { get; set; }

        /// <summary>
        /// 攻略内容
        /// </summary>
        [Required]
        public string NewsContent { get; set; }

        /// <summary>
        /// 攻略点赞数
        /// </summary>
        [Required]
        public int NewsVote { get; set; }

        /// <summary>
        /// 攻略封面图片
        /// </summary>
        [Required]
        public string NewsCoverImg { get; set; }

        //导航属性
        public virtual Users User { get; set; }
        public virtual ICollection<Talks> Talk { get; set; }
        public virtual ICollection<NewsDetalis> NewsDetails { get; set; }
    }
}
