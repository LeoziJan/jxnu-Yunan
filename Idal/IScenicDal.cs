using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    //扩展接口icommondal
    public partial interface IScenicDal : ICommonDal<Scenic>
    {
        //按价格排序
        IQueryable<Scenic> GetScenicByPrice(bool asc);

        //按类型查找
        IQueryable<Scenic> GetScenicByType(string type);

        //按旅行方式查询
        IQueryable<Scenic> GetScenicByStyle(string style);

        //按景区关键字查询
        IQueryable<Scenic> GetSceicByKeyWord(string keyword);

        //查找销量最好的景区
        IQueryable<Scenic> FindTopSales();

        //查询订单包含的景区
        Scenic GetScenicByOrder(Orders order);

        //是否插入景区
        bool InsertScenic(Scenic sc);

        IList<Scenic> GetScenic();

    }
}
