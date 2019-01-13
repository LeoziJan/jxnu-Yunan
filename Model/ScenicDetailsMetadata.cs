using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    
    [MetadataType(typeof(ScenicDetailsMetadata))]
    public partial class ScenicDetails
    {
        /// <summary>
        /// 景点描述
        /// </summary>
        public string ScenicDescribe { get; set; }
        private class ScenicDetailsMetadata
        {                      
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ScenicDetailId { get; set; }
        }
    }

    
}
