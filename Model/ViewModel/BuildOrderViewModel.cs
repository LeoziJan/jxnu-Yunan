using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;

namespace Model.ViewModel
{
    public class BuildOrderViewModel
    {
        public OrderDetailsViewModel orderDetail { get; set; }             
        public IList<TransportViewModel> Transport { get; set; }
    }

    public class TransportViewModel
    {
        public int tsid { get; set; }
        public string tsname { get; set; }
    }

    public class OrderDetailsViewModel
    {
        [Required(ErrorMessage ="请选择出行时间")]
        public DateTime BeginTime { get; set; }

        [Required(ErrorMessage ="请填写联系人电话")]
        [StringLength(11,ErrorMessage ="请输入正确电话号码")]
        public string phone { get; set; }

        [Required(ErrorMessage ="请输入地址")]
        public string Address { get; set; }

        [Required(ErrorMessage ="至少一人")]
        public int punmber { get; set; }

        [Required(ErrorMessage ="请选择出行方式")]
        public string transport { get; set; }
   
        public decimal price { get; set; }

        public int ScenicId { get; set; }

        public static implicit operator OrderDetailsViewModel(BuildOrderViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}