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
    /// 攻略表
    /// </summary>
    [Table("NewsCollect")]
    public class NewsCollect
    {
        [Key]
        public int Id { get; set; }
      
        public int NewsId { get; set; }
       
        public int UserId { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>            
        public DateTime CreateTime { get; set; }           

        ////导航属性
        //public virtual Users User { get; set; }
        //public virtual News News { get; set; }           
    }
    
}
