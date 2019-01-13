using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("AdminScenic")]
    public class AdminScenic
    {
        /// <summary>
        /// 表单id
        /// </summary>
        [Key]
        public int ASId { get; set; }

        /// <summary>
        /// 操作方式
        /// </summary>
        [Required]
        public string Actions { get; set; }

        [ForeignKey("Scenic")]
        [Required]
        public int ScenicId { get; set; }

        [Required]
        public DateTime ActTime { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }

        //导航属性
        public virtual Admins Admin { get; set; }
        public virtual Scenic Scenic { get; set; }


    }
}
