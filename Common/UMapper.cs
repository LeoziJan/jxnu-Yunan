using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IBLL;
using System.Collections;
using System.Data;
using AutoMapper.Configuration;

namespace Common
{
    public class MMapper
    {
        public static void MapperConfiguration()
        {
            Mapper.Initialize(m => m.AddProfile<Userprofile>());
        }       
    }
}
    /// <summary>
    /// 自定义mapper,未完成,白写了
    /// </summary>
//    public class UMapper : IUMapper, IDependency
//    {
//        private static readonly MapperConfigurationExpression MapperConfiguration = new MapperConfigurationExpression();

//        static UMapper()
//        {
//        }

//        private UMapper()
//        {
//            AutoMapper.Mapper.Initialize(MapperConfiguration);
//        }

//        public static UMapper Instance { get; } = new UMapper();

//        /// <summary>
//        /// 添加映射关系
//        /// </summary>
//        /// <typeparam name="TSource"></typeparam>
//        /// <typeparam name="TDestination"></typeparam>
//        public void AddMap<TSource, TDestination>() where TSource : class, new() where TDestination : class, new()
//        {
//            MapperConfiguration.CreateMap<TSource, TDestination>();
//        }

//        /// <summary>
//        /// 获取映射值
//        /// </summary>
//        /// <typeparam name="TDestination"></typeparam>
//        /// <param name="source"></param>
//        /// <returns></returns>
//        public TDestination Map<TDestination>(object source) where TDestination : class, new()
//        {
//            if (source == null)
//            {
//                return default(TDestination);
//            }

//            return Mapper.Map<TDestination>(source);
//        }

//        /// <summary>
//        /// 获取集合映射值
//        /// </summary>
//        /// <typeparam name="TDestination"></typeparam>
//        /// <param name="source"></param>
//        /// <returns></returns>
//        public IEnumerable<TDestination> Map<TDestination>(IEnumerable source) where TDestination : class, new()
//        {
//            if (source == null)
//            {
//                return default(IEnumerable<TDestination>);
//            }

//            return Mapper.Map<IEnumerable<TDestination>>(source);
//        }

//        /// <summary>
//        /// 获取映射值
//        /// </summary>
//        /// <typeparam name="TSource"></typeparam>
//        /// <typeparam name="TDestination"></typeparam>
//        /// <param name="source"></param>
//        /// <returns></returns>
//        public TDestination Map<TSource, TDestination>(TSource source) where TSource : class, new() where TDestination : class, new()
//        {
//            if (source == null)
//            {
//                return default(TDestination);
//            }

//            return Mapper.Map<TSource, TDestination>(source);
//        }

//        /// <summary>
//        /// 获取集合映射值
//        /// </summary>
//        /// <typeparam name="TSource"></typeparam>
//        /// <typeparam name="TDestination"></typeparam>
//        /// <param name="source"></param>
//        /// <returns></returns>
//        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source) where TSource : class, new() where TDestination : class, new()
//        {
//            if (source == null)
//            {
//                return default(IEnumerable<TDestination>);
//            }

//            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
//        }

//        /// <summary>
//        /// 读取DataReader内容
//        /// </summary>
//        /// <typeparam name="TDestination"></typeparam>
//        /// <param name="reader"></param>
//        /// <returns></returns>
//        public IEnumerable<TDestination> Map<TDestination>(IDataReader reader)
//        {
//            if (reader == null)
//            {
//                return new List<TDestination>();
//            }

//            var result = Mapper.Map<IEnumerable<TDestination>>(reader);

//            if (!reader.IsClosed)
//            {
//                reader.Close();
//            }

//            return result;
//        }
//    }
//}
