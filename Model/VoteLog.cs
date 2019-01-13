using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 点赞日志表
    /// </summary>
    [Table("VoteLog")]
    public class VoteLog
    {
        /// <summary>
        /// 点赞日志id
        /// </summary>
        [Key]
        public int VoteId { get; set; }
        /// <summary>
        /// 攻略id
        /// </summary>       
        public int NewsId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 点赞时间
        /// </summary>
        public DateTime VoteTime { get; set; }       
    }
}
