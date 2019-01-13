using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("NewsDetails")]
    public class NewsDetalis
    {
        /// <summary>
        /// 攻略详细id
        /// </summary>
        [Key]        
        public int NewsDetId { get; set; }

        /// <summary>
        /// 攻略id
        /// </summary>
        [ForeignKey("news")]
        public int NewsId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [ForeignKey("user")]
        public int UserId { get; set; }

        /// <summary>
        /// 攻略详细图片
        /// </summary>
        public string NewsImg { get; set; }

        public virtual Users user { get; set; }
        public virtual News news { get; set; }
    }
}
