using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel
{
    public class UserInfoViewModel
    {
        public decimal OrderTotlePrice { get; set; }
        public Users user { get; set; }
        public List<UserOrderViewModel> userOrder { get; set; }
        public List<UserNewsViewModel> userNews { get; set; }
    }

    public class UserNewsViewModel
    {
        public int Nid { get; set; }
        public string Uname { get; set; }
        public string Uimg { get; set; }
        public string Ntitle { get; set; }
        public DateTime postime { get; set; }
        public string context { get; set; }
    }

    public class UserOrderViewModel
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int Oid { get; set; }        
        public string Simg { get; set; }
        public int Sid { get; set; }
        public string Stitle { get; set; }
        public decimal price { get; set; }
        public int punmber { get; set; }
        public decimal totlePrice { get; set; }
    }
}