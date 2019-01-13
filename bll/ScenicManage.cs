  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using Dal;

namespace bll
{
    public partial class ScenicManage : CommonManage<Scenic>, IScenicManage,IDependency
    {
        private ScenicDal sd = new ScenicDal();

        /// <summary>
        /// 按销量查询景区
        /// </summary>
        /// <returns></returns>
        public IQueryable<Scenic> FindTopSalesService()
        {
            return sd.FindTopSales();
        }

        /// <summary>
        /// 按关键字查询景区
        /// </summary>
        /// <param name="keyword">搜索关键字</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetSceicByKeyWordService(string keyword)
        {
            return sd.GetSceicByKeyWord(keyword);
        }

        /// <summary>
        /// 查询订单包含的景区
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Scenic GetScenicByOrderService(Orders order)
        {
            return sd.GetScenicByOrder(order);
        }

        /// <summary>
        /// 按价格升序或降序查询景区
        /// </summary>
        /// <param name="asc">是否降序</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByPriceService(bool asc)
        {
            return sd.GetScenicByPrice(asc);
        }

        /// <summary>
        /// 按景区游玩方式查询景区
        /// </summary>
        /// <param name="style">游玩方式</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByStyleService(string style)
        {
            return sd.GetScenicByStyle(style);
        }

        /// <summary>
        /// 按景区类型查询景区
        /// </summary>
        /// <param name="type">景区类型</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByTypeService(string type)
        {
            return sd.GetScenicByType(type);
        }

        public Scenic GetScenicById(int id)
        {
            return sd.GetScenicById(id);
        }

        public int GetSOrderCount(int id)
        {
            return sd.count(id);
        }
        public bool InsertScenic(Scenic sc)
        {
            return sd.InsertScenic(sc);
        }
        public IList<Scenic> GetScenic()
        {
            return sd.GetScenic();
        }

    }
}
