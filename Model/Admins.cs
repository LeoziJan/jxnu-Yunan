using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("Admins")]
    public class Admins
    {
       [Key]
       public int AdminId { get; set; }

        [Required]
        public string AdminPassWard { get; set; }

        [Required]
        public string AdminName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Required]
        public string HeadImg { get; set; }

        public int AdminFlag { get; set; }

        //导航属性
        public virtual ICollection<AdminScenic> adminScenic { get; set; }
    }
}
