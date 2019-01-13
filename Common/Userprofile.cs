using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using Model.ViewModel;

namespace Common
{
    public class Userprofile:Profile
    {
        public Userprofile()
        {
            CreateMap<Scenic,TopScenicViewModel>();
            CreateMap<Scenic,ScenicTypeViewModel>();
            CreateMap<Scenic, ScenicStyleViewModel>();
            CreateMap<Scenic, SortScenicTypeViewModel>();
            CreateMap<Scenic, ScenicListViewModel>();
            CreateMap<News, HotNewsViewModel>();
            CreateMap<News, AdminNewsViewModel>();
            CreateMap<News, NewsViewModel>();
            CreateMap<Users, UserEditviewModel>();
            CreateMap<UserEditviewModel, Users>();
            
        }
    }
}
