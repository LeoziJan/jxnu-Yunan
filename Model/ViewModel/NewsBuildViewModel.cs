using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel
{
    public class NewsBuildViewModel
    {

        public NewBuildViewModel newBuild { get; set; }
        
    }

    public class NewBuildViewModel
    {
        public DateTime postTime { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="不超过20")]
        public string title { get; set; }

        [Required(ErrorMessage = "至少写点东西吧")]
        public string context { get; set; }

        public string img { get; set; }
    }
}