using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model.ViewModel
{
    public class UOrderDetailViewModel
    {
        public Orders order { get; set; }
        public List<OdetailViewModel> odetail { get; set; }
    }

    public class OdetailViewModel
    {
        public int sid { get; set; }
        public string stitle { get; set; }
        public string simg { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }
        public DateTime begintime { get; set; }
        public DateTime finishtime { get; set; }
        public int pnumber { get; set; }
        public decimal price { get; set; }
        public string transport { get; set; }
    }
}