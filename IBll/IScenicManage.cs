using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface IScenicManage:ICommonManage<Scenic>,IDependency
    {
        //按价格排序
        IQueryable<Scenic> GetScenicByPriceService(bool asc);

        //按类型查找
        IQueryable<Scenic> GetScenicByTypeService(string type);

        //按旅行方式查询
        IQueryable<Scenic> GetScenicByStyleService(string style);

        //按景区关键字查询
        IQueryable<Scenic> GetSceicByKeyWordService(string keyword);

        //查找销量最好的景区
        IQueryable<Scenic> FindTopSalesService();

        //查询订单包含的景区
        Scenic GetScenicByOrderService(Orders order);

        Scenic GetScenicById(int id);

        int GetSOrderCount(int id);
    }
}
