using Esportiva.BLL;
using Esportiva.BLL.Interfaces;
using Esportiva.DAL;
using Esportiva.DAL.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Esportiva
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IJogadorBLL, JogadorBLL>();
            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IAutenticacaoBLL, AutenticacaoBLL>();
            container.RegisterType<ITimeBLL, TimeBLL>();


            container.RegisterType<IJogadorDAL, JogadorDAL>();
            container.RegisterType<IHomeDAL, HomeDAL>();
            container.RegisterType<IAutenticacaoDAL, AutenticacaoDAL>();
            container.RegisterType<ITimeDAL, TimeDAL>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
